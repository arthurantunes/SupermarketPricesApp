using Flunt.Validations;

namespace SupermarketPrices.Domain.Commands.Contracts
{
    public class RegistrySupermarketProductContract : Contract<RegistrySupermarketProductCommand>
    {
        public RegistrySupermarketProductContract(RegistrySupermarketProductCommand registrySupermarket)
        {
            Requires()
            .IsGreaterThan(registrySupermarket.SupermarketId, 0, "SupermarketId")
            .IsGreaterThan(registrySupermarket.ProductId, 0, "ProductId")
            .IsGreaterThan(registrySupermarket.Price, 0, "Price");


        }
    }
}
