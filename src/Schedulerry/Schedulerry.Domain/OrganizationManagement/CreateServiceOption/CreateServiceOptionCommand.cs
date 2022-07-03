using Schedulerry.Common.DateAndTime;
using Schedulerry.Common.Mediator.Contracs;
using System;

namespace Schedulerry.Domain.OrganizationManagement
{
    public class CreateServiceOptionCommand : ICommand<CreateServiceOptionDto>
    {
        public CreateServiceOptionCommand(
            Guid organizationUid,
            Guid serviceUid,
            string name,
            string description,
            string logoUrl,
            decimal price,
            string currency,
            TimeLengthMinutesOptionsEnum serviceOptionTimeLength)
        {
            OrganizationUid = organizationUid;
            ServiceUid = serviceUid;
            Name = name;
            Description = description;
            LogoUrl = logoUrl;
            Price = price;
            Currency = currency;
            ServiceOptionTimeLength = serviceOptionTimeLength;
        }

        public Guid OrganizationUid { get; }

        public Guid ServiceUid { get; }

        public string Name { get; }

        public string Description { get; }

        public string LogoUrl { get; }

        public decimal Price { get; }

        public string Currency { get; }

        public TimeLengthMinutesOptionsEnum ServiceOptionTimeLength { get; }
    }
}
