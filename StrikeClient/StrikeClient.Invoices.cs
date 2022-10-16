using StrikeClient.Models;
using StrikeClient.Request;
using System.Text;

namespace StrikeClient
{
    /// <summary>
    /// Invoice level API endpoints:
    /// - Get invoices (OData support)
    /// - Create invoice for your own account
    /// - Get invoice by Id
    /// - Create invoice for an invoiceable Strike user
    /// - Issue a new quote for existing invoice
    /// - Cancel an unpaid invoice (TODO, maybe)
    /// </summary>
    public partial class StrikeClient
    {
        /// <summary>
        /// Query for invoices using OData
        /// </summary>
        /// <param name="oDataFilter">https://docs.microsoft.com/en-us/openspecs/windows_protocols/ms-odata/7d6c4117-317d-4860-915b-7e321be017e3</param>
        /// <param name="oDataOrderBy">https://docs.microsoft.com/en-us/openspecs/windows_protocols/ms-odata/793b1e83-95ee-4446-8434-f5b634f20d1e</param>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public async Task<Invoices?> GetInvoices(string oDataFilter = "", string oDataOrderBy = "", int skip = 0, int top = 10, Action<StrikeApiResponse>? logger = null)
        {
            StringBuilder builder = new($"v1/invoices?skip={skip}&top={top}");

            if (!string.IsNullOrWhiteSpace(oDataFilter))
            {
                builder.Append($"&filter={oDataFilter}");
            }

            if (!string.IsNullOrWhiteSpace(oDataOrderBy))
            {
                builder.Append($"&orderby={oDataOrderBy}");
            }

            string path = builder.ToString();

            return await SendGetAsync<Invoices>(path, logger).ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Issue a new invoice. Only currencies which are invoiceable for the caller's account can be used. 
        /// Invoiceable currencies can be found using get account profile endpoint.
        /// </summary>
        /// <param name="correlationId">Invoice correlation id. Must be a unique value. Can be used to correlate the invoice with an external entity</param>
        /// <param name="description">Invoice description</param>
        /// <param name="invoiceAmount">Invoice amount. Only currencies which are invoiceable for the receiver's account can be used. Invoiceable currencies can be found using get account profile endpoint.</param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public async Task<Invoice?> CreateInvoice(string correlationId, string description, InvoiceAmount invoiceAmount, Action<StrikeApiResponse>? logger = null)
        {
            string path = "v1/invoices";

            return await SendPostAsync<CreateInvoiceRequest, Invoice>(path, new CreateInvoiceRequest
            {
                CorrelationId = correlationId,
                Description = description,
                Amount = invoiceAmount
            }, logger).ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Find invoice by id
        /// </summary>
        /// <param name="invoiceId">Invoice id</param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public async Task<Invoice?> GetInvoice(string invoiceId, Action<StrikeApiResponse>? logger = null)
        {
            string path = $"v1/invoices/{invoiceId}";

            return await SendGetAsync<Invoice>(path, logger).ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Issue a new invoice for specified receiver.
        /// Only currencies which are invoiceable for the receiver's account can be used. 
        /// Invoiceable currencies can be found using get account profile endpoint to fetch account details for the receiver.
        /// </summary>
        /// <param name="handle">Handle of the invoice receiver</param>
        /// <param name="correlationId">Invoice correlation id. Must be a unique value. Can be used to correlate the invoice with an external entity</param>
        /// <param name="description">Invoice description</param>
        /// <param name="invoiceAmount">Invoice amount. Only currencies which are invoiceable for the receiver's account can be used. Invoiceable currencies can be found using get account profile endpoint.</param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public async Task<Invoice?> CreateInvoiceForUser(string handle, string correlationId, string description, InvoiceAmount invoiceAmount, Action<StrikeApiResponse>? logger = null)
        {
            string path = $"v1/invoices/handle/{handle}";

            return await SendPostAsync<CreateInvoiceRequest, Invoice>(path, new CreateInvoiceRequest
            {
                CorrelationId = correlationId,
                Description = description,
                Amount = invoiceAmount
            }, logger).ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Issue a new quote for specified invoice. This method 
        /// provides the actual BOLT11 payrequest and onChain address 
        /// whereas the CreateInvoiceForUser() method creates the reference 
        /// for which BOLT11 pay requests are associated.
        /// 
        /// Strike's model is primarily denominated in USD so the pay request 
        /// needs to be regenerated based on market price of BTC.
        /// </summary>
        /// <param name="invoiceId">Id of invoice for which the quote is requested</param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public async Task<InvoiceQuote?> IssueQuote(string invoiceId, Action<StrikeApiResponse>? logger = null)
        {
            string path = $"v1/invoices/{invoiceId}/quote";

            return await SendPostAsync<EmptyBodyRequest, InvoiceQuote>(path, new EmptyBodyRequest(),
                logger).ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}
