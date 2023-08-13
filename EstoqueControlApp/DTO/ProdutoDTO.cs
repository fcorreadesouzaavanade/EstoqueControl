namespace EstoqueControlApp.DTO
{
    public class ProdutoDTO
    {
        public Guid Id {get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public Guid FornecedorId { get; set; }

        public FornecedorDTO Fornecedor { get; set; }
    }
}