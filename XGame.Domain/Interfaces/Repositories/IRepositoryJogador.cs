using System;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.ValueObjects;
namespace XGame.Domain.Interfaces.Repositories
{
    public interface IRepositoryJogador
    {
        AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request);
        Guid AdicionarJogador(AdicionarJogadorRequest request);
    }

}
