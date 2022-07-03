using Schedulerry.Common.DateAndTime;
using System.Collections.Generic;

namespace Schedulerry.Persistence.Entities
{
    public class ServiceOption : BaseEntity
    {
        public ServiceOption(
            string name,
            string description,
            string imageUrl,
            decimal price,
            string currency,
            TimeLengthMinutesOptionsEnum timeLength,
            List<ServiceOptionSchedule> serviceOptionSchedules) : base()
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            Price = price;
            Currency = currency;
            ServiceOptionTimeLength = timeLength;
            ServiceOptionSchedules = serviceOptionSchedules;
        }

        public ServiceOption()
        {

        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public long ServiceFk { get; set; }

        public decimal Price { get; set; }

        public string Currency { get; set; }

        public TimeLengthMinutesOptionsEnum ServiceOptionTimeLength { get; set; }

        public virtual List<ServiceOptionSchedule> ServiceOptionSchedules { get; set; }

        public virtual List<Reservation> Reservations { get; set; }

        public Service Service { get; set; }
    }
}
