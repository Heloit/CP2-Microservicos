using GestaoEstoqueApi.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoEstoqueApi.Domain.Entities
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Sku { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public Categoria Categoria { get; set; } 

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoUnitario { get; set; }

        [Required]
        public int QuantidadeMinima { get; set; }

        public int QuantidadeEmEstoque { get; set; } = 0;

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}