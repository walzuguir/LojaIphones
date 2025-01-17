﻿using System;
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



        public void EfetuarCompra(Iphone iphone, Empresa empresa)
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
                Console.WriteLine($"Você adquiriu o {iphone.Modelo}, obrigado por comprar na {empresa.NomeEmpresa}.");
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
            Console.WriteLine($"Cpf: {FormatarCpf(Cpf)}");
            if (Saldo > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Saldo: {Saldo.ToString("F2")}");
                Console.ResetColor();
                Console.WriteLine("--------------------");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Saldo: {Saldo.ToString("F2")}");
                Console.ResetColor();
                Console.WriteLine("--------------------");
            }

            if (ListaDeIphones.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"O usuário {Nome} não adquiriu nenhum iPhone.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"Iphones adquiridos por {Nome}: ");
                foreach (var iphone in ListaDeIphones)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{iphone.Modelo}");
                    Console.ResetColor();
                    Console.WriteLine("--------------------");
                }
            }
        }



        private string FormatarCpf(string cpf)
        {
            if (cpf.Length == 11)
            {
                return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
            }
            return cpf;
        }
    }
}
