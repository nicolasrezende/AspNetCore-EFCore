using AspNetCore.Domain.Entities;
using AspNetCore.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCore.Data.Repositories
{
    public class RepositoryCategoria : RepositoryBase<Categoria>, IRepositoryCategoria
    {
        public IEnumerable<Categoria> ListarPorDescricao(string descricao)
        {
            return context.Categoria.Where(c => c.Descricao == descricao).ToList();
        }
    }
}
