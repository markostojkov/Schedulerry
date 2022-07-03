using System.Collections.Generic;

namespace Schedulerry.Persistence.Entities
{
    public class Service : BaseEntity
    {
        public Service(string name, string description = "", string imageUrl = "") : base()
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            ServiceOptions = new List<ServiceOption>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public long OrganizationFk { get; set; }

        public Organization Organization { get; set; }

        public virtual List<ServiceOption> ServiceOptions { get; set; }
    }
}
