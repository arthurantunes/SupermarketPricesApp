using SupermarketPrices.Domain.Commands;
using SupermarketPrices.Domain.Entities;
using SupermarketPrices.Domain.Handlers.Contracts;
using SupermarketPrices.Domain.Repositories;
using System.Threading.Tasks;

namespace SupermarketPrices.Domain.Handlers
{
    public class ProductHandler : IHandler<CreateProductCommand>, IHandler<DeleteProductCommand>, IHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _repository;
        public ProductHandler(IProductRepository productRepository)
        {
            _repository = productRepository;
        }
        public async Task<GenericCommandResult> Handle(CreateProductCommand command)
        {
            var product = new Product(command.Name, command.Description, command.EAN, command.SKU, command.Brand);
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, something looks wrong", command.Notifications);

            _repository.Create(product);

            return new GenericCommandResult(true, "Product created!", product);
        }

        public async Task<GenericCommandResult> Handle(DeleteProductCommand command)
        {
            var product = await _repository.GetById(command.Id);

            if (product != null)
            {
                _repository.Delete(product);

                return new GenericCommandResult(true, "Product deleted!", product);
            }
            else
            {
                return new GenericCommandResult(false, "Ops, something looks wrong", "Product not found!");

            }

        }

        public async Task<GenericCommandResult> Handle(UpdateProductCommand command)
        {
            var product = await _repository.GetById(command.Id);

            if (product != null)
            {
                _repository.Update(product);

                return new GenericCommandResult(true, "Product updated!", product);
            }
            else
            {
                return new GenericCommandResult(false, "Ops, something looks wrong", "Product not found!");

            }

        }
    }
}
