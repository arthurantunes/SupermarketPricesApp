using Flunt.Notifications;
using SupermarketPrices.Domain.Commands.Contracts;

namespace SupermarketPrices.Domain.Commands
{
    public class CreateSupermarketCommand : Notifiable<Notification>, ICommand
    {
        public CreateSupermarketCommand(string name)
        {
            Name = name;
            Validate();
        }

        public void Validate()
        {
            AddNotifications(new CreateSupermarketContract(this));
        }


        public string Name { get; set; }


    }
}
