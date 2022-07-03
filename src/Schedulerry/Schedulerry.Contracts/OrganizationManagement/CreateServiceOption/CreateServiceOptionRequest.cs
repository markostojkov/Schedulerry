using Schedulerry.Common.DateAndTime;
using Schedulerry.Contracts.FieldValidators;

namespace Schedulerry.Contracts.OrganizationManagement
{
    public class CreateServiceOptionRequest
    {
        [ServiceNameValidator]
        public string Name { get; set; }

        [ServiceDescriptionValidator]
        public string Description { get; set; }

        [UrlValidator]
        public string ImageUrl { get; set; }

        [RequiredValidator]
        public TimeLengthMinutesOptionsEnum TimeLength { get; set; }

        [ServiceOptionPriceValidator]
        public decimal Price { get; set; }

        [CurrencyValidator]
        public string Currency { get; set; }
    }
}
