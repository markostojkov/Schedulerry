using System;

namespace Schedulerry.Domain.OrganizationManagement
{
    public class CreateServiceDto
    {
        public CreateServiceDto(Guid uid, string name, string description, string imageUrl)
        {
            Uid = uid;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
        }

        public Guid Uid { get; }
        public string Name { get; }
        public string Description { get; }
        public string ImageUrl { get; }
    }
}
