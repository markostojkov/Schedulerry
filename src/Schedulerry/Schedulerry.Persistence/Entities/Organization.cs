using System.Collections.Generic;

namespace Schedulerry.Persistence.Entities
{
    public class Organization : BaseEntity
    {
        public Organization()
        {
            Organizers = new List<Organizer>();
            Services = new List<Service>();
            IsVerified = false;
        }

        public Organization(string name)
        {
            Name = name;
            Organizers = new List<Organizer>();
            Services = new List<Service>();
            IsVerified = false;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsVerified { get; set; }

        public virtual List<Organizer> Organizers { get; }

        public virtual List<Service> Services { get; }
    }
}
