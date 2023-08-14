namespace EstoqueControlBusiness.Modelos
{
    public class _BaseModel
    {
        public _BaseModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataAtualizacao { get; set; }

    }
}