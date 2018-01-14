using AspNetCore.Domain.Entities;
using AspNetCore.MVC.ViewModels;
using AutoMapper;

namespace AspNetCore.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Categoria, CategoriaViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
        }
    }
}
