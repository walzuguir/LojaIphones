using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaIphones
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("----- Sistema de Iphones -----"); // Pré-menu
                    Console.WriteLine();
                    Console.WriteLine("Digite SAIR para encerrar a aplicação.");
                    Console.WriteLine();
                    Console.WriteLine("1 - Cadastrar");
                    Console.WriteLine("2 - Visualizar");
                    Console.WriteLine("3 - Comprar iPhone");
                    Console.WriteLine("4 - Sair");
                    Console.WriteLine();
                    Console.Write("Escolha uma opção: ");
                    string opcao = Console.ReadLine();

                    if (opcao == "sair" || opcao == "4")
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Saindo da aplicação, aperte qualquer tecla pra confirmar...");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                    }

                    switch (opcao)
                    {
                        case "1":
                            MenuCadastrar();
                            break;

                        case "2":
                            MenuVisualizar();
                            break;

                        case "3":
                            Console.Clear();
                            IphoneRepo.ComprarIphone();
                            break;

                        default:
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Selecione uma opção válida! [Enter para continuar]");
                            Console.ResetColor();
                            Console.ReadKey();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erro: Tente novamente.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }

        static void MenuCadastrar()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("----- Menu de Cadastro -----");
                    Console.WriteLine("Digite SAIR para voltar ao menu principal.");
                    Console.WriteLine();
                    Console.WriteLine("1 - Cadastrar Cliente");
                    Console.WriteLine("2 - Cadastrar Empresa");
                    Console.WriteLine("3 - Cadastrar iPhones");
                    Console.WriteLine("4 - Sair");
                    Console.WriteLine();
                    Console.Write("Escolha uma opção: ");
                    string opcao = Console.ReadLine();

                    if (opcao == "sair" || opcao == "4")
                    {
                        break;
                    }

                    switch (opcao)
                    {
                        case "1":
                            Console.Clear();
                            IphoneRepo.CadastrarCliente();
                            break;

                        case "2":
                            Console.Clear();
                            IphoneRepo.CadastrarEmpresa();
                            break;

                        case "3":
                            Console.Clear();
                            Console.Write("Digite a quantidade de iPhones a cadastrar: ");
                            int quantidade = int.Parse(Console.ReadLine());
                            IphoneRepo.CadastrarIphones(quantidade);
                            break;

                        default:
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Selecione uma opção válida! [Enter para continuar]");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erro: Tente novamente.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }

        static void MenuVisualizar()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("----- Menu de Visualização -----");
                    Console.WriteLine("Digite SAIR para voltar ao menu principal.");
                    Console.WriteLine();
                    Console.WriteLine("1 - Informações das Empresas");
                    Console.WriteLine("2 - iPhones disponíveis");
                    Console.WriteLine("3 - Informações dos Clientes");
                    Console.WriteLine("4 - Sair");
                    Console.WriteLine();
                    Console.Write("Escolha uma opção válida: ");
                    string opcao = Console.ReadLine();

                    if (opcao == "sair" || opcao == "4")
                    {
                        break;
                    }

                    switch (opcao)
                    {
                        case "1":
                            Console.Clear();
                            IphoneRepo.VisualizarInformacoesEmpresas();
                            break;

                        case "2":
                            Console.Clear();
                            IphoneRepo.VisualizarIphonesDisponiveis();
                            break;

                        case "3":
                            Console.Clear();
                            IphoneRepo.VisualizarInformacoesCliente();
                            break;

                        default:
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Selecione uma opção válida! [Enter para continuar]");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erro: Tente novamente.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }
    }
}
