using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;


namespace DormBridge.Infrastructure.Authenticator
{
    public static class AuthenticatorExtensions
    {
        private const string authenticator = "Authentication";

        public static IServiceCollection AddAuthenticator(this IServiceCollection services, IConfiguration configuration)
        {
            var authenticatorOptions = new AuthenticatorOptions();
            configuration.GetSection(authenticator).Bind(authenticatorOptions);

            services.AddAuthentication(option =>
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
                    ValidIssuer = authenticatorOptions.Issuer,
                    ValidAudience = authenticatorOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticatorOptions.SigninKey))
                };
            });

            return services;
        }
    }
}
