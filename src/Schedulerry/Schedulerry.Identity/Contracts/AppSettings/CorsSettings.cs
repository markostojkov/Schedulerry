namespace Schedulerry.Identity.Contracts.AppSettings
{
    public class CorsSettings
    {
        public string CorsPolicyName { get; set; }
    
        public string[] AllowedCorsOrigins { get; set; }
    }
}
