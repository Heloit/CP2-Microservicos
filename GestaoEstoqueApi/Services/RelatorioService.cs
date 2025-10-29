using GestaoEstoqueApi.Domain.Entities;
using GestaoEstoqueApi.Domain.Enums;
using GestaoEstoqueApi.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoEstoqueApi.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public RelatorioService(IProdutoRepository produtoRepository, IMovimentacaoRepository movimentacaoRepository)
        {
            _produtoRepository = produtoRepository;
            _movimentacaoRepository = movimentacaoRepository;
        }

        public async Task<decimal> CalcularValorTotalEstoqueAsync()
        {
            var produtos = await _produtoRepository.GetAllAsync();
            return produtos.Sum(p => p.PrecoUnitario * p.QuantidadeEmEstoque);
        }

        public async Task<IEnumerable<Produto>> ListarProdutosAbaixoMinimoAsync()
        {
            return await _produtoRepository.GetProdutosAbaixoDoMinimoAsync();
        }

        public async Task<IEnumerable<MovimentacaoEstoque>> ListarProdutosVencendoSeteDiasAsync()
        {
            var hoje = DateTime.UtcNow;
            var seteDias = hoje.AddDays(7);

            return await _movimentacaoRepository.GetMovimentacoesVencendoAsync(
                TipoMovimentacao.ENTRADA,
                hoje,
                seteDias);
        }
    }
}