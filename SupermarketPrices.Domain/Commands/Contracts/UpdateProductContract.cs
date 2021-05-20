using Flunt.Validations;

namespace SupermarketPrices.Domain.Commands.Contracts
{
    public class UpdateProductContract : Contract<UpdateProductCommand>
    {
        public UpdateProductContract(UpdateProductCommand productCommand)
        {
            Requires()
                .IsGreaterThan(productCommand.Id, 0, "Id")
                .IsNotNullOrEmpty(productCommand.Name, "Name")
                .IsNotNullOrEmpty(productCommand.Brand, "Brand")
                .IsNotNullOrEmpty(productCommand.Description, "Description");
        }
    }
}
