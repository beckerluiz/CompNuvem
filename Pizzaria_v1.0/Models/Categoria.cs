using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pizzaria_v1._0.Models
{
        [Table("Categorias")]
        public class Categoria
        {
            [Key]
            public int CategoriaId { get; set; }

            [Display(Name = "Nome da Categoria:")]
            [Required(ErrorMessage = "Campo Obrigatório!")]
            public string CategoriaNome { get; set; }

            [Display(Name = "Descrição da Categoria:")]
            [Required(ErrorMessage = "Campo Obrigatório!")]
            public string CategoriaDescricao { get; set; }

            public List<Pedido> Pedidos { get; set; }
        }
}