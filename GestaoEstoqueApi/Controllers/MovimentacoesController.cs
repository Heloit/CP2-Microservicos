using GestaoEstoqueApi.DTOs;
using GestaoEstoqueApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestaoEstoqueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentacoesController : ControllerBase
    {
        private readonly IMovimentacaoService _movimentacaoService;

        public MovimentacoesController(IMovimentacaoService movimentacaoService)
        {
            _movimentacaoService = movimentacaoService;
        }

        [HttpPost("entrada")]
        public async Task<IActionResult> RegistrarEntrada([FromBody] MovimentacaoRequestDTO dto)
        {
            var mov = await _movimentacaoService.RegistrarEntradaAsync(dto);
            return Ok(mov);
        }

        [HttpPost("saida")]
        public async Task<IActionResult> RegistrarSaida([FromBody] MovimentacaoRequestDTO dto)
        {
            var mov = await _movimentacaoService.RegistrarSaidaAsync(dto);
            return Ok(mov);
        }
    }
}