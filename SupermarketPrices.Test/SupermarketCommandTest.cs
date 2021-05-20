using SupermarketPrices.Domain.Commands;
using Xunit;

namespace SupermarketPrices.Test
{
    public class SupermarketCommandTest
    {
        private readonly CreateSupermarketCommand _invalidCommand = new CreateSupermarketCommand("");
        private readonly CreateSupermarketCommand _validCommand = new CreateSupermarketCommand("Walmart");


        [Fact]
        public void ValidSupermarketName()
        {
            Assert.True(_validCommand.IsValid);
        }
        [Fact]
        public void InvalidSupermarketName()
        {
            Assert.False(_invalidCommand.IsValid);
        }
    }
}

