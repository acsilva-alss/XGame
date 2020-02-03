using prmToolkit.NotificationPattern;
using System;
using XGame.Domain.ValueObjects;
using XGame.Domain.Enum;
using XGame.Domain.Resources;
using XGame.Domain.Extensions;

namespace  XGame.Domain.Entities
{
    public class Jogador : Notifiable
    {
        public Jogador(Email email, string senha)
        {
            this.Email = email;
            this.Senha = senha;

            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x=> x.Senha, 6, 32, "A senha deve ter entre 6 a 32 caracteres")
                ;

        }

        public Jogador(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Id = Guid.NewGuid();
            Status = EnumSituacaoJogador.EmAnalise;

            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x => x.Senha, 6, 32,string.Format(Message.X0_E_OBRIGATORIO_E_DEVE_CONTER_X1_CARACTERES, "Senha", " 6 a 32"));

            if (IsValid())
            {
                this.Senha = this.Senha.ConvertToMD5();
            }
            AddNotifications(nome, email);
        }

        public Guid Id { get; private set; }
        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public string Senha { get; private set; }
        public EnumSituacaoJogador Status { get; private set; }
    }
}