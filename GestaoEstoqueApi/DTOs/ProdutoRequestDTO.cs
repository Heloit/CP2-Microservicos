using GestaoEstoqueApi.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace GestaoEstoqueApi.DTOs
{
    public record ProdutoRequestDTO(
        [Required] string Sku,
        [Required] string Nome,
        [Required] Categoria Categoria,
        [Range(0.01, double.MaxValue)] decimal PrecoUnitario,
        [Range(0, int.MaxValue)] int QuantidadeMinima
    );
}