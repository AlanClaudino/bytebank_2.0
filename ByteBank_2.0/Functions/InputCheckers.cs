using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_2._0.Functions
{
    internal class InputCheckers
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
                Console.Write("  Opcao invalida. Digite Novamente: ");
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
                    Console.Write("  Nome invalido. Por favor, digite novamente: ");
                }
            }
        }

        static public string DigitarSenha()
        {
            string senha = string.Empty;

            while(true)
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
            Console.WriteLine();
            return senha;
        }

        static public int ValidarSenha()
        {
            int result;
            while (true)
            {
                string senha = DigitarSenha();
                if (senha.Length != 4)
                {
                    Console.Write("  Senha invalida. Por favor, digite novamente: ");
                }
                else
                {
                    try
                    {
                        result = int.Parse(senha);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.Write("  Senha invalida. Por favor, digite novamente: ");
                    }
                }
            }
            return result;
        }

        static public string DigitarCPF()
        {
            string Cpf = string.Empty;

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                ConsoleKey key = keyInfo.Key;

                if (key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (key == ConsoleKey.Backspace && Cpf.Length > 0)
                {
                    Console.Write("\b \b");
                    Cpf = Cpf[0..^1];
                }
                else if (char.IsDigit(keyInfo.KeyChar) && Cpf.Length < 11)
                {
                    Cpf += keyInfo.KeyChar;
                    Console.Write(keyInfo.KeyChar);
                }

            }
            Console.WriteLine();
            return Cpf;
        }

        static public string ValidarCpf()
        {
            long result;
            while (true)
            {
                string Cpf = DigitarCPF();
                if (Cpf.Length != 11)
                {
                    Console.Write("  CPF invalido. Por favor, digite novamente: ");
                }
                else
                {
                    try
                    {
                        result = long.Parse(Cpf);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.Write("  CPF invalido. Por favor, digite novamente: ");
                    }
                }
            }
            return result.ToString();
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
                    Console.Write("  Valor invalido. Por favor, digite novamente: ");
                }
                else
                {
                    try
                    {
                        result = decimal.Parse(valor);

                        if (result <= 0)
                        {
                            Console.Write("  Valor invalido. Por favor, digite novamente: ");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Write("  Valor invalido. Por favor, digite novamente: ");
                    }
                }
            }
            return result;
        }
    }
}
