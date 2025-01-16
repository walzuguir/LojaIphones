using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaIphones
{
    public class Iphone
    {
        public string Modelo { get; set; }
        
        public int Ano { get; set; }

        public string Cor { get; set; }

        public double Valor { get; set; }

        public bool IsDisponivel { get; set; }

        public Iphone(string modelo, int ano, string cor, double valor, bool isDisponivel)
        {
            Modelo = modelo;
            Ano = ano;
            Cor = cor;
            Valor = valor;
            IsDisponivel = isDisponivel;
        }
    }
}
