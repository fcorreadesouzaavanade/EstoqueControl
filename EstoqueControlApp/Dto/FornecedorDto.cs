namespace EstoqueControlApp.Dto
{
    public class FornecedorDto
    {
        public Guid Id {get; set; }
        public string Nome { get; set; }
        public string Contato { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Guid EnderecoId { get; set; }

         public IEnumerable<ProdutoDto> Produtos { get; set; }
         public EnderecoDto Endereco{ get; set; }
    }
}