using SupermarketPrices.Domain.Commands;
using SupermarketPrices.Domain.Commands.Contracts;
using System.Threading.Tasks;

namespace SupermarketPrices.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        Task<GenericCommandResult> Handle(T command);
    }
}
