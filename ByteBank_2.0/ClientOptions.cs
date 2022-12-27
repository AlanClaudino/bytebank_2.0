using ByteBank_2._0.Functions;
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
        static public void AcessoConta(List<Users> Clientes)
        {
            bool loggedIn = false;
            int index = InteractiveInterfaces.Acesso(Clientes);

            if (index >= 0) { loggedIn = true; }

            while (loggedIn == true)
            {

                string opcao = MenuInterfaces.MenuOperacoes(Clientes[index].Nome);
                switch (opcao)
                {
                    case "1":
                        loggedIn = MenuInterfaces.MenuSaldo(Clientes[index]);
                        break;
                    case "2":
                        loggedIn = InteractiveInterfaces.MenuDeposito(Clientes[index]);
                        break;
                    case "3":
                        loggedIn = InteractiveInterfaces.MenuSaque(Clientes[index]);
                        break;
                    case "4":
                        loggedIn = InteractiveInterfaces.ExclusaoDeConta(Clientes, index);
                        break;
                    case "5":
                        loggedIn = false;
                        break;

                }
            }
        }
    }
}
