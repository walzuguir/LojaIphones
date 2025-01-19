using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;


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
                    Console.WriteLine();
                    Console.WriteLine("Digite SAIR para voltar ao menu de cadastro.");
                    Console.WriteLine();

                    string nome;
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("---- Cadastro de Cliente ----");
                        Console.WriteLine();
                        Console.WriteLine("Digite SAIR para voltar ao menu de cadastro.");
                        Console.WriteLine();
                        Console.Write("Nome: ");
                        nome = Console.ReadLine();
                        if (nome == "sair")
                            return;
                        if (!string.IsNullOrWhiteSpace(nome) && Regex.IsMatch(nome, @"^[\p{L}]+$"))
                            break;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nome do cliente deve conter apenas letras e não pode ser vazio. [Enter para continuar]");
                        Console.ResetColor();
                        Console.ReadKey();
                    }

                    Console.WriteLine();

                    string cpf;
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("---- Cadastro de Cliente ----");
                        Console.WriteLine();
                        Console.WriteLine("Digite SAIR para voltar ao menu de cadastro.");
                        Console.WriteLine();
                        Console.Write("CPF: ");
                        cpf = Console.ReadLine();
                        if (cpf == "sair")
                            return;
                        if (!string.IsNullOrWhiteSpace(cpf) && cpf.Length == 11 && cpf.All(char.IsDigit))
                            break;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Por favor digite um CPF válido (11 dígitos numéricos). [Enter para continuar]");
                        Console.ResetColor();
                        Console.ReadKey();
                    }

                    Console.WriteLine();

                    double saldo;
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("---- Cadastro de Cliente ----");
                        Console.WriteLine();
                        Console.WriteLine("Digite SAIR para voltar ao menu de cadastro.");
                        Console.WriteLine();
                        Console.Write("Saldo: ");
                        string saldoInput = Console.ReadLine();
                        if (saldoInput == "sair")
                            return;
                        if (!string.IsNullOrWhiteSpace(saldoInput) && double.TryParse(saldoInput.Replace(",", "."), CultureInfo.InvariantCulture, out saldo))
                            break;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Por favor digite um saldo válido. [Enter para continuar]");
                        Console.ResetColor();
                        Console.ReadKey();
                    }

                    clientes.Add(new Cliente(nome, cpf, saldo));
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Cliente cadastrado com sucesso!");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;

                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Tente novamente, entrada inválida");
                    Console.ResetColor();
                    Console.WriteLine("Erro: " + e);
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ocorreu um erro inesperado: " + e.Message);
                    Console.ResetColor();
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
                    Console.WriteLine();
                    Console.WriteLine("Digite SAIR para voltar ao menu de cadastro.");
                    Console.WriteLine();

                    string nomeEmpresa;
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("---- Cadastro de Empresas ----");
                        Console.WriteLine();
                        Console.WriteLine("Digite SAIR para voltar ao menu de cadastro.");
                        Console.WriteLine();
                        Console.Write("Nome da empresa: ");
                        nomeEmpresa = Console.ReadLine();
                        if (nomeEmpresa == "sair")
                            return;
                        if (!string.IsNullOrWhiteSpace(nomeEmpresa))
                            break;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nome da empresa não pode ser vazio. [Enter para continuar]");
                        Console.ResetColor();
                        Console.ReadKey();
                    }

                    Console.WriteLine();

                    string cnpj;
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("---- Cadastro de Empresas ----");
                        Console.WriteLine();
                        Console.WriteLine("Digite SAIR para voltar ao menu de cadastro.");
                        Console.WriteLine();
                        Console.Write("CNPJ da empresa: ");
                        cnpj = Console.ReadLine();
                        if (cnpj == "sair")
                            return;
                        if (!string.IsNullOrWhiteSpace(cnpj) && cnpj.Length == 14 && cnpj.All(char.IsDigit))
                            break;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Por favor digite um CNPJ válido (14 dígitos numéricos). [Enter para continuar]");
                        Console.ResetColor();
                        Console.ReadKey();
                    }

                    empresas.Add(new Empresa(nomeEmpresa, cnpj));
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Empresa cadastrada com sucesso!");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;

                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Tente novamente, entrada inválida.");
                    Console.ResetColor();
                    Console.WriteLine("Erro: " + e);
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ocorreu um erro inesperado: " + e.Message);
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }

        public static void CadastrarIphones(int quantidade)
        {
            for (int i = 0; i < quantidade; i++)
            {
                while (true)
                {
                    try
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"---- Cadastro de Iphone {i + 1} de {quantidade} ----");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("Digite SAIR para voltar ao menu de cadastro.");
                        Console.WriteLine();

                        int empresaIndex;
                        while (true)
                        {
                            Console.Clear();
                            for (int j = 0; j < empresas.Count; j++)
                            {
                                Console.WriteLine($"---- Cadastro de Iphone {i + 1} de {quantidade} ----");
                                Console.ResetColor();
                                Console.WriteLine();
                                Console.WriteLine("Digite SAIR para voltar ao menu de cadastro.");
                                Console.WriteLine();
                                Console.WriteLine($"{j + 1} - {empresas[j].NomeEmpresa}");
                                Console.WriteLine();
                            }

                            Console.Write("Digite o número da empresa: ");
                            string empresaIndexInput = Console.ReadLine();
                            if (empresaIndexInput == "sair")
                                return;
                            if (!string.IsNullOrWhiteSpace(empresaIndexInput) && int.TryParse(empresaIndexInput, out empresaIndex) && empresaIndex >= 1 && empresaIndex <= empresas.Count)
                            {
                                empresaIndex--;
                                break;
                            }
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Empresa inválida. [Enter para continuar]");
                            Console.ResetColor();
                            Console.ReadKey();
                        }

                        Console.WriteLine();

                        string modelo;
                        while (true)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine($"---- Cadastro de Iphone {i + 1} de {quantidade} ----");
                            Console.ResetColor();
                            Console.WriteLine();
                            Console.WriteLine("Digite SAIR para voltar ao menu de cadastro.");
                            Console.WriteLine();
                            Console.Write("Modelo: ");
                            modelo = Console.ReadLine();
                            if (modelo == "sair")
                                return;
                            if (!string.IsNullOrWhiteSpace(modelo))
                                break;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Modelo não pode ser vazio. [Enter]");
                            Console.ResetColor();
                            Console.ReadKey();
                        }

                        Console.WriteLine();

                        int ano;
                        while (true)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine($"---- Cadastro de Iphone {i + 1} de {quantidade} ----");
                            Console.ResetColor();
                            Console.WriteLine();
                            Console.WriteLine("Digite SAIR para voltar ao menu de cadastro.");
                            Console.WriteLine();
                            Console.Write("Ano: ");
                            string anoInput = Console.ReadLine();
                            if (anoInput == "sair")
                                return;
                            if (!string.IsNullOrWhiteSpace(anoInput) && int.TryParse(anoInput, out ano))
                                break;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Por favor digite um ano válido. [Enter para continuar]");
                            Console.ResetColor();
                            Console.ReadKey();
                        }

                        Console.WriteLine();

                        string cor;
                        while (true)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine($"---- Cadastro de Iphone {i + 1} de {quantidade} ----");
                            Console.ResetColor();
                            Console.WriteLine();
                            Console.WriteLine("Digite SAIR para voltar ao menu de cadastro.");
                            Console.WriteLine();
                            Console.Write("Cor: ");
                            cor = Console.ReadLine();
                            if (cor == "sair")
                                return;
                            if (!string.IsNullOrWhiteSpace(cor) && Regex.IsMatch(cor, @"^[\p{L}]+$"))
                                break;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Cor não pode ser vazia. [Enter para continuar]");
                            Console.ResetColor();
                            Console.ReadKey();
                        }

                        Console.WriteLine();

                        double valor;
                        while (true)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine($"---- Cadastro de Iphone {i + 1} de {quantidade} ----");
                            Console.ResetColor();
                            Console.WriteLine();
                            Console.WriteLine("Digite SAIR para voltar ao menu de cadastro.");
                            Console.WriteLine();
                            Console.Write("Valor: ");
                            string valorInput = Console.ReadLine();
                            if (valorInput == "sair")
                                return;
                            if (!string.IsNullOrWhiteSpace(valorInput))
                            {
                                valorInput = valorInput.Replace(',', '.');
                                if (double.TryParse(valorInput, NumberStyles.Any, CultureInfo.InvariantCulture, out valor) && valor > 0)
                                    break;
                            }
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Por favor digite um valor válido (maior que 0). [Enter para continuar]");
                            Console.ResetColor();
                            Console.ReadKey();
                        }

                        bool isDisponivel = true;
                        empresas[empresaIndex].ListaDeIphones.Add(new Iphone(modelo, ano, cor, valor, isDisponivel));
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Iphone cadastrado com sucesso!");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                    }
                    catch (FormatException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Entrada inválida, Tente novamente.");
                        Console.ResetColor();
                        Console.WriteLine("Erro: " + e);
                        Console.ReadKey();
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ocorreu um erro inesperado: " + e.Message);
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                }
            }
        }

        public static void VisualizarInformacoesEmpresas() 
        {
            try
            {
                Console.Clear();
                Console.WriteLine("---- Empresas ----");
                Console.WriteLine();
                Console.WriteLine("Aperte qualquer tecla para voltar ao menu de visualização.");
                Console.WriteLine();
                if (empresas.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nenhuma empresa cadastrada no sistema.");
                    Console.ResetColor();
                }
                else
                {
                    foreach (var empresa in empresas)
                    {
                        empresa.VisualizarInformacoes();
                        Console.WriteLine();
                    }
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ocorreu um erro ao visualizar as informações das empresas: " + e.Message);
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        public static void VisualizarIphonesDisponiveis()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("---- Iphones ----");
                Console.WriteLine();
                Console.WriteLine("Aperte qualquer tecla para voltar ao menu de visualização.");
                Console.WriteLine();
                bool iphonesDisponiveis = false; 
                foreach (var empresa in empresas)
                {
                    foreach (var iphone in empresa.ListaDeIphones)
                    {
                        if (iphone.IsDisponivel)
                        {
                            iphonesDisponiveis = true;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Modelo: {iphone.Modelo}, Ano: {iphone.Ano}, Cor: {iphone.Cor}, Valor: {iphone.Valor.ToString("F2", CultureInfo.CurrentCulture)}");
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                    }
                }
                if (!iphonesDisponiveis)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nenhum iPhone disponível no momento.");
                    Console.ResetColor();
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ocorreu um erro ao visualizar os iPhones disponíveis: " + e.Message);
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        public static void VisualizarInformacoesCliente()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("---- Clientes ----");
                Console.WriteLine();
                Console.WriteLine("Aperte qualquer tecla para voltar ao menu de visualização.");
                Console.WriteLine();
                if (clientes.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nenhum cliente cadastrado.");
                    Console.ResetColor();
                }
                else
                {
                    foreach (var cliente in clientes)
                    {
                        cliente.VisualizarInformacoes();
                        Console.WriteLine();
                    }
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ocorreu um erro ao visualizar as informações dos clientes: " + e.Message);
                Console.ResetColor();
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
                    Console.WriteLine();
                    Console.WriteLine("Digite SAIR para voltar ao menu principal.");
                    Console.WriteLine();

                    if (clientes.Count == 0 || empresas.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Clientes ou empresas não cadastrados. [Enter para continuar]");
                        Console.ResetColor();
                        Console.ReadKey();
                        return;
                    }

                    int escolhaCliente;
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("---- Comprar Iphone ----");
                        Console.WriteLine();
                        Console.WriteLine("Digite SAIR para voltar ao menu principal.");
                        Console.WriteLine();
                        Console.WriteLine("Escolha o cliente: ");
                        for (int i = 0; i < clientes.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {clientes[i].Nome}");
                        }
                        Console.WriteLine();
                        string escolhaClienteInput = Console.ReadLine();
                        if (escolhaClienteInput == "sair")
                            return;
                        if (!string.IsNullOrWhiteSpace(escolhaClienteInput) && int.TryParse(escolhaClienteInput, out escolhaCliente) && escolhaCliente >= 1 && escolhaCliente <= clientes.Count)
                        {
                            escolhaCliente--;
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Cliente inválido. [Enter para continuar]");
                        Console.ResetColor();
                        Console.ReadKey();
                    }

                    Console.WriteLine();

                    int escolhaEmpresa;
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("---- Comprar Iphone ----");
                        Console.WriteLine();
                        Console.WriteLine("Digite SAIR para voltar ao menu principal.");
                        Console.WriteLine();
                        Console.WriteLine("Escolha a empresa:");
                        for (int i = 0; i < empresas.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {empresas[i].NomeEmpresa}");
                        }
                        Console.WriteLine();
                        string escolhaEmpresaInput = Console.ReadLine();
                        if (escolhaEmpresaInput == "sair")
                            return;
                        if (!string.IsNullOrWhiteSpace(escolhaEmpresaInput) && int.TryParse(escolhaEmpresaInput, out escolhaEmpresa) && escolhaEmpresa >= 1 && escolhaEmpresa <= empresas.Count)
                        {
                            escolhaEmpresa--;
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Empresa inválida. [Enter para continuar]");
                        Console.ResetColor();
                        Console.ReadKey();
                    }

                    Console.WriteLine();

                    Empresa empresa = empresas[escolhaEmpresa];
                    Cliente cliente = clientes[escolhaCliente];

                    int escolhaIphone;
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("---- Comprar Iphone ----");
                        Console.WriteLine();
                        Console.WriteLine("Digite SAIR para voltar ao menu principal.");
                        Console.WriteLine();
                        Console.WriteLine("Escolha o iphone:");
                        if (empresa.ListaDeIphones.Count < 1)
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Nenhum iPhone está disponível na {empresa.NomeEmpresa}.");
                            Console.WriteLine();
                            Console.WriteLine("Pressione qualquer botão para voltar ao menu principal");
                            Console.ResetColor();
                            Console.ReadKey();
                            return;
                        }
                        for (int i = 0; i < empresa.ListaDeIphones.Count; i++)
                        {
                            var iphone = empresa.ListaDeIphones[i];
                            if (iphone != null && iphone.IsDisponivel)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{i + 1} - {iphone.Modelo}, R$ {iphone.Valor} ");
                                Console.ResetColor();
                            }
                        }
                        Console.WriteLine();
                        string escolhaIphoneInput = Console.ReadLine();
                        if (escolhaIphoneInput == "sair")
                            return;
                        if (!string.IsNullOrWhiteSpace(escolhaIphoneInput) && int.TryParse(escolhaIphoneInput, out escolhaIphone) && escolhaIphone >= 1 && escolhaIphone <= empresa.ListaDeIphones.Count)
                        {
                            escolhaIphone--;
                            break;
                        }
                    }

                    Console.WriteLine();

                    if (!empresa.ListaDeIphones[escolhaIphone].IsDisponivel)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Este iphone não está disponível para compra nessa empresa. [Enter para continuar]");
                        Console.ResetColor();
                        Console.ReadKey();
                        continue;
                    }

                    if (cliente.Saldo < empresa.ListaDeIphones[escolhaIphone].Valor)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Saldo insuficiente para realizar a compra. [Enter para continuar]");
                        Console.ResetColor();
                        Console.ReadKey();
                        continue;
                    }

                    cliente.EfetuarCompra(empresa.ListaDeIphones[escolhaIphone], empresa);

                    empresa.ListaDeIphones[escolhaIphone].IsDisponivel = false;

                    empresa.ListaDeIphones.RemoveAt(escolhaIphone);

                    Console.ReadKey();
                    break;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erro na compra. Tente novamente.");
                    Console.ResetColor();
                    Console.WriteLine("Erro: " + e);
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ocorreu um erro inesperado: " + e.Message);
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }
    }
}
