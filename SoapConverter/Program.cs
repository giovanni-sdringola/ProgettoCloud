using SoapConverter.Business_Logics;
using SoapCore;
namespace SoapConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSoapCore();
            builder.Services.AddScoped<ISoapService, SoapService>();

            var app = builder.Build();

            app.UseRouting();
            // app.MapGet("/", () => "Hello World!");

            app.UseEndpoints(endpoints =>
            {
                endpoints.UseSoapEndpoint<ISoapService>("/Service.wsdl", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
            });

            app.Run();
        }
    }
}