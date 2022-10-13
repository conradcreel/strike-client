﻿using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace StrikeClient
{
    public partial class StrikeClient
    {
        private const string _ContentType = "application/json";
        private const string _Accept = "application/json";
        private const string _Scheme = "Bearer";
        private readonly Encoding _Encoding = Encoding.UTF8;

        private readonly StrikeConfiguration _Configuration;
        private readonly HttpClient _Http;

        public StrikeClient(StrikeConfiguration configuration, HttpClient http)
        {
            _Configuration = configuration;
            _Http = http;

            _Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_Scheme, _Configuration.ApiKey);
        }

        private void DoNothing(StrikeApiResponse apiResponse) { }

        protected async Task<TResponse?> SendPostAsync<TRequest, TResponse>(string url, TRequest? data, Action<StrikeApiResponse>? logger = null)
        {
            if (logger == null)
            {
                logger = DoNothing;
            }

            try
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                httpRequestMessage.Headers.Add("Accept", _Accept);

                var requestBody = JsonSerializer.Serialize(data, SerializationUtility.SerializerOptions);

                httpRequestMessage.Content = new StringContent(requestBody, _Encoding, _ContentType);

                var response = await _Http.SendAsync(httpRequestMessage).ConfigureAwait(continueOnCapturedContext: false);

                if (!response.IsSuccessStatusCode)
                {
                    var errorBody = await response.Content.ReadAsStringAsync();

                    logger(new StrikeApiResponse
                    {
                        IsSuccess = false,
                        StatusCode = (int)response.StatusCode,
                        Message = errorBody
                    });


                    return default;
                }

                var responseBody = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<TResponse>(responseBody);
            }
            catch (Exception ex)
            {
                logger(new StrikeApiResponse
                {
                    Exception = ex
                });
            }

            return default;
        }

        protected async Task<TResponse?> SendGetAsync<TResponse>(string url, Action<StrikeApiResponse>? logger = null)
        {
            if (logger == null)
            {
                logger = DoNothing;
            }

            try
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                httpRequestMessage.Headers.Add("Accept", _Accept);

                var response = await _Http.SendAsync(httpRequestMessage).ConfigureAwait(continueOnCapturedContext: false);

                if (!response.IsSuccessStatusCode)
                {
                    var errorBody = await response.Content.ReadAsStringAsync();

                    logger(new StrikeApiResponse
                    {
                        IsSuccess = false,
                        StatusCode = (int)response.StatusCode,
                        Message = errorBody
                    });

                    return default;
                }

                var responseBody = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<TResponse>(responseBody);
            }
            catch (Exception ex)
            {
                logger(new StrikeApiResponse
                {
                    Exception = ex
                });
            }

            return default;
        }
    }
}