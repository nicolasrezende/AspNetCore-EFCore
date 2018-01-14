using AspNetCore.Domain.Entities;
using AspNetCore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCore.Data.Repositories
{
    public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
    {
        public override IEnumerable<Produto> GetAll()
        {
            return context.Produtos
                .Include(p => p.Categoria).ToList();
        }

        public override Produto GetById(int id)
        {
            return context.Produtos
                .Include(p => p.Categoria).FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Produto> PesquisarPorDescricao(string descricao)
        {
            return context.Produtos
                .Include(p => p.Categoria)
                .Where(p => EF.Functions.Like(p.Descricao, $"%{descricao}%")).ToList();
        }

        public IEnumerable<Produto> PesquisarPorDescricaoECategoria(string descricao, int categoria)
        {
            return context.Produtos
                .Include(p => p.Categoria)
                .Where(p => EF.Functions.Like(p.Descricao, $"%{descricao}%") && p.CategoriaId == categoria)
                .ToList();
        }
    }
}
