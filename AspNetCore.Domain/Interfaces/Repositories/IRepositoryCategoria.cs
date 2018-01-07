using AspNetCore.Domain.Entities;
using System.Collections.Generic;

namespace AspNetCore.Domain.Interfaces.Repositories
{
    public interface IRepositoryCategoria : IRepositoryBase<Categoria>
    {
        IEnumerable<Categoria> ListarPorDescricao(string descricao);
    }
}
