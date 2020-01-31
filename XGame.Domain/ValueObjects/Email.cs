using System;
using XGame.Domain.Resources;
using prmToolkit.NotificationPattern;
namespace  XGame.Domain.ValueObjects
{
    
    public class Email : Notifiable
    {
        public Email(string endereco)
        {
            this.Endereco = endereco;

            new AddNotifications<Email>(this).IfNotEmail(x=> x.Endereco, string.Format(Message.X0_INVALIDO,"E-mail" ));

        }
        public string Endereco { get; private set; }

    } 
}