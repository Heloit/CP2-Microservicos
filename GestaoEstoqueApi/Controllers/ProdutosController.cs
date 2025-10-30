using GestaoEstoqueApi.DTOs;
using GestaoEstoqueApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GestaoEstoqueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] ProdutoRequestDTO dto)
        {
            var produto = await _produtoService.CadastrarProdutoAsync(dto);
            return CreatedAtAction(nameof(BuscarPorId), new { id = produto.Id }, produto);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var produtos = await _produtoService.ListarTodosAsync();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            var produto = await _produtoService.GetByIdAsync(id);
            return Ok(produto);
        }
    }
}