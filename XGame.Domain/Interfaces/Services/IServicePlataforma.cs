using System;
using XGame.Domain.Arguments.Plataforma;
using XGame.Domain.ValueObjects;

namespace  XGame.Domain.Interfaces.Services
{
    public interface IServicePlataforma
    {
      AdicionarPlataformaResponse AdicionarPlataforma(AdicionarPlataformaResquet request);
    } 
}