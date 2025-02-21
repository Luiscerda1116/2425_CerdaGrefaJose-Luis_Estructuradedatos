using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public class Ciudadano
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Id { get; set; }
    }

    static void Main()
    {
        // Crear lista de nombres y apellidos para generar datos aleatorios
        string[] nombres = {
            "Juan", "María", "Pedro", "Ana", "Luis", "Carmen", "José", "Isabel", "Miguel",
            "Rosa", "Carlos", "Laura", "Francisco", "Patricia", "Antonio", "Sofia", "Alberto",
            "Lucia", "Fernando", "Victoria", "Diego", "Elena", "Javier", "Monica", "Ricardo"
        };

        string[] apellidos = {
            "García", "Rodríguez", "López", "Martínez", "González", "Pérez", "Sánchez",
            "Ramírez", "Torres", "Flores", "Rivera", "Gómez", "Díaz", "Cruz", "Hernández",
            "Morales", "Rojas", "Acosta", "Medina", "Castro", "Silva", "Vargas", "Ortiz"
        };

        // Generar conjunto total de ciudadanos
        Random rnd = new Random();
        HashSet<Ciudadano> todosLosCiudadanos = new HashSet<Ciudadano>();

        for (int i = 0; i < 500; i++)
        {
            Ciudadano ciudadano = new Ciudadano
            {
                Nombre = nombres[rnd.Next(nombres.Length)],
                Apellido = apellidos[rnd.Next(apellidos.Length)],
                Id = (i + 1).ToString("D8")
            };
            todosLosCiudadanos.Add(ciudadano);
        }

        // Seleccionar aleatoriamente ciudadanos para cada vacuna
        List<Ciudadano> ciudadanosList = todosLosCiudadanos.ToList();
        HashSet<Ciudadano> vacunadosPfizer = new HashSet<Ciudadano>();
        HashSet<Ciudadano> vacunadosAstrazeneca = new HashSet<Ciudadano>();

        // Seleccionar 75 para Pfizer
        for (int i = 0; i < 75; i++)
        {
            int index = rnd.Next(ciudadanosList.Count);
            vacunadosPfizer.Add(ciudadanosList[index]);
            ciudadanosList.RemoveAt(index);
        }

        // Seleccionar 75 para Astrazeneca
        ciudadanosList = todosLosCiudadanos.Except(vacunadosPfizer).ToList();
        for (int i = 0; i < 75; i++)
        {
            int index = rnd.Next(ciudadanosList.Count);
            vacunadosAstrazeneca.Add(ciudadanosList[index]);
            ciudadanosList.RemoveAt(index);
        }

        // Calcular los diferentes conjuntos requeridos
        var noVacunados = todosLosCiudadanos.Except(vacunadosPfizer).Except(vacunadosAstrazeneca);
        var dosVacunas = vacunadosPfizer.Intersect(vacunadosAstrazeneca);
        var soloPfizer = vacunadosPfizer.Except(vacunadosAstrazeneca);
        var soloAstrazeneca = vacunadosAstrazeneca.Except(vacunadosPfizer);

        // Imprimir resultados
        Console.WriteLine("=== ANÁLISIS DE VACUNACIÓN COVID ===\n");

        Console.WriteLine("1. Ciudadanos no vacunados:");
        foreach (var ciudadano in noVacunados)
        {
            Console.WriteLine($"ID: {ciudadano.Id} - {ciudadano.Nombre} {ciudadano.Apellido}");
        }

        Console.WriteLine("\n2. Ciudadanos con ambas vacunas:");
        foreach (var ciudadano in dosVacunas)
        {
            Console.WriteLine($"ID: {ciudadano.Id} - {ciudadano.Nombre} {ciudadano.Apellido}");
        }

        Console.WriteLine("\n3. Ciudadanos solo con Pfizer:");
        foreach (var ciudadano in soloPfizer)
        {
            Console.WriteLine($"ID: {ciudadano.Id} - {ciudadano.Nombre} {ciudadano.Apellido}");
        }

        Console.WriteLine("\n4. Ciudadanos solo con Astrazeneca:");
        foreach (var ciudadano in soloAstrazeneca)
        {
            Console.WriteLine($"ID: {ciudadano.Id} - {ciudadano.Nombre} {ciudadano.Apellido}");
        }

        // Imprimir estadísticas
        Console.WriteLine("\n=== ESTADÍSTICAS ===");
        Console.WriteLine($"Total de ciudadanos: {todosLosCiudadanos.Count}");
        Console.WriteLine($"No vacunados: {noVacunados.Count()}");
        Console.WriteLine($"Con ambas vacunas: {dosVacunas.Count()}");
        Console.WriteLine($"Solo Pfizer: {soloPfizer.Count()}");
        Console.WriteLine($"Solo Astrazeneca: {soloAstrazeneca.Count()}");
    }
}
