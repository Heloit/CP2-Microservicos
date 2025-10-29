using GestaoEstoqueApi.Data;
using GestaoEstoqueApi.Domain.Entities;
using GestaoEstoqueApi.Domain.Enums;
using GestaoEstoqueApi.DTOs;
using GestaoEstoqueApi.Exceptions;
using GestaoEstoqueApi.Repositories;
using System;
using System.Threading.Tasks;

namespace GestaoEstoqueApi.Services
{
    public class MovimentacaoService : IMovimentacaoService
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MovimentacaoService(IMovimentacaoRepository movimentacaoRepository, IProdutoRepository produtoRepository, IUnitOfWork unitOfWork)
        {
            _movimentacaoRepository = movimentacaoRepository;
            _produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<MovimentacaoEstoque> RegistrarEntradaAsync(MovimentacaoRequestDTO dto)
        {
            var produto = await _produtoRepository.GetByIdAsync(dto.ProdutoId)
                ?? throw new RecursoNaoEncontradoException($"Produto não encontrado. ID: {dto.ProdutoId}");

            if (produto.Categoria == Categoria.PERECIVEL)
            {
                if (string.IsNullOrWhiteSpace(dto.Lote))
                {
                    throw new RegraNegocioException("Lote é obrigatório para produtos perecíveis.");
                }
                if (!dto.DataValidade.HasValue)
                {
                    throw new RegraNegocioException("Data de validade é obrigatória para produtos perecíveis.");
                }
                if (dto.DataValidade.Value.Date < DateTime.UtcNow.Date)
                {
                    throw new RegraNegocioException("Não é permitido dar entrada em produtos vencidos.");
                }
            }

            produto.QuantidadeEmEstoque += dto.Quantidade;
            _produtoRepository.Update(produto);

            var mov = new MovimentacaoEstoque
            {
                ProdutoId = produto.Id,
                Tipo = TipoMovimentacao.ENTRADA,
                Quantidade = dto.Quantidade,
                Lote = dto.Lote,
                DataValidade = dto.DataValidade
            };

            await _movimentacaoRepository.AddAsync(mov);
            await _unitOfWork.CommitAsync();

            return mov;
        }

        public async Task<MovimentacaoEstoque> RegistrarSaidaAsync(MovimentacaoRequestDTO dto)
        {
            var produto = await _produtoRepository.GetByIdAsync(dto.ProdutoId)
                ?? throw new RecursoNaoEncontradoException($"Produto não encontrado. ID: {dto.ProdutoId}");

            if (produto.QuantidadeEmEstoque < dto.Quantidade)
            {
                throw new RegraNegocioException($"Estoque insuficiente. Saldo atual: {produto.QuantidadeEmEstoque}");
            }

            produto.QuantidadeEmEstoque -= dto.Quantidade;
            _produtoRepository.Update(produto);

            var mov = new MovimentacaoEstoque
            {
                ProdutoId = produto.Id,
                Tipo = TipoMovimentacao.SAIDA,
                Quantidade = dto.Quantidade
            };

            await _movimentacaoRepository.AddAsync(mov);
            await _unitOfWork.CommitAsync();

            return mov;
        }
    }
}