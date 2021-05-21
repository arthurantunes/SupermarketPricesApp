using Flunt.Notifications;
using SupermarketPrices.Domain.Commands.Contracts;
using System;

namespace SupermarketPrices.Domain.Commands
{
    public class RegistrySupermarketProductCommand : Notifiable<Notification>, ICommand
    {

        public RegistrySupermarketProductCommand(int supermarketId, int productId,  decimal price)
        {
            SupermarketId = supermarketId;
            ProductId = productId;
            Date = DateTime.Now;
            Price = price;

        }

        public int SupermarketId { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }

        public void Validate()
        {
            AddNotifications(new RegistrySupermarketProductContract(this));
        }
    }
}
