using Schedulerry.Common.DateAndTime;
using System;
using System.Collections.Generic;

namespace Schedulerry.Domain.OrganizationManagement
{
    public class CreateServiceOptionDto
    {
        public CreateServiceOptionDto(
            Guid uid,
            Guid serviceUid,
            string name,
            string description,
            string imageUrl,
            decimal price,
            string currency,
            TimeLengthMinutesOptionsEnum serviceOptionTimeLength,
            IEnumerable<CreateServiceOptionWorkingTimeDto> serviceOptionWorkingTime)
        {
            Uid = uid;
            ServiceUid = serviceUid;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            Price = price;
            Currency = currency;
            ServiceOptionTimeLength = serviceOptionTimeLength;
            ServiceOptionWorkingTime = serviceOptionWorkingTime;
        }

        public Guid Uid { get; }
        public Guid ServiceUid { get; }
        public string Name { get; }
        public string Description { get; }
        public string ImageUrl { get; }
        public decimal Price { get; }
        public string Currency { get; }
        public TimeLengthMinutesOptionsEnum ServiceOptionTimeLength { get; }
        public IEnumerable<CreateServiceOptionWorkingTimeDto> ServiceOptionWorkingTime { get; }
    }
}
