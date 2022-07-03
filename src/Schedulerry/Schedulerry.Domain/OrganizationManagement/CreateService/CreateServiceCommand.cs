using Schedulerry.Common.Mediator.Contracs;
using System;

namespace Schedulerry.Domain.OrganizationManagement
{
    public class CreateServiceCommand : ICommand<CreateServiceDto>
    {
        public CreateServiceCommand(Guid organizationUid, string name, string description, string logoUrl)
        {
            OrganizationUid = organizationUid;
            Name = name;
            Description = description;
            LogoUrl = logoUrl;
        }

        public Guid OrganizationUid { get; }

        public string Name { get; }

        public string Description { get; }

        public string LogoUrl { get; }
    }
}
