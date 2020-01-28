using prmToolKit.NotificationPattern;
using System;
using XGame.Domain.ValueObjects;
using XGame.Domain.Enum;
namespace  XGame.Domain.Entities
{
    public class Jogador : Notifiable
    {
        public Jogador(Email email, Senha senha)
        {
            this.Email = email;
            this.Senha = senha;

            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x=> x.senha, 6, 32, "A senha deve ter entre 6 a 32 caracteres")
                ;

        }
        public Guid Id { get; set; }
        public Nome Nome { get; set; }
        public Email Email { get; set; }
        public string Senha { get; set; }
        public EnumSituacaoJogador Status { get; set; }
    }
}