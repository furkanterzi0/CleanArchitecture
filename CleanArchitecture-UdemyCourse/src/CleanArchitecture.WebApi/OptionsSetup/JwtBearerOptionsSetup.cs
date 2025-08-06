using CleanArchitecture.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CleanArchitecture.WebApi.OptionsSetup
{
    public class JwtBearerOptionsSetup : IPostConfigureOptions<JwtBearerOptions>
    {
        private readonly JwtOptions jwtOptions;

        public JwtBearerOptionsSetup(IOptions<JwtOptions> jwtOptions)
        {
            this.jwtOptions=jwtOptions.Value;
        }

        public void PostConfigure(string? name, JwtBearerOptions options)
        {
            options.TokenValidationParameters.ValidateIssuer = true;
            options.TokenValidationParameters.ValidateAudience = true;
            options.TokenValidationParameters.ValidateLifetime = true;
            options.TokenValidationParameters.ValidateIssuerSigningKey= true;

            options.TokenValidationParameters.ValidIssuer = jwtOptions.Issuer;
            options.TokenValidationParameters.ValidAudience = jwtOptions.Audience;

            options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey));
        }
    }
}
