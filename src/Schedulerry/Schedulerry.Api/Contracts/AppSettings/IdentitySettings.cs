namespace Schedulerry.Api.Contracts.AppSettings
{
    public class IdentitySettings
    {
        public string Authority { get; set; }

        public string Audience { get; set; }

        public bool RequireHttpsMetadata { get; set; }
    }
}
