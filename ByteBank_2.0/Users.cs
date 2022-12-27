using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace ByteBank_2._0
{
    internal class Users
    {
        public string Nome { get; set; }
        public string Cpf { get; set;}
        public int Senha { get; set; }
        public decimal Saldo { get; set; }
        public Users() { }

        public Users(string aNome, string aCpf, int aSenha)
        {
            Nome = aNome;
            Cpf = aCpf;
            Senha = aSenha;
            Saldo = 0.00m;
        }

        public void Depositar(decimal aDeposito) {
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

    internal class Admin
    {
        public string Nome { get; set; }
        public string NomeDeUsuario { get; set; }
        public int Senha { get; set; }
        public Admin() { }
        public Admin(string aNome, string aNomeDeUsuario, int aSenha) 
        {
            Nome = aNome;
            NomeDeUsuario= aNomeDeUsuario;
            Senha = aSenha;
        }

    }
}
