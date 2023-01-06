using System.Drawing;
using ByteBank_2._0.Functions;
using ByteBank_2._0.Models;
using Console = Colorful.Console;

namespace ByteBank_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = Color.PaleGoldenrod;
            List<Clients> clientes = InputOutput.GetClientsDB();
            Admin admin = new Admin("Alan", "admin", 9999);

            bool encerrarPrograma = false;

            while (encerrarPrograma != true)
            {
                MenuInterfaces.MenuInicial();
                string menuInicial = InputValidation.ValidarSelecao("1", "2", "3", "4");

                switch (menuInicial)
                {
                    case "1":
                        InteractiveInterfaces.NovoCliente(clientes);
                        break;
                    case "2":
                        ClientOptions.AcessoConta(clientes);
                        break;
                    case "3":
                        AdminOptions.AcessoAdm(clientes, admin);
                        break;
                    case "4":
                        encerrarPrograma = true;
                        break;
                }
            }

            InputOutput.SalvarUsuariosDB(clientes);


        }
    }
}