using StrikeClient;

namespace StrikeWebhook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddSingleton(new StrikeConfiguration
            {
                ApiKey = builder.Configuration["Strike:Key"],
                Endpoint = builder.Configuration["Strike:Endpoint"]
            });

            builder.Services.AddHttpClient<StrikeClient.StrikeClient>();

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}