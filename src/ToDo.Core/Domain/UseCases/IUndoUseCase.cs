namespace ToDo.Core.Domain.UseCases
{
    public interface IUndoUseCase
    {
        void Execute(string id);
    }
}
