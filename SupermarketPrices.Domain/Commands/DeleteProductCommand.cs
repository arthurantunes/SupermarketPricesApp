using SupermarketPrices.Domain.Commands.Contracts;

namespace SupermarketPrices.Domain.Commands
{
    public class DeleteProductCommand : ICommand
    {
        public DeleteProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

        public void Validate()
        {

        }
    }
}
