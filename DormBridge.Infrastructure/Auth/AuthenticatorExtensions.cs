using System.Text;
using DormBridge.Application.Authenticator;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;


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
                });

            return services;
        }
    }
}
