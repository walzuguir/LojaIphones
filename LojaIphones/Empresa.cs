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
            Console.WriteLine($"Cnpj: {FormatarCnpj(Cnpj)}");
            Console.WriteLine($"Iphones disponiveis na {NomeEmpresa}: ");
            Console.WriteLine("--------------------");
            ViewIphonesDisponiveis();
        }

        public void ViewIphonesDisponiveis()
        {
            bool iphonesDisponiveis = false;
            foreach (var iphone in ListaDeIphones)
            {
                if (iphone != null && iphone.IsDisponivel)
                {
                    iphonesDisponiveis = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{iphone.Modelo}, ano: {iphone.Ano}, cor: {iphone.Cor}, valor: R$ {iphone.Valor.ToString("F2", CultureInfo.CurrentCulture)}");
                    Console.ResetColor();
                    Console.WriteLine("--------------------");
                }
            }

            if (!iphonesDisponiveis)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Nenhum iPhone disponível na {NomeEmpresa}.");
                Console.ResetColor();
            }
        }

        private string FormatarCnpj(string cnpj)
        {
            if (cnpj.Length == 14)
            {
                return Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
            }
            return cnpj;
        }
    }
}
