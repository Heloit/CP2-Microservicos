using GestaoEstoqueApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestaoEstoqueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService;

        public RelatoriosController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        [HttpGet("valor-total-estoque")]
        public async Task<IActionResult> GetValorTotal()
        {
            var valor = await _relatorioService.CalcularValorTotalEstoqueAsync();
            return Ok(new { valorTotal = valor });
        }

        [HttpGet("produtos/vencendo")]
        public async Task<IActionResult> GetProdutosVencendo()
        {
            var itens = await _relatorioService.ListarProdutosVencendoSeteDiasAsync();
            return Ok(itens);
        }

        [HttpGet("produtos/estoque-minimo")]
        public async Task<IActionResult> GetProdutosAbaixoMinimo()
        {
            var produtos = await _relatorioService.ListarProdutosAbaixoMinimoAsync();
            return Ok(produtos);
        }
    }
}