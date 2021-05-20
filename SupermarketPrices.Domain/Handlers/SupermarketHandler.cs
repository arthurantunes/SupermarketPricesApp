using SupermarketPrices.Domain.Commands;
using SupermarketPrices.Domain.Entities;
using SupermarketPrices.Domain.Handlers.Contracts;
using SupermarketPrices.Domain.Repositories;
using System.Threading.Tasks;

namespace SupermarketPrices.Domain.Handlers
{
    public class SupermarketHandler : IHandler<CreateSupermarketCommand>
    {
        private readonly ISupermarketRepository _repository;
        public SupermarketHandler(ISupermarketRepository supermarketRepository)
        {
            _repository = supermarketRepository;
        }

        public async Task<GenericCommandResult> Handle(CreateSupermarketCommand command)
        {
            var supermarket = new Supermarket(command.Name);
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, something looks wrong", command.Notifications);

            _repository.Create(supermarket);

            return new GenericCommandResult(true, "Supermarket created!", supermarket);
        }
    }
}
