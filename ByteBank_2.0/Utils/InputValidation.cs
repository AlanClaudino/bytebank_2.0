using ByteBank_2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_2._0.Functions
{
    internal class InputValidation
    {

        static public string DigitarOpcao()
        {
            string opcao  = string.Empty;

            while(true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                ConsoleKey key = keyInfo.Key;

                if (key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (key == ConsoleKey.Backspace && opcao.Length > 0)
                {
                    Console.Write("\b \b");
                    opcao = opcao[0..^1];
                }
                else if (char.IsDigit(keyInfo.KeyChar) && opcao.Length < 1)
                {
                    opcao += keyInfo.KeyChar;
                    Console.Write(keyInfo.KeyChar);
                }

            }
            Console.WriteLine();
            return opcao;
        }
        
        static public string ValidarSelecao(params string[] menu)
        {
            while (true)
            {
                string valor = DigitarOpcao();

                foreach (string s in menu)
                {
                    if (valor == s)
                    {
                        return valor;
                    }
                }
                Console.Write("  Opcao inválida. Digite Novamente: ");
            }

        }

        static public string ValidarNome()
        {
            while (true)
            {
                string nome = Console.ReadLine();
                if (nome.Length >= 1)
                {
                    return nome;
                }
                else
                {
                    Console.Write("  Nome inválido. Por favor, digite novamente: ");
                }
            }
        }

        static public bool ValidarSenha(int aSenha)
        {
            string senha = aSenha.ToString();
            if (senha.Length != 4)
            {
                Console.WriteLine();
                Console.Write("  Senha inválida. Por favor, digite novamente: ");
                return false;
            }
            else
            {
                return true;
            }
        }

        static public int DigitarSenha()
        {
            bool isValid = false;
            int senhaValida = 0;
            while (!isValid)
            {
                string senha = string.Empty;

                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    ConsoleKey key = keyInfo.Key;

                    if (key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else if (key == ConsoleKey.Backspace && senha.Length > 0)
                    {
                        Console.Write("\b \b");
                        senha = senha[0..^1];
                    }
                    else if (char.IsDigit(keyInfo.KeyChar) && senha.Length < 4)
                    {
                        senha += keyInfo.KeyChar;
                        Console.Write('*');
                    }

                }

                senhaValida = int.Parse(senha);
                isValid = ValidarSenha(senhaValida);
            }
            Console.WriteLine();
            return senhaValida;
        }

        static public bool ValidarConta(string aConta)
        {
            string conta = aConta;
            if (conta.Length != 8)
            {
                Console.WriteLine();
                Console.Write("  Conta inválida. Por favor, digite novamente: ");
                return false;
            }
            else
            {
                return true;
            }
        }

        static public string DigitarConta()
        {
            string conta = string.Empty;
            bool isValid = false;

            while(!isValid)
            {
                conta = string.Empty;
                
                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    ConsoleKey key = keyInfo.Key;

                    if (key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else if (key == ConsoleKey.Backspace && conta.Length > 0)
                    {
                        Console.Write("\b \b");
                        conta = conta[0..^1];
                    }
                    else if (char.IsDigit(keyInfo.KeyChar) && conta.Length < 8)
                    {
                        if (conta.Length == 4)
                        {
                            conta += "-";
                            Console.Write("-");
                        }
                        conta += keyInfo.KeyChar;
                        Console.Write(keyInfo.KeyChar);
                    }
                }
                isValid = ValidarConta(conta);
            }
            Console.WriteLine();
            return conta;
        }

        static public bool ValidarCpf(string aCpf)
        {
            string conta = aCpf;
            if (conta.Length != 12)
            {
                Console.WriteLine();
                Console.Write("  CPF inválido. Por favor, digite novamente: ");
                return false;
            }
            else
            {
                return true;
            }
        }

        static public string DigitarCPF()
        {
            bool isValid = false;
            string cpf = string.Empty;

            while (!isValid)
            {
                cpf = string.Empty;
                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    ConsoleKey key = keyInfo.Key;

                    if (key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else if (key == ConsoleKey.Backspace && cpf.Length > 0)
                    {
                        Console.Write("\b \b");
                        cpf = cpf[0..^1];
                    }
                    else if (char.IsDigit(keyInfo.KeyChar) && cpf.Length < 12)
                    {
                        if (cpf.Length == 9)
                        {
                            cpf += "-";
                            Console.Write("-");
                        }
                        cpf += keyInfo.KeyChar;
                        Console.Write(keyInfo.KeyChar);
                    }
                }
                isValid = ValidarCpf(cpf);
            }
            Console.WriteLine();
            return cpf;
        }

        static public decimal ValidarDecimal()
        {
            decimal result;
            while (true)
            {
                string valor = Console.ReadLine();
                string[] valores = valor.Split('.');

                if (valores.Length > 1 && valores[1].Length > 2)
                {
                    Console.Write("  Valor inválido. Por favor, digite novamente: ");
                }
                else
                {
                    try
                    {
                        result = decimal.Parse(valor);

                        if (result <= 0)
                        {
                            Console.Write("  Valor inválido. Por favor, digite novamente: ");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Write("  Valor inválido. Por favor, digite novamente: ");
                    }
                }
            }
            return result;
        }
    }
}
