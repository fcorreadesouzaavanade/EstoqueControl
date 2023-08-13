
using AutoMapper;
using EstoqueControlApp.DTO;
using EstoqueControlBusiness.Modelos;

namespace EstoqueControlApp.AutoMapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
            CreateMap<FornecedorDTO, FornecedorDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}