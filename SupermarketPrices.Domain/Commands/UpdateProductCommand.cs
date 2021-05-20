using Flunt.Notifications;
using SupermarketPrices.Domain.Commands.Contracts;

namespace SupermarketPrices.Domain.Commands
{
    public class UpdateProductCommand : Notifiable<Notification>, ICommand
    {
        public UpdateProductCommand(int id, string name, string description, string eAN, string sKU, string brand)
        {
            Name = name;
            Description = description;
            EAN = eAN;
            SKU = sKU;
            Brand = brand;
            Id = id;

            Validate();
        }

        public void Validate()
        {
            AddNotifications(new UpdateProductContract(this));
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EAN { get; set; }
        public string SKU { get; set; }
        public string Brand { get; set; }

    }
}
