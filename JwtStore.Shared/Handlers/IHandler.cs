using JwtStore.Shared.Commands;

namespace JwtStore.Shared.Handlers;

public interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}