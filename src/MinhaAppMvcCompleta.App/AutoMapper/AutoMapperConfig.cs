using AutoMapper;
using MinhaAppMvcCompleta.App.ViewModels;
using MinhaAppMvcCompleta.Business.Models;

namespace MinhaAppMvcCompleta.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}
