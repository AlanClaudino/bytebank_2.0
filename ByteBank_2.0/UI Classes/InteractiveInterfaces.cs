using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ByteBank_2._0.Functions;
using Console = Colorful.Console;

namespace ByteBank_2._0
{
    internal class InteractiveInterfaces
    {
        static public void NovoCliente(List<Users> Clientes)
        {
            MenuInterfaces.Title(); 
            Console.WriteLine("  Cadastro de Contas");
            Console.WriteLine();
            Console.Write("  Nome: ", Color.LightSeaGreen);
            string Nome = InputCheckers.ValidarNome();

            Console.Write("  CPF (11 dígitos numéricos): ", Color.LightSeaGreen);
            string Cpf = InputCheckers.ValidarCpf();

            Console.Write("  Senha (4 dígitos numéricos): ", Color.LightSeaGreen);
            int senha = InputCheckers.ValidarSenha();

            int IsClient = Clientes.FindIndex(p => p.Cpf == Cpf);
            
            if (IsClient == -1)
            {
                Users User1 = new Users(Nome, Cpf, senha);
                Clientes.Add(User1);
                Utilidades.MensagemNovaConta(Nome);

            }
            else { Utilidades.MensagemContaExistente(); }
        }

        static public int Acesso(List<Users> Clientes)
        {
            int index;
            while (true)
            {
                MenuInterfaces.Title();
                Console.WriteLine("  Acesso - Espaço do Cliente");
                Console.WriteLine();

                Console.Write("  CPF: ", Color.LightSeaGreen);
                string Cpf = InputCheckers.ValidarCpf();

                Console.Write("  Senha: ", Color.LightSeaGreen);
                int senha = InputCheckers.ValidarSenha();


                int isClient = Clientes.FindIndex(p => p.Cpf == Cpf);

                if (isClient == -1)
                {
                    Console.WriteLine();
                    Console.WriteLine("  CPF nao cadastrado ou senha incorreta.");
                    string opcao = Utilidades.MensagemMenuErro("Menu Inicial");
                    if (opcao == "2") { return isClient; }
                }
                else if (senha != Clientes[isClient].Senha)
                {
                    Console.WriteLine();
                    Console.WriteLine("  CPF nao cadastrado ou senha incorreta");
                    string opcao = Utilidades.MensagemMenuErro("Menu Inicial");
                    if (opcao == "2") { return isClient; }
                }
                else
                {
                    index = isClient;
                    break;
                }

            }
            return index;
        }

        static public bool MenuDeposito(Users usuario)
        {
            MenuInterfaces.Title();
            Console.WriteLine("  Espaço do Cliente - Depósito");
            Console.WriteLine();
            Console.Write("  Valor (R$): ", Color.LightSeaGreen);
            decimal valor = InputCheckers.ValidarDecimal();
            usuario.Depositar(valor);
            Console.WriteLine();
            Console.WriteLine("  Deposito realizado com sucesso!");
            usuario.MostrarSaldo();
            string opcao = Utilidades.MensagemRetornarMenu("Espaço do Cliente");
            if (opcao == "2") { return false; } else return true;
        }

        static public bool MenuSaque(Users usuario)
        {
            bool verificadorSaldo = true;
            decimal valor = 0;

            while (verificadorSaldo)
            {
                MenuInterfaces.Title();
                Console.WriteLine("  Espaço do Cliente - Saque");
                Console.WriteLine();
                usuario.MostrarSaldo();
                Console.WriteLine();
                Console.Write("  Valor (R$): ", Color.LightSeaGreen);
                valor = InputCheckers.ValidarDecimal();
                if (usuario.Saldo < valor)
                {
                    Console.WriteLine();
                    Console.WriteLine("  Saldo insuficiente. Por favor, selecione outro valor.");
                    string opcaoSaldo = Utilidades.MensagemMenuErro("Espaço do Cliente");
                    if (opcaoSaldo == "2") { return true; };
                }
                else { verificadorSaldo = false; }
            }

            usuario.Sacar(valor);
            Console.WriteLine();
            Console.WriteLine("  Saque realizado com sucesso!");
            usuario.MostrarSaldo();
            string opcao = Utilidades.MensagemRetornarMenu("Espaço do Cliente");
            if (opcao == "2") { return false; } else return true;
        }

        static public bool ExclusaoDeConta(List<Users> Clientes , int Index)
        {
            bool excluir = false;
            
            while (true)
            {
                MenuInterfaces.Title();
                Console.WriteLine("  Espaço do Cliente - Encerrar Conta");
                Console.WriteLine();

                Console.Write("  CPF: ", Color.LightSeaGreen);
                string Cpf = InputCheckers.ValidarCpf();

                Console.Write("  Senha: ", Color.LightSeaGreen);
                int senha = InputCheckers.ValidarSenha();

                if (Cpf == Clientes[Index].Cpf && senha == Clientes[Index].Senha)
                {
                    if(Clientes[Index].Saldo == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("  Tem certeza que deseja excluir a sua conta?");
                        Console.WriteLine();
                        Console.Write("  [1] ", Color.LightSeaGreen);
                        Console.WriteLine("Sim");
                        Console.Write("  [2] ", Color.LightSeaGreen);
                        Console.WriteLine("Nao");
                        Console.WriteLine();
                        Console.Write("  Digite a opcao selecionada: ");
                        string opcao = InputCheckers.ValidarSelecao("1", "2");
                        if (opcao == "1")
                        {
                            excluir = true;
                            break;
                        }
                        else
                        {
                            excluir = false;
                            break;
                        }
                    }
                    else if (Clientes[Index].Saldo > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"  {Clientes[Index].Nome}, você possui saldo em sua conta.");
                        Console.WriteLine("  Por favor, faça o saque do valor antes de encerrar a sua conta.");
                        Console.WriteLine();
                        Console.Write("  Pressione Enter para retornar ao menu anterior.");
                        Console.ReadLine();
                        return true;

                    }

                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("  CPF ou senha inválidos.");
                    string opcao = Utilidades.MensagemMenuErro("Espaço do Cliente");
                    if (opcao == "2") { return true; }
                }

            }

