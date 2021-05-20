using Flunt.Notifications;
using SupermarketPrices.Domain.Commands.Contracts;

namespace SupermarketPrices.Domain.Commands
{
    public class CreateProductCommand : Notifiable<Notification>, ICommand
    {
        public CreateProductCommand(string name, string description, string eAN, string sKU, string brand)
        {
            Name = name;
            Description = description;
            EAN = eAN;
            SKU = sKU;
            Brand = brand;

            Validate();
        }

        public void Validate()
        {
            AddNotifications(new CreateProductContract(this));
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string EAN { get; set; }
        public string SKU { get; set; }
        public string Brand { get; set; }

    }
}
