using System;

namespace AspNetCore.Domain.Entities
{
    public class Produto : BaseEntity
    {
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public Produto()
        {
            this.DataCadastro = DateTime.Now;
        }

        public Produto(string descricao, decimal precoUnitario, int categoriaId)
        {
            this.Descricao = descricao;
            this.PrecoUnitario = precoUnitario;
            this.CategoriaId = categoriaId;
            this.DataCadastro = DateTime.Now;
        }
    }
}
