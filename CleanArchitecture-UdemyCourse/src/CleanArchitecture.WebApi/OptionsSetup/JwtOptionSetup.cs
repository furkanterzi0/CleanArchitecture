using CleanArchitecture.Infrastructure.Authentication;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.WebApi.OptionsSetup
{
    public class JwtOptionSetup : IConfigureOptions<JwtOptions>
    {
        private readonly IConfiguration configuration;

        public JwtOptionSetup(IConfiguration configuration)
        {
            this.configuration=configuration;
        }
        public void Configure(JwtOptions options)
        {
            configuration.GetSection("Jwt").Bind(options);
        }
    }
}
