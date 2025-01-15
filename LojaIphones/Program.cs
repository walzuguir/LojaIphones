using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace LojaIphones
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("----- Sistema de Iphones -----");
                    Console.WriteLine("1 - Cadastrar Cliente");
                    Console.WriteLine("2 - Cadastrar Empresa");
                    Console.WriteLine("3 - Cadastrar Iphones");
                    Console.WriteLine("4 - informações das Empresas");
                    Console.WriteLine("5 - Iphones disponiveis");
                    Console.WriteLine("6 - Informações dos clientes");
                    Console.WriteLine("7 - Comprar Iphone");
                    Console.WriteLine("8 - Sair");
                    Console.Write("Escolha uma opção: ");
                    opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            IphoneRepo.CadastrarCliente();
                            break;

                        case 2:
                            IphoneRepo.CadastrarEmpresa();
                            break;

                        case 3:
                            IphoneRepo.CadastrarIphone();
                            break;

                        case 4:
                            IphoneRepo.VisualizarInformacoesEmpresas();
                            break;

                        case 5:
                            IphoneRepo.VisualizarIphonesDisponiveis();
                            break;

                        case 6:
                            IphoneRepo.VisualizarInformacoesCliente();
                            break;

                        case 7:
                            IphoneRepo.ComprarIphone();
                            break;

                        case 8:
                            Console.WriteLine("Saindo...");
                            break;

                        default:
                            Console.WriteLine("Selecione uma opção válida!");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erro: Tente novamente.");
                    Console.ReadKey();
                }
            } while (opcao != 8);
        }
    }
}