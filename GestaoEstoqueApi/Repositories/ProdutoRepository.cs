using GestaoEstoqueApi.Data;
using GestaoEstoqueApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoEstoqueApi.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> AddAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            return produto;
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<Produto?> GetByIdAsync(Guid id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<Produto?> GetBySkuAsync(string sku)
        {
            return await _context.Produtos
                .FirstOrDefaultAsync(p => p.Sku == sku);
        }

        public async Task<IEnumerable<Produto>> GetProdutosAbaixoDoMinimoAsync()
        {
            return await _context.Produtos
                .Where(p => p.QuantidadeEmEstoque < p.QuantidadeMinima)
                .AsNoTracking()
                .ToListAsync();
        }

        public void Update(Produto produto)
        {
            _context.Produtos.Update(produto);
        }
    }
}