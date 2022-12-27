using System.Drawing;
using ByteBank_2._0.Functions;
using Console = Colorful.Console;

namespace ByteBank_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = Color.PaleGoldenrod;
            List<Users> Clientes = InputOutput.GetClientsDB();
            Admin Admin = new Admin("Alan", "admin", 9999);

            bool EncerrarPrograma = false;

            while (EncerrarPrograma != true)
            {
                MenuInterfaces.MenuInicial();
                string MenuInicial = InputCheckers.ValidarSelecao("1", "2", "3", "4");

                switch (MenuInicial)
                {
                    case "1":
                        InteractiveInterfaces.NovoCliente(Clientes);
                        break;
                    case "2":
                        ClientOptions.AcessoConta(Clientes);
                        break;
                    case "3":
                        AdminOptions.AcessoAdm(Clientes, Admin);
                        break;
                    case "4":
                        EncerrarPrograma = true;
                        break;
                }
            }

            InputOutput.SalvarUsuariosDB(Clientes);


        }
    }
}