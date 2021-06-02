using AutoMapper;
using MVCFornecedores.Data.Entities;
using MVCFornecedores.ViewModels;

namespace MVCFornecedores.Data
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            CreateMap<Empresa, EmpresaViewModel>()
              //.ForMember(o => o.OrderId, ex => ex.MapFrom(i => i.Id))
              .ReverseMap();

            CreateMap<Fornecedor, FornecedoresViewModel>()
              .ForMember(o => o.Id_Fornecedor, ex => ex.MapFrom(i => i.Id))
              .ForMember(o => o.Id_Empresa, ex => ex.MapFrom(i => i.Empresa.Id))
              .ReverseMap();
        }
    }
}
