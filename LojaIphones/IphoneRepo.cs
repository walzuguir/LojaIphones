using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace LojaIphones
{
    public class IphoneRepo
    {
        public static List<Empresa> empresas = new List<Empresa>();
        public static List<Cliente> clientes = new List<Cliente>();
        public static List<Iphone> iphones = new List<Iphone>();

        public static void CadastrarCliente()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("---- Cadastro de Cliente ----");
                    Console.WriteLine("Digite 0 para voltar ao menu principal.");

                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    if (nome == "0")
                        break;
                    if (string.IsNullOrWhiteSpace(nome))
                    {
                        Console.WriteLine("Nome não pode ser vazio. [Enter]");
                        Console.ReadKey();
                        continue;
                    }

                    Console.Write("CPF: ");
                    string cpf = Console.ReadLine();
                    if (cpf == "0")
                        break;
                    if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 || !cpf.All(char.IsDigit))
                    {
                        Console.WriteLine("Por favor digite um CPF válido (11 dígitos numéricos). [Enter]");
                        Console.ReadKey();
                        continue;
                    }

                    Console.Write("Saldo: ");
                    string saldoInput = Console.ReadLine();
                    if (saldoInput == "0")
                        break;
                    if (string.IsNullOrWhiteSpace(saldoInput) || !double.TryParse(saldoInput, out double saldo))
                    {
                        Console.WriteLine("Por favor digite um saldo válido. [Enter]");
                        Console.ReadKey();
                        continue;
                    }

                    clientes.Add(new Cliente(nome, cpf, saldo));
                    Console.WriteLine("Cliente cadastrado com sucesso!");
                    Console.ReadKey();
                    break;

                }
                catch (FormatException e)
                {
                    Console.WriteLine("Tente novamente, entrada inválida");
                    Console.WriteLine("Erro: " + e);
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocorreu um erro inesperado: " + e.Message);
                    Console.ReadKey();
                }
            }
        }

        public static void CadastrarEmpresa()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("---- Cadastro de Empresas ----");
                    Console.WriteLine("Digite 0 para voltar ao menu principal.");

                    Console.Write("Nome da empresa: ");
                    string nomeEmpresa = Console.ReadLine();
                    if (nomeEmpresa == "0")
                        break;
                    if (string.IsNullOrWhiteSpace(nomeEmpresa))
                    {
                        Console.WriteLine("Nome da empresa não pode ser vazio. [Enter]");
                        Console.ReadKey();
                        continue;
                    }

                    Console.Write("CNPJ da empresa: ");
                    string cnpj = Console.ReadLine();
                    if (cnpj == "0")
                        break;
                    if (string.IsNullOrWhiteSpace(cnpj) || cnpj.Length != 14 || !cnpj.All(char.IsDigit))
                    {
                        Console.WriteLine("Por favor digite um CNPJ válido (14 dígitos numéricos). [Enter]");
                        Console.ReadKey();
                        continue;
                    }

                    empresas.Add(new Empresa(nomeEmpresa, cnpj));
                    Console.WriteLine("Empresa cadastrada com sucesso!");
                    Console.ReadKey();
                    break;

                }
                catch (FormatException e)
                {
                    Console.WriteLine("Tente novamente, entrada inválida.");
                    Console.WriteLine("Erro: " + e);
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocorreu um erro inesperado: " + e.Message);
                    Console.ReadKey();
                }
            }
        }

        public static void CadastrarIphone()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("---- Cadastro de Iphones ----");
                    Console.WriteLine("Digite 0 para voltar ao menu principal.");
                    for (int i = 0; i < empresas.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {empresas[i].NomeEmpresa}");
                    }
                    Console.WriteLine("Digite o número da empresa: ");
                    string empresaIndexInput = Console.ReadLine();
                    if (empresaIndexInput == "0")
                        break;
                    if (string.IsNullOrWhiteSpace(empresaIndexInput) || !int.TryParse(empresaIndexInput, out int empresaIndex) || empresaIndex < 1 || empresaIndex > empresas.Count)
                    {
                        Console.WriteLine("Empresa inválida. [Enter]");
                        Console.ReadKey();
                        continue;
                    }
                    empresaIndex--;

                    Console.Write("Modelo:");
                    string modelo = Console.ReadLine();
                    if (modelo == "0")
                        break;
                    if (string.IsNullOrWhiteSpace(modelo))
                    {
                        Console.WriteLine("Modelo não pode ser vazio. [Enter]");
                        Console.ReadKey();
                        continue;
                    }

                    Console.Write("Ano: ");
                    string anoInput = Console.ReadLine();
                    if (anoInput == "0")
                        break;
                    if (string.IsNullOrWhiteSpace(anoInput) || !int.TryParse(anoInput, out int ano))
                    {
                        Console.WriteLine("Por favor digite um ano válido. [Enter]");
                        Console.ReadKey();
                        continue;
                    }

                    Console.Write("Cor: ");
                    string cor = Console.ReadLine();
                    if (cor == "0")
                        break;
                    if (string.IsNullOrWhiteSpace(cor))
                    {
                        Console.WriteLine("Cor não pode ser vazia. [Enter]");
                        Console.ReadKey();
                        continue;
                    }

                    Console.Write("Valor: ");
                    string valorInput = Console.ReadLine();
                    if (valorInput == "0")
                        break;
                    if (string.IsNullOrWhiteSpace(valorInput) || !double.TryParse(valorInput, NumberStyles.Any, CultureInfo.InvariantCulture, out double valor))
                    {
                        Console.WriteLine("Por favor digite um valor válido. [Enter]");
                        Console.ReadKey();
                        continue;
                    }

                    bool isDisponivel = true;
                    empresas[empresaIndex].ListaDeIphones.Add(new Iphone(modelo, ano, cor, valor, isDisponivel));
                    Console.WriteLine("Iphone cadastrado com sucesso!");
                    Console.ReadKey();
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Entrada inválida, Tente novamente.");
                    Console.WriteLine("Erro: " + e);
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocorreu um erro inesperado: " + e.Message);
                    Console.ReadKey();
                }
            }
        }

        public static void VisualizarInformacoesEmpresas()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("---- Empresas ----");
                if (empresas.Count == 0)
                {
                    Console.WriteLine("Nenhuma empresa cadastrada no sistema.");
                }
                else
                {
                    foreach (var empresa in empresas)
                    {
                        empresa.VisualizarInformacoes();
                    }
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao visualizar as informações das empresas: " + e.Message);
                Console.ReadKey();
            }
        }

        public static void VisualizarIphonesDisponiveis()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("---- Iphones ----");
                bool iphonesDisponiveis = false;
                foreach (var empresa in empresas)
                {
                    foreach (var iphone in empresa.ListaDeIphones)
                    {
                        if (iphone.IsDisponivel)
                        {
                            iphonesDisponiveis = true;
                            Console.WriteLine($"Modelo: {iphone.Modelo}, Ano: {iphone.Ano}, Cor: {iphone.Cor}, Valor: {iphone.Valor.ToString("F2", CultureInfo.CurrentCulture)}");
                        }
                    }
                }
                if (!iphonesDisponiveis)
                {
                    Console.WriteLine("Nenhum iPhone disponível no momento.");
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao visualizar os iPhones disponíveis: " + e.Message);
                Console.ReadKey();
            }
        }

        public static void VisualizarInformacoesCliente()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("---- Clientes ----");
                if (clientes.Count == 0)
                {
                    Console.WriteLine("Nenhum cliente cadastrado");
                }
                else
                {
                    foreach (var cliente in clientes)
                    {
                        cliente.VisualizarInformacoes();
                    }
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao visualizar as informações dos clientes: " + e.Message);
                Console.ReadKey();
            }
        }

        public static void ComprarIphone()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("---- Comprar Iphone ----");
                    Console.WriteLine("Digite 0 para voltar ao menu principal.");

                    if (clientes.Count == 0 || empresas.Count == 0)
                    {
                        Console.WriteLine("Clientes ou empresas não cadastrados. Realize os cadastros antes de prosseguir.");
                        Console.ReadKey();
                        return;
                    }

                    Console.WriteLine("Escolha o cliente: ");
                    for (int i = 0; i < clientes.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {clientes[i].Nome}");
                    }
                    string escolhaClienteInput = Console.ReadLine();
                    if (escolhaClienteInput == "0")
                        break;
                    if (string.IsNullOrWhiteSpace(escolhaClienteInput) || !int.TryParse(escolhaClienteInput, out int escolhaCliente) || escolhaCliente < 1 || escolhaCliente > clientes.Count)
                    {
                        Console.WriteLine("Cliente inválido. [Enter]");
                        Console.ReadKey();
                        continue;
                    }
                    escolhaCliente--;

                    Console.WriteLine("Escolha a empresa:");
                    for (int i = 0; i < empresas.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {empresas[i].NomeEmpresa}");
                    }
                    string escolhaEmpresaInput = Console.ReadLine();
                    if (escolhaEmpresaInput == "0")
                        break;
                    if (string.IsNullOrWhiteSpace(escolhaEmpresaInput) || !int.TryParse(escolhaEmpresaInput, out int escolhaEmpresa) || escolhaEmpresa < 1 || escolhaEmpresa > empresas.Count)
                    {
                        Console.WriteLine("Empresa inválida. [Enter]");
                        Console.ReadKey();
                        continue;
                    }
                    escolhaEmpresa--;

                    Empresa empresa = empresas[escolhaEmpresa];
                    Cliente cliente = clientes[escolhaCliente];

                    Console.WriteLine("Escolha o iphone:");
                    for (int i = 0; i < empresa.ListaDeIphones.Count; i++)
                    {
                        var iphone = empresa.ListaDeIphones[i];
                        if (iphone != null && iphone.IsDisponivel)
                        {
                            Console.WriteLine($"{i + 1} - {iphone.Modelo} ({iphone.Valor}) R$");
                        }
                        else
                        {
                            Console.WriteLine($"{i + 1} - Esse iphone não está disponível.");
                        }
                    }
                    string escolhaIphoneInput = Console.ReadLine();
                    if (escolhaIphoneInput == "0")
                        break;
                    if (string.IsNullOrWhiteSpace(escolhaIphoneInput) || !int.TryParse(escolhaIphoneInput, out int escolhaIphone) || escolhaIphone < 1 || escolhaIphone > empresa.ListaDeIphones.Count)
                    {
                        Console.WriteLine("iPhone inválido. [Enter]");
                        Console.ReadKey();
                        continue;
                    }
                    escolhaIphone--;

                    if (!empresa.ListaDeIphones[escolhaIphone].IsDisponivel)
                    {
                        Console.WriteLine("Este iphone não está disponível para compra.");
                        Console.ReadKey();
                        continue;
                    }

                    if (cliente.Saldo < empresa.ListaDeIphones[escolhaIphone].Valor)
                    {
                        Console.WriteLine("Saldo insuficiente para realizar a compra.");
                        Console.ReadKey();
                        continue;
                    }

                    cliente.EfetuarCompra(empresa.ListaDeIphones[escolhaIphone]);
                    empresa.ListaDeIphones[escolhaIphone].IsDisponivel = false;
                    Console.ReadKey();
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Erro na compra. Tente novamente.");
                    Console.WriteLine("Erro: " + e);
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocorreu um erro inesperado: " + e.Message);
                    Console.ReadKey();
                }
            }
        }
    }
}
