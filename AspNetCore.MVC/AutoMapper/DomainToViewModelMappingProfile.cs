using AspNetCore.Domain.Entities;
using AspNetCore.MVC.ViewModels;
using AutoMapper;

namespace AspNetCore.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<CategoriaViewModel, Categoria>();
        }
    }
}
