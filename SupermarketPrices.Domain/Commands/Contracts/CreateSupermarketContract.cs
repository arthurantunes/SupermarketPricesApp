using Flunt.Validations;

namespace SupermarketPrices.Domain.Commands.Contracts
{
    public class CreateSupermarketContract : Contract<CreateSupermarketCommand>
    {
        public CreateSupermarketContract(CreateSupermarketCommand supermarket)
        {
            Requires()
            .IsNotNullOrEmpty(supermarket.Name, "Name");
        }
    }
}
