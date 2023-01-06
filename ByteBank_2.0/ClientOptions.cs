using ByteBank_2._0.Functions;
using ByteBank_2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_2._0
{
    internal class ClientOptions
    {
        static public void AcessoConta(List<Clients> clientes)
        {
            bool loggedIn = false;
            int index = InteractiveInterfaces.Acesso(clientes);

            if (index >= 0) { loggedIn = true; }

            while (loggedIn == true)
            {

                string opcao = MenuInterfaces.MenuOperacoes(clientes[index].Nome);
                switch (opcao)
                {
                    case "1":
                        loggedIn = MenuInterfaces.MenuSaldo(clientes[index]);
                        break;
                    case "2":
                        loggedIn = InteractiveInterfaces.MenuDeposito(clientes[index]);
                        break;
                    case "3":
                        loggedIn = InteractiveInterfaces.MenuSaque(clientes[index]);
                        break;
                    case "4":
                        loggedIn = InteractiveInterfaces.MenuTransferencia(clientes[index], clientes);
                        break;
                    case "5":
                        loggedIn = InteractiveInterfaces.ExclusaoDeConta(clientes, index);
                        break;
                    case "6":
                        loggedIn = false;
                        break;

                }
            }
        }
    }
}
