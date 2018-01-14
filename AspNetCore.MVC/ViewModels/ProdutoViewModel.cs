using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AspNetCore.MVC.ViewModels
{
    [DataContract]
    public class ProdutoViewModel
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Descrição é obrigatório")]
        [MinLength(4, ErrorMessage = "Campo deve ter no mínimo 4 caracteres")]
        [MaxLength(100, ErrorMessage = "Campo deve ter no máximo 100 caracteres")]
        [DisplayName("Descrição")]
        [DataMember]
        public string Descricao { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Preencha um valor")]
        [Range(typeof(decimal), "0", "99999999999", ErrorMessage = "Preço inválido")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DisplayName("Preço Unitário")]
        [DataMember]
        public decimal PrecoUnitario { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Categoria")]
        [DataMember]
        public int CategoriaId { get; set; }

        [DataMember]
        public CategoriaViewModel Categoria { get; set; }
    }
}
