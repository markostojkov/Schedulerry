using Microsoft.Extensions.Configuration;
using Schedulerry.Identity.Contracts.AppSettings;
using System.Collections.Generic;

namespace Schedulerry.Identity.Services
{
    public class AppSettings
    {
        public AppSettings(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public CorsSettings CorsSettings {
            get
            {
                var cors = new CorsSettings();
                Configuration.GetSection("app:corsSettings").Bind(cors);
                return cors;
            } 
        }

        public IdentityServerSettings IdentityServerSettings { 
            get
            {
                var identitySettings = new IdentityServerSettings();
                var apiResourceSettings = new List<ApiResourceSettings>();
                var clientsSettings = new List<ClientsSettings>();
                var apiScopesSettings = new List<ApiScopesSettings>();

                Configuration.GetSection("app:identityServerSettings:apiResources").Bind(apiResourceSettings);
                Configuration.GetSection("app:identityServerSettings:clients").Bind(clientsSettings);
                Configuration.GetSection("app:identityServerSettings:apiScopes").Bind(apiScopesSettings);

                identitySettings.ApiResourceSettings = apiResourceSettings;
                identitySettings.ClientsSettings = clientsSettings;
                identitySettings.ApiScopesSettings = apiScopesSettings;

                return identitySettings;
            }
        }

        private IConfiguration Configuration { get; }
    }
}
