using System;

namespace AgenciaBancaria.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var conta1 = new ContaCorrente(1000, 5000, true);

                var conta2 = new ContaCorrente(2500, 7000, true);

                conta1.Depositar(420);

                conta1.Sacar(1500);

                conta1.Transferir(250, conta2);


                conta2.Depositar(180);

                conta2.Sacar(500);

                conta2.Transferir(120, conta1);


                Console.Clear();

                Console.WriteLine();

                Console.WriteLine(conta1.MostrarExtrato());

                Console.WriteLine();

                Console.WriteLine(conta2.MostrarExtrato());

                Console.WriteLine();

                Console.WriteLine();

                Console.WriteLine(conta1.MostrarSaldo());

                Console.WriteLine();

                Console.WriteLine(conta2.MostrarSaldo());

                Console.WriteLine();
            }
            catch (System.Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
            }

        }
    }
}

