using GestaoEstoqueApi.Data;
using GestaoEstoqueApi.Domain.Entities;
using GestaoEstoqueApi.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoEstoqueApi.Repositories
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly AppDbContext _context;

        public MovimentacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<MovimentacaoEstoque> AddAsync(MovimentacaoEstoque movimentacao)
        {
            await _context.MovimentacoesEstoque.AddAsync(movimentacao);
            return movimentacao;
        }

        public async Task<IEnumerable<MovimentacaoEstoque>> GetMovimentacoesVencendoAsync(TipoMovimentacao tipo, DateTime inicio, DateTime fim)
        {
            var dataInicio = inicio.Date;
            var dataFim = fim.Date;

            return await _context.MovimentacoesEstoque
                .Where(m => m.Tipo == tipo &&
                            m.DataValidade.HasValue &&
                            m.DataValidade.Value.Date >= dataInicio &&
                            m.DataValidade.Value.Date <= dataFim)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}