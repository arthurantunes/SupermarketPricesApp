using Flunt.Notifications;
using SupermarketPrices.Domain.Commands.Contracts;
using System;

namespace SupermarketPrices.Domain.Commands
{
    public class UpdateProductPriceCommand : Notifiable<Notification>, ICommand
    {
        public UpdateProductPriceCommand(int supermarketId, int productId, DateTime date, decimal price)
        {
            SupermarketId = supermarketId;
            ProductId = productId;
            Date = date;
            Price = price;

            Validate();
        }

        public void Validate()
        {
            AddNotifications(new UpdateProductPriceContract(this));
        }

        public int SupermarketId { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }

    }
}

