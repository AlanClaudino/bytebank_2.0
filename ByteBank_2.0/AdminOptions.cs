using ByteBank_2._0.Functions;
using ByteBank_2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_2._0
{
    internal class AdminOptions
    {
        static public void AcessoAdm(List<Clients> clientes, Admin admin1)
        {
            bool login = InteractiveInterfaces.MenuAcessoAdm(admin1);
            while (login)
            {
                string opcao = MenuInterfaces.MenuOperacoesAdm(admin1.Nome);
                switch (opcao)
                {
                    case "1":
                        login = MenuInterfaces.MenuListaClientes(clientes);
                        break;
                    case "2":
                        login = MenuInterfaces.MenuListaContas(clientes);
                        break;
                    case "3":
                        login = InteractiveInterfaces.ExclusaoDeContaAdm(clientes, admin1);
                        break;
                    case "4":
                        InteractiveInterfaces.AlterarSenhaAdm(clientes, admin1);
                        break;
                    case "5":
                        login = false;
                        break;

                }
            }
        }
    }
}
