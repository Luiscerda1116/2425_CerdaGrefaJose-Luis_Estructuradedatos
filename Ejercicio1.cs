using System;

namespace ListaEnlazadaSimple
{
    // Primero definimos la clase Nodo de forma independiente
    public class Nodo
    {
        public int dato;
        public Nodo siguiente;

        // Constructor de Nodo
        public Nodo(int valor)
        {
            dato = valor;
            siguiente = null;
        }
    }

    // Luego definimos la clase Lista
    public class Lista
    {
        private Nodo inicio;

        // Constructor de Lista
        public Lista()
        {
            inicio = null;
        }

        // Método para agregar elementos
        public void Agregar(int valor)
        {
            Nodo nuevoNodo = new Nodo(valor);

            if (inicio == null)
            {
                inicio = nuevoNodo;
                return;
            }

            Nodo actual = inicio;
            while (actual.siguiente != null)
            {
                actual = actual.siguiente;
            }
            actual.siguiente = nuevoNodo;
        }

        // Método para contar elementos
        public int ContarElementos()
        {
            int contador = 0;
            Nodo actual = inicio;

            while (actual != null)
            {
                contador++;
                actual = actual.siguiente;
            }

            return contador;
        }

        // Método para mostrar la lista
        public void MostrarLista()
        {
            if (inicio == null)
            {
                Console.WriteLine("La lista está vacía");
                return;
            }

            Nodo actual = inicio;
            while (actual != null)
            {
                Console.Write(actual.dato + " -> ");
                actual = actual.siguiente;
            }
            Console.WriteLine("null");
        }
    }

    // Clase principal del programa
    class Program
    {
        static void Main(string[] args)
        {
            // Crear una nueva lista
            Lista miLista = new Lista();

            // Agregar elementos
            miLista.Agregar(10);
            miLista.Agregar(20);
            miLista.Agregar(30);
            miLista.Agregar(40);

            // Mostrar la lista
            Console.WriteLine("Elementos de la lista:");
            miLista.MostrarLista();

            // Mostrar cantidad de elementos
            Console.WriteLine("\nNúmero de elementos en la lista: " + miLista.ContarElementos());

            // Esperar a que el usuario presione una tecla
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}