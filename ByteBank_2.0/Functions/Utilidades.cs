using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace ByteBank_2._0.Functions
{
    internal class Utilidades
    {
        static public void MensagemNovaConta(string Nome)
        {
            Console.WriteLine();
            Console.WriteLine($"  Parabens {Nome}! A sua conta foi criada com sucesso.");
            Console.Write("  Pressione Enter para retornar ao Menu inicial. ");
            Console.ReadLine();
        }

        static public void MensagemContaExistente()
        {
            Console.WriteLine();
            Console.WriteLine("  Você já possui uma conta cadastrada.");
            Console.Write("  Pressione Enter para retornar ao Menu Inicial. ");
            Console.ReadLine();
        }

        static public void MensagemContaExcluida(string NomeMenu)
        {
            Console.WriteLine();
            Console.WriteLine("  Conta encerrada com sucesso!");
            Console.Write($"  Pressione enter retornar ao {NomeMenu}. ");
            Console.ReadLine();
        }

        static public void MensagemSenhaAlterada()
        {
            Console.WriteLine();
            Console.WriteLine("  Senhas alterada com sucesso!");
            Console.Write("  Pressione enter retornar ao Espaço do Administrador. ");
            Console.ReadLine();
        }

        static public string MensagemMenuErro(string NomeMenu)
        {
            Console.WriteLine();
            Console.Write("  [1] ", Color.LightSeaGreen);
            Console.WriteLine("Tente novamente");
            Console.Write("  [2] ", Color.LightSeaGreen);
            Console.WriteLine($"Retorne ao {NomeMenu}");
            System.Console.WriteLine();
            Console.Write("  Digite a opção selecionada: ");
            return InputCheckers.ValidarSelecao("1", "2");
        }

        static public string MensagemRetornarMenu(string NomeMenu)
        {
            System.Console.WriteLine();
            Console.Write("  [1] ", Color.LightSeaGreen);
            Console.WriteLine($"Retornar ao {NomeMenu}");
            Console.Write("  [2] ", Color.LightSeaGreen);
            Console.WriteLine("Encerrar atendimento");
            System.Console.WriteLine();
            Console.Write("  Digite a opção selecionada: ");
            return InputCheckers.ValidarSelecao("1", "2");
        }

    }
}
