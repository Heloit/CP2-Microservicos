using GestaoEstoqueApi.Data;
using GestaoEstoqueApi.Domain.Entities;
using GestaoEstoqueApi.DTOs;
using GestaoEstoqueApi.Exceptions;
using GestaoEstoqueApi.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoEstoqueApi.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoService(IProdutoRepository produtoRepository, IUnitOfWork unitOfWork)
        {
            _produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Produto> CadastrarProdutoAsync(ProdutoRequestDTO dto)
        {
            var produtoExistente = await _produtoRepository.GetBySkuAsync(dto.Sku);
            if (produtoExistente != null)
            {
                throw new RegraNegocioException($"SKU já cadastrado: {dto.Sku}");
            }

            var novoProduto = new Produto
            {
                Sku = dto.Sku,
                Nome = dto.Nome,
                Categoria = dto.Categoria,
                PrecoUnitario = dto.PrecoUnitario,
                QuantidadeMinima = dto.QuantidadeMinima
            };

            await _produtoRepository.AddAsync(novoProduto);
            await _unitOfWork.CommitAsync();

            return novoProduto;
        }

        public async Task<Produto> GetByIdAsync(Guid id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto == null)
            {
                throw new RecursoNaoEncontradoException($"Produto não encontrado. ID: {id}");
            }
            return produto;
        }

        public async Task<IEnumerable<Produto>> ListarTodosAsync()
        {
            return await _produtoRepository.GetAllAsync();
        }
    }
}