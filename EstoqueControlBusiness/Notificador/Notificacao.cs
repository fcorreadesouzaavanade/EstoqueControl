using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueControlBusiness.Notificador
{
    public class Notificacao
    {
        public string Mensagem { get; }

        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}