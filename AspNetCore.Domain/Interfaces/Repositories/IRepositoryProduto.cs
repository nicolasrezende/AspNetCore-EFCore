using AspNetCore.Domain.Entities;
using System.Collections.Generic;

namespace AspNetCore.Domain.Interfaces.Repositories
{
    public interface IRepositoryProduto : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> PesquisarPorDescricao(string descricao);
        IEnumerable<Produto> PesquisarPorDescricaoECategoria(string descricao, int categoria);
    }
}
