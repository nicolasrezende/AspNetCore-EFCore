using AspNetCore.Data.Context;
using AspNetCore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCore.Data.Data
{
    public static class DbInitializer
    {
        public static void Initialize()
        {
            using (var context = new AspNetCoreContext())
            {
                context.Database.EnsureCreated();
                if (context.Produtos.Any()) return;

                var categorias = new List<Categoria>
                {
                    new Categoria("Smartphones"),
                    new Categoria("Relógios"),
                    new Categoria("Livros")
                };

                categorias.ForEach(c => context.Categoria.Add(c));
                context.SaveChanges();

                var produtos = new List<Produto>
                {
                    new Produto("Galaxy S8", 3000m, 1),
                    new Produto("Zenfone 4", 2000m, 1),
                    new Produto("Moto G5 Plus", 1199.99m, 1),
                    new Produto("Mi Band", 99.99m, 2),
                    new Produto("Mi Band 2", 149.99m, 2),
                    new Produto("Scrum - A Arte de Faze o Dobro de Trabalho na Metade do Tempo", 28.90m, 3),
                    new Produto("Domain Driven Design", 99.90m, 3),
                    new Produto("Código Limpo - Habilidades Práticas Do Agile Software", 99.90m, 3)
                };

                produtos.ForEach(p => context.Produtos.Add(p));
                context.SaveChanges();
            }
        }
    }
}
