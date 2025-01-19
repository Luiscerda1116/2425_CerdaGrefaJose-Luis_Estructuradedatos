using System;

class Nodo
{
    public int dato;
    public Nodo siguiente;

    public Nodo(int valor)
    {
        dato = valor;
        siguiente = null;
    }
}

class ListaEnlazada
{
    private Nodo inicio;

    public ListaEnlazada()
    {
        inicio = null;
    }

    // Método para agregar elementos al final de la lista
    public void Agregar(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor);
        if (inicio == null)
        {
            inicio = nuevoNodo;
        }
        else
        {
            Nodo actual = inicio;
            while (actual.siguiente != null)
            {
                actual = actual.siguiente;
            }
            actual.siguiente = nuevoNodo;
        }
    }

    // Método para invertir la lista
    public void Invertir()
    {
        Nodo anterior = null;
        Nodo actual = inicio;
        Nodo siguiente = null;

        while (actual != null)
        {
            // Guardamos el siguiente nodo
            siguiente = actual.siguiente;
            
            // Invertimos el enlace del nodo actual
            actual.siguiente = anterior;
            
            // Avanzamos los punteros
            anterior = actual;
            actual = siguiente;
        }
        
        // El último nodo ahora es el primero
        inicio = anterior;
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

class Program
{
    static void Main(string[] args)
    {
        ListaEnlazada lista = new ListaEnlazada();

        // Agregamos algunos elementos de prueba
        lista.Agregar(1);
        lista.Agregar(2);
        lista.Agregar(3);
        lista.Agregar(4);
        lista.Agregar(5);

        // Mostramos la lista original
        Console.WriteLine("Lista Original:");
        lista.MostrarLista();

        // Invertimos la lista
        lista.Invertir();

        // Mostramos la lista invertida
        Console.WriteLine("\nLista Invertida:");
        lista.MostrarLista();

        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }
}