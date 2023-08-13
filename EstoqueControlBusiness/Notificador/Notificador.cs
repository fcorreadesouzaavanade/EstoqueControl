using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueControlBusiness.Interfaces.Notificador;

namespace EstoqueControlBusiness.Notificador
{
    public class Notificador : INotificador
    {
        private List<Notificacao> notificacoes;

        public Notificador()
        {
            notificacoes = new List<Notificacao>();
        }

        public IEnumerable<Notificacao> ObterNotificacoes()
        {
            return notificacoes;
        }

        public bool TemNotifiicacoes()
        {
            return notificacoes.Any();
        }

        public void TratarNotificacao(Notificacao notificacao)
        {
            notificacoes.Add(notificacao);
        }
    }
}