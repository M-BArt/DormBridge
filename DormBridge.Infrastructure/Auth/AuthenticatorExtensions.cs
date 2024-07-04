using System.Text;
using DormBridge.Application.Authenticator;
using DormBridge.Application.DTOs.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;


namespace DormBridge.Infrastructure.Auth
{
    public static class AuthenticatorExtensions
    {
        private const string authenticator = "Authentication";

        public static IServiceCollection AddAuthenticator(this IServiceCollection services, IConfiguration configuration)
        {
            var authenticatorOptions = new AuthenticatorOptions();
            configuration.GetSection(authenticator).Bind(authenticatorOptions);

            services.Configure<AuthenticatorOptions>(configuration.GetSection(authenticator));

            services
                .AddSingleton<IAuthenticator, Authenticator>()
                .AddAuthentication(option =>
                {
                    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                }).AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.IncludeErrorDetails = false;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = authenticatorOptions.JwtIssuer,
                        ValidAudience = authenticatorOptions.JwtAudience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticatorOptions.JwtKey))
                    };

                    cfg.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = ctx =>
                        {
                            
                            
                            ctx.Request.Cookies.TryGetValue("accessToken", out var accessToken);
                            
                            if (!string.IsNullOrEmpty(accessToken))
                            {
                                ctx.Token = accessToken;
                                Console.WriteLine($"Token from cookie: {accessToken}"); // Dodaj logowanie
                            }
                            else
                            {
                                Console.WriteLine("No token found in cookie."); // Dodaj logowanie
                            }
                            return Task.CompletedTask;
                        }
                    };
                });
            //services.AddAuthorization(authorization =>
            //{
            //    authorization.AddPolicy("IsPersonnel", policy =>
            //    {
            //        policy.RequireRole("personnel");
            //    });
            //});


            return services;
        }
    }
}
