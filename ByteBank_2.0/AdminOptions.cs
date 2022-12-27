using ByteBank_2._0.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_2._0
{
    internal class AdminOptions
    {
        static public void AcessoAdm(List<Users> Clientes, Admin Admin1)
        {
            bool login = InteractiveInterfaces.MenuAcessoAdm(Admin1);
            while (login)
            {
                string opcao = MenuInterfaces.MenuOperacoesAdm(Admin1.Nome);
                switch (opcao)
                {
                    case "1":
                        login = MenuInterfaces.MenuListaClientes(Clientes);
                        break;
                    case "2":
                        login = MenuInterfaces.MenuListaContas(Clientes);
                        break;
                    case "3":
                        login = InteractiveInterfaces.ExclusaoDeContaAdm(Clientes, Admin1);
                        break;
                    case "4":
                        InteractiveInterfaces.AlterarSenhaAdm(Clientes, Admin1);
                        break;
                    case "5":
                        login = false;
                        break;

                }
            }
        }
    }
}
