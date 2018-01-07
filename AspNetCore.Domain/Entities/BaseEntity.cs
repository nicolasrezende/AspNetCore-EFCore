using System;

namespace AspNetCore.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
