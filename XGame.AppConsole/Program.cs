using System;
using System.Linq;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Services;

namespace XGame.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando...");

            var service = new ServiceJogador();

            Console.WriteLine("Criei umam isntancia o meu serviço");

            AutenticarJogadorRequest request = new AutenticarJogadorRequest();
            Console.WriteLine("Criei uma instancia do meu objeto de request");
            request.Email = "paulo@paulo.com";
            request.Senha = "12345678";

            var response = service.AutenticarJogador(request);

            Console.WriteLine("Serviço é valido -> " + service.IsValid());

            service.Notifications.ToList().ForEach(x =>
            {
                Console.WriteLine(x.Message);
            });

            Console.ReadKey();
        }
    }
}
