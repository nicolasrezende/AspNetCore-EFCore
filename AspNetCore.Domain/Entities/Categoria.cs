using System;
using System.Collections.Generic;

namespace AspNetCore.Domain.Entities
{
    public class Categoria : BaseEntity
    {
        public string Descricao { get; set; }
        public ICollection<Produto> Produtos { get; set; }

        public Categoria()
        {
            this.DataCadastro = DateTime.Now;
        }

        public Categoria(string descricao)
        {
            this.Descricao = descricao;
            this.DataCadastro = DateTime.Now;
        }
    }
}
