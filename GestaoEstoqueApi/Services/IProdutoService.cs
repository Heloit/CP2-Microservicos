using GestaoEstoqueApi.Domain.Entities;
using GestaoEstoqueApi.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoEstoqueApi.Services
{
    public interface IProdutoService
    {
        Task<Produto> CadastrarProdutoAsync(ProdutoRequestDTO dto);
        Task<Produto> GetByIdAsync(Guid id);
        Task<IEnumerable<Produto>> ListarTodosAsync();
    }
}