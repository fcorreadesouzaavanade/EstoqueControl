
using AutoMapper;
using EstoqueControlApp.Dto;
using EstoqueControlBusiness.Modelos;

namespace EstoqueControlApp.AutoMapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Endereco, EnderecoDto>().ReverseMap();
            CreateMap<Fornecedor, FornecedorDto>().ReverseMap();
            CreateMap<Produto, ProdutoDto>().ReverseMap();
        }
    }
}