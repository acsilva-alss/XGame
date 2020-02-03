using prmToolkit.NotificationPattern;
using System;
using XGame.Domain.Resources;

namespace  XGame.Domain.ValueObjects
{
    public class Nome: Notifiable
    {
        public Nome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;

            new AddNotifications<Nome>(this)
                .IfNullOrInvalidLength(x=>x.PrimeiroNome, 3, 50, string.Format(Message.X0_E_OBRIGATORIO_E_DEVE_CONTER_X1_CARACTERES,"Primeiro nome", "10" ))
                .IfNullOrInvalidLength(x => x.UltimoNome, 3, 50, string.Format(Message.X0_E_OBRIGATORIO_E_DEVE_CONTER_X1_CARACTERES, "Ultimo nome ", "10"));
        }

        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }

    } 
}