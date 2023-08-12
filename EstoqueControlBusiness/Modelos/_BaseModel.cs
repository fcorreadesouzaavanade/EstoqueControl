using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueControlBusiness.Modelos
{
    public class _BaseModel
    {
        public _BaseModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public bool Ativo {get => DataRemocao != null; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime? DataRemocao { get; set; }

    }
}