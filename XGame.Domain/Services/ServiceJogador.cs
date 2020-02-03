using System;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;
using prmToolkit.NotificationPattern;
using XGame.Domain.Entities;
using XGame.Domain.ValueObjects;
using XGame.Domain.Resources;

namespace XGame.Domain.Services
{
    public class ServiceJogador: Notifiable, IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;

        public ServiceJogador()
        {
        }

        public ServiceJogador(IRepositoryJogador repositoryJogador)
        {
            _repositoryJogador = repositoryJogador;
        }
        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {
            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var email = new Email(request.Email);

            Jogador jogador = new Jogador(nome, email, request.Senha);


            if (this.IsInvalid())
            {
                return null;
            }

            Guid id = _repositoryJogador.AdicionarJogador(jogador);

            return new AdicionarJogadorResponse(){Id = id, Message = "Operação realizada com sucesso"};
        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
            if(request == null)
            {
               AddNotification("AutenticarJogadorRequest",string.Format(Message.X0_E_OBRIGATORIO, "AutenticarJogadorRequest"));
            }

            var email = new Email(request.Email);
            var jogador = new Jogador(email, request.Senha);
            AddNotifications(jogador, email);

            if(jogador.IsInvalid())
            {
                return null;
            }

            var response = _repositoryJogador.AutenticarJogador(jogador.Email.Endereco, jogador.Senha);
            return response;

        }

        private bool IsEmail(string email)
        {
            return false;
        }


    }

}