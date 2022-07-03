using System.Globalization;

namespace Schedulerry.Api.ApplicationServices.OriginUrlSettings
{
    public class OriginUrlSettings : IOriginUrlSettings
    {
        public OriginUrlSettings(string originUrl)
        {
            OriginUrl = originUrl;
        }

        public string OrganizerVerifyProfile(params object[] args)
        {
            var url = "{origin}/organizer/verify?code={0}";
            url = url.Replace(OriginPlaceholder, OriginUrl);
            return string.Format(CultureInfo.InvariantCulture, url, args);
        }

        public string OrganizerInvitedToOrganization(params object[] args)
        {
            var url = "{origin}/organizer/join-organization?code={0}";
            url = url.Replace(OriginPlaceholder, OriginUrl);
            return string.Format(CultureInfo.InvariantCulture, url, args);
        }

        public string CustomerVerifyProfile(params object[] args)
        {
            var url = "{origin}/customer/verify?code={0}";
            url = url.Replace(OriginPlaceholder, OriginUrl);
            return string.Format(CultureInfo.InvariantCulture, url, args);
        }

        private string OriginUrl { get; set; }

        private readonly string OriginPlaceholder = "{origin}";
    }
}
