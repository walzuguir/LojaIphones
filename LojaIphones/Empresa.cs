using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace LojaIphones
{
    public class Empresa
    {
        public string NomeEmpresa { get; set; }

        public string Cnpj { get; set; }

        public List<Iphone> ListaDeIphones { get; set; }

        public Empresa(string nomeEmpresa, string cnpj)
        {
            NomeEmpresa = nomeEmpresa;
            Cnpj = cnpj;
            ListaDeIphones = new List<Iphone>();
        }

        public void VisualizarInformacoes()
        {
            Console.WriteLine();
            Console.WriteLine($"Empresa: {NomeEmpresa}");
            Console.WriteLine($"Cnpj: {Cnpj}");
            Console.WriteLine($"Iphones disponiveis: ");
            Console.WriteLine("--------------------");
            ViewIphonesDisponiveis();
        }

        public void ViewIphonesDisponiveis()
        {
            foreach (var iphone in ListaDeIphones)
            {
                if (iphone != null && iphone.IsDisponivel)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{iphone.Modelo}, ano: {iphone.Ano}, cor: {iphone.Cor}, valor: R$ {iphone.Valor.ToString("F2", CultureInfo.CurrentCulture)}");
                    Console.ResetColor();
                    Console.WriteLine("--------------------");
                }
            }
        }
    }
}
