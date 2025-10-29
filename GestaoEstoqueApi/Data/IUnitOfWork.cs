namespace GestaoEstoqueApi.Data
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}