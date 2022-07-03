using System.Collections.Generic;

namespace Schedulerry.Identity.Contracts.AppSettings
{
    public class IdentityServerSettings
    {
        public List<ApiResourceSettings> ApiResourceSettings { get; set; }

        public List<ClientsSettings> ClientsSettings { get; set; }

        public List<ApiScopesSettings> ApiScopesSettings { get; set; }
    }

    public class ApiResourceSettings
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public List<string> ApiSecrets { get; set; }

        public List<string> ApiScopes { get; set; }

        public List<string> ApiClaims { get; set; }
    }

    public class ClientsSettings
    {
        public string ClientName { get; set; }

        public string ClientId { get; set; }

        public bool AllowAccessTokensViaBrowser { get; set; }

        public List<string> AllowedCorsOrigins { get; set; }

        public List<string> AllowedScopes { get; set; }

        public bool AllowRememberConsent { get; set; }

        public List<string> RedirectUris { get; set; }

        public List<string> PostLogoutRedirectUris { get; set; }
    }

    public class ApiScopesSettings
    {
        public string Name { get; set; }
    }
}
