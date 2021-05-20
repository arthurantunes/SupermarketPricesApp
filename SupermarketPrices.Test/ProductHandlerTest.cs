using SupermarketPrices.Domain.Commands;
using SupermarketPrices.Domain.Handlers;
using System.Linq;
using Xunit;

namespace SupermarketPrices.Test
{
    public class ProductHandlerTest
    {
        private readonly CreateProductCommand _validCommand = new CreateProductCommand("Notebook Asus x240", "The best notebook", "axc1234", "1213123", "Asus");
        private readonly CreateProductCommand _invalidCommand = new CreateProductCommand("Notebook Asus x240", "The best notebook", "axc1234", "1213123", "Asus");
        private readonly ProductHandler _handler = new ProductHandler(new ProductFakeRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        [Fact]
        public async void ValidProductHandler()
        {
            _result = await _handler.Handle(_validCommand);
            Assert.True(_result.Success);
        }
        [Fact]
        public async void InvalidProductHandler()
        {
            _result = await _handler.Handle(_invalidCommand);
            Assert.False(_result.Success); ;
        }

        [Fact]
        public void ValidProducts()
        {
            Assert.True(new ProductFakeRepository().GetAll().ToList().Count > 0);
        }
    }
}

