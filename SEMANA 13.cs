using System;
using System.Collections.Generic;

namespace CatalogoRevistas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear la lista para el catálogo de revistas
            List<string> catalogoRevistas = new List<string>();
            
            // Ingresar 10 títulos al catálogo
            AgregarRevistasIniciales(catalogoRevistas);
            
            // Mostrar menú y procesar opciones
            MostrarMenu(catalogoRevistas);
        }
        
        static void AgregarRevistasIniciales(List<string> catalogo)
        {
            Console.WriteLine("=== INGRESO DE REVISTAS AL CATÁLOGO ===");
            
            // Agregar 10 títulos al catálogo
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Ingrese el título de la revista #{i+1}: ");
                string titulo = Console.ReadLine();
                catalogo.Add(titulo);
            }
            
            Console.WriteLine("\nSe han agregado 10 revistas al catálogo exitosamente.");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        static void MostrarMenu(List<string> catalogo)
        {
            bool salir = false;
            
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== CATÁLOGO DE REVISTAS ===");
                Console.WriteLine("1. Buscar un título");
                Console.WriteLine("2. Salir");
                Console.Write("\nSeleccione una opción: ");
                
                string opcion = Console.ReadLine();
                
                switch (opcion)
                {
                    case "1":
                        BuscarTitulo(catalogo);
                        break;
                    case "2":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        
        static void BuscarTitulo(List<string> catalogo)
        {
            Console.Clear();
            Console.WriteLine("=== BÚSQUEDA DE TÍTULOS ===");
            Console.Write("Ingrese el título a buscar: ");
            string tituloBuscado = Console.ReadLine();
            
            // Realizar la búsqueda
            bool encontrado = catalogo.Contains(tituloBuscado);
            
            // Mostrar resultado
            if (encontrado)
            {
                Console.WriteLine("\nResultado: Encontrado");
            }
            else
            {
                Console.WriteLine("\nResultado: No encontrado");
            }
            
            Console.WriteLine("\nPresione cualquier tecla para volver al menú principal...");
            Console.ReadKey();
        }
    }
}
