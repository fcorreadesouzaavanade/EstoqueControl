namespace EstoqueControlApp.DTO
{
    public class FornecedorDTO
    {
        public Guid Id {get; set; }
        public string Nome { get; set; }
        public string Contato { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Guid EnderecoId { get; set; }

         public IEnumerable<ProdutoDTO> Produtos { get; set; }
         public EnderecoDTO Endereco{ get; set; }
    }
}