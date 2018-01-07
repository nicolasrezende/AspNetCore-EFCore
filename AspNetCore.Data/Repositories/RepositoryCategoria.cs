using AspNetCore.Domain.Entities;
using AspNetCore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCore.Data.Repositories
{
    public class RepositoryCategoria : RepositoryBase<Categoria>, IRepositoryCategoria
    {
        public IEnumerable<Categoria> ListarPorDescricao(string descricao)
        {
            return context.Categoria.Where(c => EF.Functions.Like(c.Descricao, $"%{descricao}%")).ToList();
        }
    }
}
