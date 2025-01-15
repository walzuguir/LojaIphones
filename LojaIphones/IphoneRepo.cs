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
        public static List<Empresa> empresas = new List<Empresa>(); //Instanciando as novas listas gênericas
        public static List<Cliente> clientes = new List<Cliente>();
        public static List<Iphone> iphones = new List<Iphone>();

        public static void CadastrarCliente() // Método para cadastro de clientes
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("---- Cadastro de Cliente ----");
                    Console.WriteLine();
                    Console.WriteLine("Digite SAIR para voltar ao menu principal.");
                    Console.WriteLine();

                    string nome;
                    while (true)
                    {
                        Console.Write("Nome: ");
                        nome = Console.ReadLine();
                        if (nome == "sair")
                            return;
                        if (!string.IsNullOrWhiteSpace(nome))
                            break;
                        Console.WriteLine("Nome não pode ser vazio. [Enter]");
                        Console.ReadKey();
                    }

                    Console.WriteLine();

                    string cpf;
                    while (true)
                    {
                        Console.Write("CPF: ");
                        cpf = Console.ReadLine();
                        if (cpf == "sair")
                            return;
                        if (!string.IsNullOrWhiteSpace(cpf) && cpf.Length == 11 && cpf.All(char.IsDigit)) // Verificando se cpf não é nulo, tem 11 digitos e apenas números.
                            break;
                        Console.WriteLine("Por favor digite um CPF válido (11 dígitos numéricos). [Enter]");
                        Console.ReadKey();
                    }

                    Console.WriteLine();

                    double saldo;
                    while (true)
                    {
                        Console.Write("Saldo: ");
                        string saldoInput = Console.ReadLine();
                        if (saldoInput == "sair")
                            return;
                        if (!string.IsNullOrWhiteSpace(saldoInput) && double.TryParse(saldoInput, out saldo))
                            break;
                        Console.WriteLine("Por favor digite um saldo válido. [Enter]");
                        Console.ReadKey();
                    }

                    clientes.Add(new Cliente(nome, cpf, saldo));
                    Console.WriteLine();
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

        public static void CadastrarEmpresa() // Método para o cadastro de empresas
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("---- Cadastro de Empresas ----");
                    Console.WriteLine();
                    Console.WriteLine("Digite SAIR para voltar ao menu principal.");
                    Console.WriteLine();

                    string nomeEmpresa;
                    while (true)
                    {
                        Console.Write("Nome da empresa: ");
                        nomeEmpresa = Console.ReadLine();
                        if (nomeEmpresa == "sair")
                            return;
                        if (!string.IsNullOrWhiteSpace(nomeEmpresa))
                            break;
                        Console.WriteLine("Nome da empresa não pode ser vazio. [Enter]");
                        Console.ReadKey();
                    }

                    Console.WriteLine();

                    string cnpj;
                    while (true)
                    {
                        Console.Write("CNPJ da empresa: ");
                        cnpj = Console.ReadLine();
                        if (cnpj == "sair")
                            return;
                        if (!string.IsNullOrWhiteSpace(cnpj) && cnpj.Length == 14 && cnpj.All(char.IsDigit))
                            break;
                        Console.WriteLine("Por favor digite um CNPJ válido (14 dígitos numéricos). [Enter]");
                        Console.ReadKey();
                    }

                    empresas.Add(new Empresa(nomeEmpresa, cnpj));
                    Console.WriteLine();
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

        public static void CadastrarIphones(int quantidade) // Método para cadastro de iphones
        {
            for (int i = 0; i < quantidade; i++)
            {
                while (true)
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine($"---- Cadastro de Iphone {i + 1} de {quantidade} ----");
                        Console.WriteLine();
                        Console.WriteLine("Digite SAIR para voltar ao menu principal.");
                        Console.WriteLine();

                        int empresaIndex;
                        while (true)
                        {
                            for (int j = 0; j < empresas.Count; j++)
                            {
                                Console.WriteLine($"{j + 1} - {empresas[j].NomeEmpresa}");
                            }
                            Console.WriteLine();
                            Console.Write("Digite o número da empresa: ");
                            string empresaIndexInput = Console.ReadLine();
                            if (empresaIndexInput == "sair")
                                return;
                            if (!string.IsNullOrWhiteSpace(empresaIndexInput) && int.TryParse(empresaIndexInput, out empresaIndex) && empresaIndex >= 1 && empresaIndex <= empresas.Count)
                            {
                                empresaIndex--;
                                break;
                            }
                            Console.WriteLine("Empresa inválida. [Enter]");
                            Console.ReadKey();
                        }

                        Console.WriteLine();

                        string modelo;
                        while (true)
                        {
                            Console.Write("Modelo: ");
                            modelo = Console.ReadLine();
                            if (modelo == "sair")
                                return;
                            if (!string.IsNullOrWhiteSpace(modelo))
                                break;
                            Console.WriteLine("Modelo não pode ser vazio. [Enter]");
                            Console.ReadKey();
                        }

                        Console.WriteLine();

                        int ano;
                        while (true)
                        {
                            Console.Write("Ano: ");
                            string anoInput = Console.ReadLine();
                            if (anoInput == "sair")
                                return;
                            if (!string.IsNullOrWhiteSpace(anoInput) && int.TryParse(anoInput, out ano))
                                break;
                            Console.WriteLine("Por favor digite um ano válido. [Enter]");
                            Console.ReadKey();
                        }

                        Console.WriteLine();

                        string cor;
                        while (true)
                        {
                            Console.Write("Cor: ");
                            cor = Console.ReadLine();
                            if (cor == "sair")
                                return;
                            if (!string.IsNullOrWhiteSpace(cor))
                                break;
                            Console.WriteLine("Cor não pode ser vazia. [Enter]");
                            Console.ReadKey();
                        }

                        Console.WriteLine();

                        double valor;
                        while (true)
                        {
                            Console.Write("Valor: ");
                            string valorInput = Console.ReadLine();
                            if (valorInput == "sair")
                                return;
                            if (!string.IsNullOrWhiteSpace(valorInput) && double.TryParse(valorInput.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out valor) && valor > 0)
                                break;
                            Console.WriteLine("Por favor digite um valor válido (maior que 0). [Enter]");
                            Console.ReadKey();
                        }

                        bool isDisponivel = true;
                        empresas[empresaIndex].ListaDeIphones.Add(new Iphone(modelo, ano, cor, valor, isDisponivel));
                        Console.WriteLine();
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
        }

        public static void VisualizarInformacoesEmpresas() // Método pra visualizar informações das empresas
        {
            try
            {
                Console.Clear();
                Console.WriteLine("---- Empresas ----");
                Console.WriteLine();
                if (empresas.Count == 0)
                {
                    Console.WriteLine("Nenhuma empresa cadastrada no sistema.");
                }
                else
                {
                    foreach (var empresa in empresas)
                    {
                        empresa.VisualizarInformacoes(); // Chama o método da classe empresa
                        Console.WriteLine();
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

        public static void VisualizarIphonesDisponiveis() // Método pra visualizar os iphones disponíveis
        {
            try
            {
                Console.Clear();
                Console.WriteLine("---- Iphones ----");
                Console.WriteLine();
                bool iphonesDisponiveis = false; 
                foreach (var empresa in empresas)
                {
                    foreach (var iphone in empresa.ListaDeIphones)
                    {
                        if (iphone.IsDisponivel)
                        {
                            iphonesDisponiveis = true;
                            Console.WriteLine($"Modelo: {iphone.Modelo}, Ano: {iphone.Ano}, Cor: {iphone.Cor}, Valor: {iphone.Valor.ToString("F2", CultureInfo.CurrentCulture)}");
                            Console.WriteLine();
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

        public static void VisualizarInformacoesCliente() // Método pra visualizar informações do cliente
        {
            try
            {
                Console.Clear();
                Console.WriteLine("---- Clientes ----");
                Console.WriteLine();
                if (clientes.Count == 0)
                {
                    Console.WriteLine("Nenhum cliente cadastrado");
                }
                else
                {
                    foreach (var cliente in clientes)
                    {
                        cliente.VisualizarInformacoes(); // Chama o método da classe cliente
                        Console.WriteLine();
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

        public static void ComprarIphone() // Método pra realizar compra de um iphone cadastrado
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

                    if (clientes.Count == 0 || empresas.Count == 0) // Caso nenhuma empresa ou cliente esteja cadastrado, pede cadastro de ambos.
                    {
                        Console.WriteLine("Clientes ou empresas não cadastrados. Realize os cadastros antes de prosseguir.");
                        Console.ReadKey();
                        return;
                    }

                    int escolhaCliente;
                    while (true)
                    {
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
                        Console.WriteLine("Cliente inválido. [Enter]");
                        Console.ReadKey();
                    }

                    Console.WriteLine();

                    int escolhaEmpresa;
                    while (true)
                    {
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
                        Console.WriteLine("Empresa inválida. [Enter]");
                        Console.ReadKey();
                    }

                    Console.WriteLine();

                    Empresa empresa = empresas[escolhaEmpresa]; // Obtém a empresa selecionada a partir da lista de empresas
                    Cliente cliente = clientes[escolhaCliente];

                    int escolhaIphone;
                    while (true)
                    {
                        Console.WriteLine("Escolha o iphone:");
                        for (int i = 0; i < empresa.ListaDeIphones.Count; i++)
                        {
                            var iphone = empresa.ListaDeIphones[i];  // Obtém o iPhone da lista de iPhones da empresa
                            if (iphone != null && iphone.IsDisponivel) // Veriificar se o iphone não é nulo é esta disponivel.
                            {
                                Console.WriteLine($"{i + 1} - {iphone.Modelo}, R$ {iphone.Valor} ");
                            }
                            else
                            {
                                Console.WriteLine($"{i + 1} - Esse iphone não está disponível.");
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
                        Console.WriteLine("iPhone inválido. [Enter]");
                        Console.ReadKey();
                    }

                    Console.WriteLine();

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
                    Console.WriteLine();
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
