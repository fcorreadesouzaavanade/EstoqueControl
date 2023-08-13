using EstoqueControlBusiness.Interfaces.Repository;
using EstoqueControlBusiness.Modelos;
using EstoqueControlData.Context;

namespace EstoqueControlData.Repository
{
    public class EnderecoRepository :  GenericRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(EstoqueControlDbContext context) : base(context) { }
    }
}