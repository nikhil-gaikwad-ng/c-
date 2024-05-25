using Microsoft.Identity.Web;

namespace AzureADAuth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddMicrosoftIdentityWebApiAuthentication(builder.Configuration);

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthentication();

/*            app.Use(async (context,next)=>
            {
                if (!context.User.Identity?.IsAuthenticated ?? false)
                {
                    context.Response.StatusCode = 401;
                    context.Response.WriteAsJsonAsync("Unauthorised");
                }
                else
                {
                    await next();
                }
            });*/
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
