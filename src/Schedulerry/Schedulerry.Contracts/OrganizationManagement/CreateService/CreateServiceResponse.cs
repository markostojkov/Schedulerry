using System;

namespace Schedulerry.Contracts.OrganizationManagement
{
    public class CreateServiceResponse
    {
        public CreateServiceResponse(Guid uid, Guid organizationUid, string name, string description, string imageUrl)
        {
            Uid = uid;
            OrganizationUid = organizationUid;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
        }

        public Guid Uid { get; }

        public Guid OrganizationUid { get; }

        public string Name { get; }

        public string Description { get; }

        public string ImageUrl { get; }
    }
}
