using GestaoEstoqueApi.Domain.Entities;
using GestaoEstoqueApi.DTOs;
using System.Threading.Tasks;

namespace GestaoEstoqueApi.Services
{
    public interface IMovimentacaoService
    {
        Task<MovimentacaoEstoque> RegistrarEntradaAsync(MovimentacaoRequestDTO dto);
        Task<MovimentacaoEstoque> RegistrarSaidaAsync(MovimentacaoRequestDTO dto);
    }
}