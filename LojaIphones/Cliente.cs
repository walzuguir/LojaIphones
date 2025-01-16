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
                Console.WriteLine("Este iphone não está mais disponivel. ");
                return;
            }

            if (Saldo >= iphone.Valor)
            {
                Saldo -= iphone.Valor;
                ListaDeIphones.Add(iphone);
                Console.WriteLine($"Compra realizada com sucesso!, você adquiriu o {iphone.Modelo}.");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente pra realizar a compra.");
            }
        }

        public void VisualizarInformacoes()
        {
            Console.WriteLine($"Cliente: {Nome}");
            Console.WriteLine($"Cpf: {Cpf}");
            Console.WriteLine($"Saldo: {Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Iphones comprados: ");
            foreach (var iphone in ListaDeIphones)
            {
                Console.WriteLine($"{iphone.Modelo}");
            }
        }
    }
}
