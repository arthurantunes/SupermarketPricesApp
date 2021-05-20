using SupermarketPrices.Domain.Commands;
using SupermarketPrices.Domain.Entities;
using SupermarketPrices.Domain.Handlers.Contracts;
using SupermarketPrices.Domain.Repositories;
using System.Threading.Tasks;

namespace SupermarketPrices.Domain.Handlers
{
    public class SupermarketProductHandler : IHandler<RegistrySupermarketProductCommand>, IHandler<UpdateProductPriceCommand>
    {
        private readonly ISupermarketProductRepository _repository;
        public SupermarketProductHandler(ISupermarketProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<GenericCommandResult> Handle(RegistrySupermarketProductCommand command)
        {
            var supermarketProduct = new SupermarketProduct(command.SupermarketId, command.ProductId, command.Date, command.Price);

            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, something looks wrong", command.Notifications);

            _repository.Create(supermarketProduct);

            return new GenericCommandResult(true, "Supermarket created!", supermarketProduct);
        }

        public async Task<GenericCommandResult> Handle(UpdateProductPriceCommand command)
        {
            var supermarketProduct = new SupermarketProduct(command.SupermarketId, command.ProductId, command.Date, command.Price);

            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, something looks wrong", command.Notifications);

            var productPrice = await _repository.GetByIds(command.SupermarketId, command.ProductId);

            if (productPrice != null)
            {
                var product = new SupermarketProduct(productPrice.SupermarketId, productPrice.ProductId, command.Date, command.Price);
                _repository.Update(product);

                return new GenericCommandResult(true, "Product Price updated!", product);
            }
            else
            {
                return new GenericCommandResult(false, "Ops, something looks wrong", "Product not found!");

            }

        }
    }
}
