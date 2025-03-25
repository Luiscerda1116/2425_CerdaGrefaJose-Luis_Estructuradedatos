using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n--- Menú de Árbol Binario ---");
            Console.WriteLine("1. Insertar valor");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Console.Write("Ingrese un valor: ");
                string valor = Console.ReadLine();
                Console.WriteLine($"Valor ingresado: {valor}");
            }
            else if (opcion == "2")
            {
                break;
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }
    }
}
