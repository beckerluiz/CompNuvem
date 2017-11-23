using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzaria_v1._0.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }
        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; } //asp:DropDownList

        [Display(Name = "Sabor:")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Sabor { get; set; }

        [Display(Name = "Descrição:")]
        [MaxLength(2000, ErrorMessage = "No máximo 2000 caracteres!")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [ForeignKey("Empresa")]
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; } //asp:DropDownList
    }
}