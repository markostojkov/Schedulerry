namespace Schedulerry.Api.ApplicationServices.Authentication
{
    public static class AuthenticationPolicy
    {
        public const string Organizer = "Organizer";
        public const string Customer = "Customer";
        public const string OrganizationManagedByCurrentOrganizer = "OrganizationManagedByCurrentOrganizer";
        public const string ServiceManagedByCurrentOrganizerOrganization = "ServiceManagedByCurrentOrganizerOrganization";
        public const string ServiceOptionBelongsToServiceManagedByCurrentOrganizerOrganization = "ServiceOptionBelongsToServiceManagedByCurrentOrganizerOrganization";

    }
}
