using AspNetCore.Domain.Entities;
using AspNetCore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCore.Data.Repositories
{
    public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
    {
        public IEnumerable<Produto> PesquisarPorCategoria(string categoria)
        {
            return context.Produtos
                .Include(p => p.Categoria)
                .Where(p => p.Categoria.Descricao == categoria);
        }

        public IEnumerable<Produto> PesquisarPorDescricao(string descricao)
        {
            return context.Produtos.Where(p => p.Descricao == descricao).ToList();
        }
    }
}
