using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Domain.Entities
{
    public class Categoria : BaseEntity
    {
        [Required]
        public string Descricao { get; set; }
        public ICollection<Produto> Produtos { get; set; }

        public Categoria()
        {
            this.DataCadastro = DateTime.Today;
        }

        public Categoria(string descricao)
        {
            this.Descricao = descricao;
            this.DataCadastro = DateTime.Today;
        }
    }
}
