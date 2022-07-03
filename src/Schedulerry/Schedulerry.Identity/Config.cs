using IdentityServer4.Models;
using Schedulerry.Identity.Services;
using System.Collections.Generic;
using System.Linq;

namespace Schedulerry.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes(AppSettings appSettings)
        {
            return appSettings.IdentityServerSettings.ApiScopesSettings.Select(x => new ApiScope(x.Name));
        }

        public static IEnumerable<ApiResource> ApiResources(AppSettings appSettings)
        {
            return appSettings.IdentityServerSettings.ApiResourceSettings.Select(x =>
            {
                return new ApiResource
                {
                    Name = x.Name,
                    DisplayName = x.DisplayName,
                    ApiSecrets = x.ApiSecrets.Select(x => new Secret(x.Sha256())).ToArray(),
                    Scopes = x.ApiScopes.ToArray(),
                    UserClaims = x.ApiClaims.ToArray()
                };
            });
        }

        public static IEnumerable<Client> Clients(AppSettings appSettings)
        {
            return appSettings.IdentityServerSettings.ClientsSettings.Select(x =>
            {
                return new Client
                {
                    ClientName = x.ClientName,
                    ClientId = x.ClientId,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = x.AllowAccessTokensViaBrowser,
                    AllowedCorsOrigins = x.AllowedCorsOrigins,
                    AllowRememberConsent = x.AllowRememberConsent,
                    AllowedScopes = x.AllowedScopes,
                    RedirectUris = x.RedirectUris,
                    PostLogoutRedirectUris = x.PostLogoutRedirectUris
                };
            });
        }
    }
}