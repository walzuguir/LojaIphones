using System;
using System.Globalization;

namespace LojaIphones
{
    public class Cliente
    {
           public string Nome { get; set; }

           public string Cpf { get; set; }

           public double Saldo { get; set; }
           public List<Iphone> ListaDeIphones { get; set; }

        public Cliente(string nome, string cpf, double saldo)
        {
            Nome = nome;
            Cpf = cpf;
            Saldo = saldo;
            ListaDeIphones = new List<Iphone>();
        }



        public void EfetuarCompra(Iphone iphone)
        {
            if (iphone == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Este iphone já foi adquirido. ");
                Console.ResetColor();
                return;
            }

            if (Saldo >= iphone.Valor)
            {
                Saldo -= iphone.Valor;
                ListaDeIphones.Add(iphone);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Compra realizada com sucesso!, você adquiriu o {iphone.Modelo}.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Saldo insuficiente pra realizar a compra, reveja seu saldo atual e tente novamente.");
                Console.ResetColor();
            }
        }

        public void VisualizarInformacoes()
        {
            Console.WriteLine();
            Console.WriteLine($"Cliente: {Nome}");
            Console.WriteLine($"Cpf: {Cpf}");
            if (Saldo > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Saldo: {Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
                Console.ResetColor();
                Console.WriteLine("--------------------");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Saldo: {Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
                Console.ResetColor();
                Console.WriteLine("--------------------");

            }
            Console.WriteLine($"Iphones adquiridos por {Nome}: ");
            Console.WriteLine();
            foreach (var iphone in ListaDeIphones)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{iphone.Modelo}");
                Console.ResetColor();
                Console.WriteLine("--------------------");
            }
        }
    }
}
