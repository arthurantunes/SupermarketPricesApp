using Flunt.Validations;

namespace SupermarketPrices.Domain.Commands.Contracts
{
    public class CreateProductContract : Contract<CreateProductCommand>
    {
        public CreateProductContract(CreateProductCommand productCommand)
        {
            Requires()
            .IsNotNullOrEmpty(productCommand.Name, "Name")
            .IsNotNullOrEmpty(productCommand.Brand, "Brand")
            .IsNotNullOrEmpty(productCommand.Description, "Description");
        }
    }
}
