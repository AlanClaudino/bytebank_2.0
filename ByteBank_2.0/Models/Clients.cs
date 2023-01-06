using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace ByteBank_2._0.Models
{
    internal class Clients
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Senha { get; set; }
        public string NumeroConta { get; set; }
        public decimal Saldo { get; set; }
        public Clients() { }

        public Clients(string aNome, string aCpf, int aSenha, string ultimaConta = "1000-000")
        {
            Nome = aNome;
            Cpf = aCpf;
            Senha = aSenha;
            Saldo = 0.00m;
            NumeroConta = $"1000-{(int.Parse(ultimaConta[6..]) + 1).ToString().PadLeft(3, '0')}";
        }

        public void Depositar(decimal aDeposito)
        {
            Saldo += aDeposito;
        }

        public void Sacar(decimal aSaque)
        {
            Saldo -= aSaque;
        }

        public void MostrarSaldo()
        {
            Console.Write($"  Saldo disponivel: ", Color.LightSeaGreen);
            Console.WriteLine($"R$ {Saldo}");
        }
    }
}
