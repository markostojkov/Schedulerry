using Schedulerry.Common.Dtos;
using Schedulerry.Common.Mediator.Contracs;

namespace Schedulerry.Domain.Users.Customer
{
    public class CreateCustomerCommand : ICommand<CreatedEntity>
    {
        public CreateCustomerCommand(string customerUsername, string customerEmail, string customerPassword)
        {
            CustomerUsername = customerUsername;
            CustomerEmail = customerEmail;
            CustomerPassword = customerPassword;
        }

        public string CustomerUsername { get; }
        public string CustomerEmail { get; }
        public string CustomerPassword { get; }
    }
}
