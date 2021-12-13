namespace ConsoleMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;

            do
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Este es el menú, por favor elija una opción:");
                Console.WriteLine("-------------------------------");

                Console.WriteLine("Pulsa 1");
                Console.WriteLine("Pulsa 2");
                Console.WriteLine("Pulsa 3");
                Console.WriteLine("Pulsa 4");
                Console.WriteLine("Para salir => Pulsa 5");

                int.TryParse(Console.ReadLine(), out result);

                switch(result) 
                {
                    case 1:
                        Console.WriteLine("Caso 1");
                        break;
                    case 2:
                        Console.WriteLine("Caso 2");
                        break;
                    case 3:
                        Console.WriteLine("Caso 3");
                        break;
                    case 4:
                        Console.WriteLine("Caso 4");
                        break;
                    default:
                        Console.WriteLine("Hasta pronto!");
                        break;
                }
            } while (result != 5);
        }
    }
}