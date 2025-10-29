using GestaoEstoqueApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoEstoqueApi.Services
{
    public interface IRelatorioService
    {
        Task<decimal> CalcularValorTotalEstoqueAsync();
        Task<IEnumerable<MovimentacaoEstoque>> ListarProdutosVencendoSeteDiasAsync();
        Task<IEnumerable<Produto>> ListarProdutosAbaixoMinimoAsync();
    }
}