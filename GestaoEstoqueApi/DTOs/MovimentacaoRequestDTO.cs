using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoEstoqueApi.DTOs
{
    public record MovimentacaoRequestDTO(
        [Required] Guid ProdutoId,
        [Range(1, int.MaxValue)] int Quantidade,
        string? Lote,
        DateTime? DataValidade
    );
}