using Flunt.Validations;

namespace SupermarketPrices.Domain.Commands.Contracts
{
    public class UpdateProductPriceContract : Contract<UpdateProductPriceCommand>
    {
        public UpdateProductPriceContract(UpdateProductPriceCommand updateProductPriceCommand)
        {
            Requires()
            .IsGreaterThan(updateProductPriceCommand.SupermarketId, 0, "SupermarketId")
            .IsGreaterThan(updateProductPriceCommand.ProductId, 0, "ProductId")
            .IsGreaterThan(updateProductPriceCommand.Price, 0, "Price");
        }
    }
}
