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
                    ExibirMenuPrincipal();
                    string opcao = LerOpcaoUsuario();

                    if (opcao == "sair" || opcao == "4")
                    {
                        break;
                    }

                    ProcessarOpcaoMenuPrincipal(opcao);
                }
                catch (FormatException)
                {
                    ExibirMensagemErro("Erro: Tente novamente.");
                }
            }
        }

        static void ExibirMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("----- Sistema de Iphones -----");
            Console.WriteLine();
            Console.WriteLine("Digite SAIR para encerrar a aplicação.");
            Console.WriteLine();
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Visualizar");
            Console.WriteLine("3 - Comprar iPhone");
            Console.WriteLine("4 - Sair");
            Console.WriteLine();
        }

        static string LerOpcaoUsuario()
        {
            Console.Write("Escolha uma opção: ");
            return Console.ReadLine();
        }

        static void ProcessarOpcaoMenuPrincipal(string opcao)
        {
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
                    ExibirMensagemErro("Selecione uma opção válida! [Enter para continuar]");
                    break;
            }
        }

        static void ExibirMensagemErro(string mensagem)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadKey();
        }

        static void MenuCadastrar()
        {
            while (true)
            {
                try
                {
                    ExibirMenuCadastrar();
                    string opcao = LerOpcaoUsuario();

                    if (opcao == "sair" || opcao == "4")
                    {
                        break;
                    }

                    ProcessarOpcaoMenuCadastrar(opcao);
                }
                catch (FormatException)
                {
                    ExibirMensagemErro("Erro: Tente novamente.");
                }
            }
        }

        static void ExibirMenuCadastrar()
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
        }

        static void ProcessarOpcaoMenuCadastrar(string opcao)
        {
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
                    int quantidade = ObterQuantidadeIphones();
                    if (quantidade > 0)
                    {
                        IphoneRepo.CadastrarIphones(quantidade);
                    }
                    break;

                default:
                    ExibirMensagemErro("Selecione uma opção válida! [Enter para continuar]");
                    break;
            }
        }
        static void MenuVisualizar()
        {
            while (true)
            {
                try
                {
                    ExibirMenuVisualizar();
                    string opcao = LerOpcaoUsuario();

                    if (opcao == "sair" || opcao == "4")
                    {
                        break;
                    }

                    ProcessarOpcaoMenuVisualizar(opcao);
                }
                catch (FormatException)
                {
                    ExibirMensagemErro("Erro: Tente novamente.");
                }
            }
        }

        static void ExibirMenuVisualizar()
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
        }

        static void ProcessarOpcaoMenuVisualizar(string opcao)
        {
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
                    ExibirMensagemErro("Selecione uma opção válida! [Enter para continuar]");
                    break;
            }
        }
        static int ObterQuantidadeIphones()
        {
            if (IphoneRepo.empresas.Count == 0)
            {
                ExibirMensagemErro("Cadastre uma empresa antes de cadastrar um iPhone.");
                return -1;
            }

            while (true)
            {
                Console.WriteLine("Digite SAIR para voltar ao menu principal");
                Console.WriteLine();
                Console.Write("Digite a quantidade de iPhones a cadastrar: ");
                string quantidadeInput = Console.ReadLine();
                if (quantidadeInput.ToLower() == "sair")
                    return -1;
                if (int.TryParse(quantidadeInput, out int quantidade) && quantidade > 0)
                {
                    return quantidade;
                }
                else
                {
                    Console.Clear();
                    ExibirMensagemErro("Por favor, digite um número válido ou 'sair' para voltar ao menu principal.");
                }
            }
        }


    }
}

