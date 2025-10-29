using GestaoEstoqueApi.Domain.Entities;
using GestaoEstoqueApi.Domain.Enums;

namespace GestaoEstoqueApi.Repositories
{
    public interface IMovimentacaoRepository
    {
        Task<MovimentacaoEstoque> AddAsync(MovimentacaoEstoque movimentacao);
        Task<IEnumerable<MovimentacaoEstoque>> GetMovimentacoesVencendoAsync(TipoMovimentacao tipo, DateTime inicio, DateTime fim);
    }
}