            if (excluir)
            {
                Clientes.Remove(Clientes[Index]);
                Utilidades.MensagemContaExcluida("Menu Inicial");
            }

            return !excluir;
        }

        static public bool MenuAcessoAdm(Admin aAdmin)
        {
            while (true)
            {

                MenuInterfaces.Title();
                Console.WriteLine("  Acesso - Espaço do Administrador");
                Console.WriteLine();
                Console.Write("  Nome de usuario: ", Color.LightSeaGreen);
                string Nome = InputCheckers.ValidarNome();

                Console.Write("  Senha: ", Color.LightSeaGreen);
                int senha = InputCheckers.ValidarSenha();

                if (aAdmin.NomeDeUsuario == Nome && aAdmin.Senha == senha)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("  Usuario ou senha inválidos.");
                    Console.WriteLine();
                    Console.Write("  [1] ", Color.LightSeaGreen);
                    Console.WriteLine("Tente novamente");
                    Console.Write("  [2] ", Color.LightSeaGreen);
                    Console.WriteLine("Retorne ao Menu Inicial");
                    Console.WriteLine();
                    Console.Write("  Digite a opcao selecionada: ");
                    string opcao = InputCheckers.ValidarSelecao("1", "2");
                    if (opcao == "2") { return false; }
                }
            }
        }

        static public bool ExclusaoDeContaAdm(List<Users> Clientes, Admin admin)
        {
            bool excluir;
            int index;

            while (true)
            {
                MenuInterfaces.Title();
                Console.WriteLine("  Espaço do Administrador - Encerrar Conta");
                Console.WriteLine();

                Console.Write("  CPF do titular: ", Color.LightSeaGreen);
                string Cpf = InputCheckers.ValidarCpf();

                index = Clientes.FindIndex(p => p.Cpf == Cpf);
                if (index == -1)
                {
                    Console.WriteLine();
                    Console.WriteLine("  Número de CPF inválido.");
                    string opcao = Utilidades.MensagemMenuErro("Espaço do Administrador");
                    if (opcao == "2") { return true; }

                }
                else
                {
                    Console.Write("  Senha Administrador: ", Color.LightSeaGreen);
                    int senha = InputCheckers.ValidarSenha();

                    if (senha == admin.Senha)
                    {
                        Console.WriteLine();
                        Console.WriteLine("  Tem certeza que deseja excluir essa conta?");
                        Console.WriteLine();
                        Console.Write("  [1] ", Color.LightSeaGreen);
                        Console.WriteLine("Sim");
                        Console.Write("  [2] ", Color.LightSeaGreen);
                        Console.WriteLine("Nao");
                        Console.WriteLine();
                        Console.Write("  Digite a opcao selecionada: ");
                        string opcao = InputCheckers.ValidarSelecao("1", "2");
                        if (opcao == "1") { 
                            excluir = true;
                            break;
                        } else 
                        { 
                            excluir = false; 
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("  Senha inválida.");
                        string opcao = Utilidades.MensagemMenuErro("Espaço do Administrador");
                        if (opcao == "2") { return true; }
                    }

                }

            }

            if (excluir)
            {
                Clientes.Remove(Clientes[index]);
                Utilidades.MensagemContaExcluida("Espaço do Administrador");
            }

            return true;
        }

        static public void AlterarSenhaAdm(List<Users> usuarios, Admin admin)
        {
            while (true)
            {
                MenuInterfaces.Title();
                Console.WriteLine("  Espaço do Administrador - Alterar Senhas");
                Console.WriteLine();

                Console.Write("  CPF do titular: ", Color.LightSeaGreen);
                string Cpf = InputCheckers.ValidarCpf();

                int index = usuarios.FindIndex(p => p.Cpf == Cpf);
                if (index == -1)
                {
                    Console.WriteLine();
                    Console.WriteLine("  Número de CPF inválido.");
                    string opcao = Utilidades.MensagemMenuErro("Espaço do Administrador");
                    if (opcao == "2") break;

                }
                else
                {
                    Console.WriteLine();
                    Console.Write("  Nova Senha (4 dígitos numéricos): ", Color.LightSeaGreen);
                    int senha = InputCheckers.ValidarSenha();

                    Console.WriteLine();
                    Console.Write("  Senha Administrador: ", Color.LightSeaGreen);
                    int senhaAdm = InputCheckers.ValidarSenha();

                    if (senhaAdm == admin.Senha)
                    {
                        Console.WriteLine();
                        Console.WriteLine("  Tem certeza que deseja alterar essa senha?");
                        Console.WriteLine();
                        Console.Write("  [1] ", Color.LightSeaGreen);
                        Console.WriteLine("Sim");
                        Console.Write("  [2] ", Color.LightSeaGreen);
                        Console.WriteLine("Nao");
                        Console.WriteLine();
                        Console.Write("  Digite a opção selecionada: ");
                        string opcao = InputCheckers.ValidarSelecao("1", "2");
                        if (opcao == "2") { return; }
                        else
                        {
                            usuarios[index].Senha = senha;
                            Utilidades.MensagemSenhaAlterada();
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("  Senha de Administrador inválida");
                        string opcao = Utilidades.MensagemMenuErro("Espaço do Administrador");

                        if (opcao == "2") { return; }
                    }
                }
            }
        }
    }
}
