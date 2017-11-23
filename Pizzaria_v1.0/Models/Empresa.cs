using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pizzaria_v1._0.Models
{
    [Table("Empresas")]
    public class Empresa
    {
        [Key]
        public int EmpresaId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MinLength(3, ErrorMessage = "No mínimo 8 caracteres!")]
        [MaxLength(50, ErrorMessage = "No máximo 15 caracteres!")]
        [Display(Name = "Login:")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MinLength(3, ErrorMessage = "No mínimo 8 caracteres!")]
        [MaxLength(50, ErrorMessage = "No máximo 15 caracteres!")]
        [Display(Name = "Senha:")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MinLength(3, ErrorMessage = "No mínimo 3 caracteres!")]
        [MaxLength(50, ErrorMessage = "No máximo 50 caracteres!")]
        [Display(Name = "Nome da Empresa:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MinLength(3, ErrorMessage = "No mínimo 3 caracteres!")]
        [MaxLength(50, ErrorMessage = "No máximo 50 caracteres!")]
        [Display(Name = "CNPJ:")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MinLength(3, ErrorMessage = "No mínimo 3 caracteres!")]
        [MaxLength(50, ErrorMessage = "No máximo 50 caracteres!")]
        [Display(Name = "Endereço:")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MinLength(3, ErrorMessage = "No mínimo 8 caracteres!")]
        [MaxLength(50, ErrorMessage = "No máximo 15 caracteres!")]
        [Display(Name = "Telefone:")]
        public string Telefone { get; set; }
    }
}