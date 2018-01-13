using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.MVC.ViewModels
{
    public class CategoriaViewModel
    {
        public CategoriaViewModel()
        {
            this.DataCadastro = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o Campo Descrição")]
        [MinLength(4, ErrorMessage = "Campo deve ter no mínimo 4 caracteres")]
        [MaxLength(100, ErrorMessage = "Campo deve ter no máximo 100 caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }
    }
}
