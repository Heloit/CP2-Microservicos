using GestaoEstoqueApi.Domain.Entities;

namespace GestaoEstoqueApi.Repositories
{
    public interface IProdutoRepository
    {
        Task<Produto> AddAsync(Produto produto);
        Task<Produto?> GetByIdAsync(Guid id);
        Task<Produto?> GetBySkuAsync(string sku);
        Task<IEnumerable<Produto>> GetAllAsync();
        void Update(Produto produto); // O Update do EF é síncrono
        Task<IEnumerable<Produto>> GetProdutosAbaixoDoMinimoAsync();
    }
}