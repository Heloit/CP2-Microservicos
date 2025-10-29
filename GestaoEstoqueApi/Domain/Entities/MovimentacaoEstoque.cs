using GestaoEstoqueApi.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoEstoqueApi.Domain.Entities
{
    public class MovimentacaoEstoque
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }


        [Required]
        public Guid ProdutoId { get; set; } 

        public Produto Produto { get; set; }


        [Required]
        public TipoMovimentacao Tipo { get; set; } 

        [Required]
        public int Quantidade { get; set; }

        public DateTime DataMovimentacao { get; set; } = DateTime.UtcNow;

        public string? Lote { get; set; }
        public DateTime? DataValidade { get; set; }
    }
}