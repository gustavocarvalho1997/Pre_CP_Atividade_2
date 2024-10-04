using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Produto.Domain.Entities
{
    [Table("tb_prod_categoria")]
    public class CategoriaEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descriao { get; set; } = string.Empty;
    }
}
