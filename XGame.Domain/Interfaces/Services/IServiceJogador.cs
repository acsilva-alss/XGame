using System;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.ValueObjects;

namespace  XGame.Domain.Interfaces.Services
{
    public interface IServiceJogador
    {
        AutenticarJogadorResponse AutenticarJogador(string email, string senha);
        AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request);
    } 
}