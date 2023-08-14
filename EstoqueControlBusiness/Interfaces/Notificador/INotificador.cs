using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueControlBusiness.Notificador;

namespace EstoqueControlBusiness.Interfaces.Notificador
{
    public interface INotificador
    {
        bool TemNotifiicacoes();
        IEnumerable<Notificacao>  ObterNotificacoes();
        void TratarNotificacao(Notificacao notificacao);
    }
}