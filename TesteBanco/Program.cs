using System;
using Graphql.Loja.Model;
using Graphql.Loja.Persistencia;

namespace TesteBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Cliente()
            {
                Id = 2
            };

            using (var ctx = new LocadouraDAO())
            {
                var cl = ctx.GetClienteById(c);
                Console.WriteLine(cl.Nome);
                Console.ReadKey();
            }
        }
    }
}
