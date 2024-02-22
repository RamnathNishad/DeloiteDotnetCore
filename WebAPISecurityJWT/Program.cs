using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPISecurityJWT.Models;

namespace WebAPISecurityJWT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //configure JWT Bearer Authentication
            builder.Services.AddAuthentication(x => {
                //Type of authentication scheme
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                //parameters for token validation
                var key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer=true, 
                    ValidateAudience=true,
                    ValidateLifetime=true,
                    ValidateIssuerSigningKey=true,

                    ValidIssuer= builder.Configuration["JWT:Issuer"],
                    ValidAudience= builder.Configuration["JWT:Audience"],
                    IssuerSigningKey=new SymmetricSecurityKey(key)
                };
            });

            //configure the dependency injection for the EmployeeDataAccess
            builder.Services.AddScoped<IEmpDataAccess, EmployeeDataAccess>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            //use the authentiction and authorization before app.Run()
            app.UseAuthentication(); //make sure this sequence
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
