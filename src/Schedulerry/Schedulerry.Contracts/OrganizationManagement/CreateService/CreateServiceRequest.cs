using Schedulerry.Contracts.FieldValidators;

namespace Schedulerry.Contracts.OrganizationManagement
{
    public class CreateServiceRequest
    {
        [ServiceNameValidator]
        public string Name { get; set; }

        [ServiceDescriptionValidator]
        public string Description { get; set; }

        [UrlValidator]
        public string ImageUrl { get; set; }
    }
}
