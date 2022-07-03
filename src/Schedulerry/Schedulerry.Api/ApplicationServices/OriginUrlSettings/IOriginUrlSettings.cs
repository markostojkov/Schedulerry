namespace Schedulerry.Api.ApplicationServices.OriginUrlSettings
{
    public interface IOriginUrlSettings
    {
        public string OrganizerVerifyProfile(params object[] args);

        public string CustomerVerifyProfile(params object[] args);

        public string OrganizerInvitedToOrganization(params object[] args);
    }
}
