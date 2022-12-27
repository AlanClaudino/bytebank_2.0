using ByteBank_2._0.Functions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace ByteBank_2._0
{
    internal class MenuInterfaces
    {
        static public void Title()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("   Banco ARC", Color.LightSeaGreen);
            Console.WriteLine("  -----------", Color.LightSeaGreen);
        }
        static public void MenuInicial()
        {
            Title();
            Console.WriteLine("  Menu Inicial");
            Console.WriteLine();
            Console.Write("  [1] ", Color.LightSeaGreen);
            Console.WriteLine("Abrir conta");
            Console.Write("  [2] ", Color.LightSeaGreen);
            Console.WriteLine("Acessar conta");
            Console.Write("  [3] ", Color.LightSeaGreen);
            Console.WriteLine("Acessar como administrador");
            Console.Write("  [4] ", Color.LightSeaGreen);
            Console.WriteLine("Encerrar programa");
            System.Console.WriteLine();
            Console.Write("  Digite a opção selecionada: ");
        }

        static public string MenuOperacoes(string Name)
        {
            Title();
            Console.WriteLine($"  Olá {Name}, bem-vindo ao Espaço do Cliente.");
            Console.WriteLine();
            Console.Write("  [1] ", Color.LightSeaGreen);
            Console.WriteLine("Consultar saldo");
            Console.Write("  [2] ", Color.LightSeaGreen);
            Console.WriteLine("Realizar depósito");
            Console.Write("  [3] ", Color.LightSeaGreen);
            Console.WriteLine("Realizar saque");
            Console.Write("  [4] ", Color.LightSeaGreen);
            Console.WriteLine("Encerrar conta");
            Console.Write("  [5] ", Color.LightSeaGreen);
            Console.WriteLine("Sair");
            Console.WriteLine();
            Console.Write("  Digite a opção selecionada: ");
            string opcao = InputCheckers.ValidarSelecao("1", "2", "3", "4", "5");

            return opcao;
        }

        static public bool MenuSaldo(Users usuario)
        {
            Title();
            Console.WriteLine("  Espaço do Cliente - Saldo");
            Console.WriteLine();
            usuario.MostrarSaldo();
            Console.WriteLine();
            Console.Write("  [1] ", Color.LightSeaGreen);
            Console.WriteLine("Retornar ao Espaço do Cliente");
            Console.Write("  [2] ", Color.LightSeaGreen);
            Console.WriteLine("Encerrar atendimento");
            System.Console.WriteLine();
            Console.Write("  Digite a opção selecionada: ");
            string opcao = InputCheckers.ValidarSelecao("1", "2");
            if (opcao == "2") { return false; } else return true;
        }

        static public string MenuOperacoesAdm(string Name)
        {
            Title();
            Console.WriteLine($"  Olá {Name}, bem-vindo ao Espaço do Administrador.");
            Console.WriteLine();
            Console.Write("  [1] ", Color.LightSeaGreen);
            Console.WriteLine("Listar de clientes");
            Console.Write("  [2] ", Color.LightSeaGreen);
            Console.WriteLine("Listar de contas - detalhes");
            Console.Write("  [3] ", Color.LightSeaGreen);
            Console.WriteLine("Excluir conta");
            Console.Write("  [4] ", Color.LightSeaGreen);
            Console.WriteLine("Alterar senha de acesso");
            Console.Write("  [5] ", Color.LightSeaGreen);
            Console.WriteLine("Sair");
            Console.WriteLine();
            Console.Write("  Digite a opcao selecionada: ");
            string opcao = InputCheckers.ValidarSelecao("1", "2", "3", "4", "5");

            return opcao;
        }

        static public bool MenuListaClientes(List<Users> usuarios)
        {
            Title();
            Console.WriteLine("  Espaço do Administrador - Clientes");
            Console.WriteLine();

            var table = new ConsoleTables.ConsoleTable("Cliente", "CPF");
            foreach (Users u in usuarios)
            {
                table.AddRow(u.Nome, u.Cpf);
            }
            table.Write();

            Console.WriteLine();
            string opcao = Utilidades.MensagemRetornarMenu("Espaço do Administrador");
            if (opcao == "2") { return false; } else return true;
        }

        static public bool MenuListaContas(List<Users> usuarios)
        {
            Title();
            Console.WriteLine("  Espaço do Administrador - Contas");
            Console.WriteLine();

            var table = new ConsoleTables.ConsoleTable("Cliente", "CPF", "Saldo");
            foreach (Users u in usuarios)
            {
                table.AddRow(u.Nome, u.Cpf, u.Saldo);
            }
            table.Write();

            string opcao = Utilidades.MensagemRetornarMenu("Espaço do Administrador");
            if (opcao == "2") { return false; } else return true;
        }

    }
}
