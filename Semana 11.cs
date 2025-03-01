using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TraductorBasico
{
    class Program
    {
        static void Main(string[] args)
        {
            // Diccionario inicial con palabras en inglés y español
            Dictionary<string, string> diccionarioEnEs = new Dictionary<string, string>
            {
                { "time", "tiempo" },
                { "person", "persona" },
                { "year", "año" },
                { "way", "camino" },
                { "day", "día" },
                { "thing", "cosa" },
                { "man", "hombre" },
                { "world", "mundo" },
                { "life", "vida" },
                { "hand", "mano" },
                { "part", "parte" },
                { "child", "niño" },
                { "eye", "ojo" },
                { "woman", "mujer" },
                { "place", "lugar" },
                { "work", "trabajo" },
                { "week", "semana" },
                { "case", "caso" },
                { "point", "punto" },
                { "government", "gobierno" },
                { "company", "empresa" }
            };

            // Crear diccionario inverso (español a inglés)
            Dictionary<string, string> diccionarioEsEn = diccionarioEnEs.ToDictionary(
                pair => pair.Value,
                pair => pair.Key
            );

            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("\nMENU");
                Console.WriteLine("=======================================================");
                Console.WriteLine("1. Traducir una frase");
                Console.WriteLine("2. Ingresar más palabras al diccionario");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 0:
                            Console.WriteLine("¡Gracias por usar el traductor!");
                            continuar = false;
                            break;

                        case 1:
                            TraducirFrase(diccionarioEnEs, diccionarioEsEn);
                            break;

                        case 2:
                            AgregarPalabras(diccionarioEnEs, diccionarioEsEn);
                            break;

                        default:
                            Console.WriteLine("Opción no válida. Por favor, seleccione una opción del menú.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Error: Debe ingresar un número.");
                }
            }
        }

        static void TraducirFrase(Dictionary<string, string> diccionarioEnEs, Dictionary<string, string> diccionarioEsEn)
        {
            Console.Write("Ingrese la frase: ");
            string frase = Console.ReadLine();
            string[] palabras = frase.Split(' ');

            // Detectar automáticamente el idioma de entrada
            int coincidenciasEs = palabras.Count(p => diccionarioEsEn.ContainsKey(LimpiarPalabra(p).ToLower()));
            int coincidenciasEn = palabras.Count(p => diccionarioEnEs.ContainsKey(LimpiarPalabra(p).ToLower()));

            // Determinar el diccionario a utilizar según el idioma detectado
            Dictionary<string, string> diccionario;
            if (coincidenciasEs >= coincidenciasEn)
            {
                // La frase parece estar en español
                diccionario = diccionarioEsEn;
            }
            else
            {
                // La frase parece estar en inglés
                diccionario = diccionarioEnEs;
            }

            List<string> fraseTraducida = new List<string>();

            foreach (string palabra in palabras)
            {
                // Separar la palabra de los signos de puntuación
                string palabraLimpia = LimpiarPalabra(palabra);
                string puntuacion = ObtenerPuntuacion(palabra);

                // Traducir la palabra si está en el diccionario
                if (diccionario.ContainsKey(palabraLimpia.ToLower()))
                {
                    string palabraTraducida = diccionario[palabraLimpia.ToLower()];

                    // Mantener mayúsculas/minúsculas
                    if (char.IsUpper(palabraLimpia[0]))
                    {
                        palabraTraducida = char.ToUpper(palabraTraducida[0]) + palabraTraducida.Substring(1);
                    }

                    fraseTraducida.Add(palabraTraducida + puntuacion);
                }
                else
                {
                    fraseTraducida.Add(palabra);
                }
            }

            Console.WriteLine($"Su frase traducida es: {string.Join(" ", fraseTraducida)}");
        }

        static void AgregarPalabras(Dictionary<string, string> diccionarioEnEs, Dictionary<string, string> diccionarioEsEn)
        {
            Console.WriteLine("\nAgregar nuevas palabras al diccionario");
            Console.WriteLine("-------------------------------------------------------");

            while (true)
            {
                Console.Write("Ingrese la palabra en inglés (o 'salir' para terminar): ");
                string palabraEn = Console.ReadLine();

                if (palabraEn.ToLower() == "salir")
                {
                    break;
                }

                Console.Write("Ingrese la traducción en español: ");
                string palabraEs = Console.ReadLine();

                // Guardar las palabras en ambos diccionarios
                diccionarioEnEs[palabraEn.ToLower()] = palabraEs.ToLower();
                diccionarioEsEn[palabraEs.ToLower()] = palabraEn.ToLower();

                Console.WriteLine($"Palabra '{palabraEn} - {palabraEs}' agregada con éxito.");
            }
        }

        static string LimpiarPalabra(string palabra)
        {
            // Elimina signos de puntuación al inicio y final de la palabra
            return Regex.Replace(palabra, @"^[\p{P}]+|[\p{P}]+$", "");
        }

        static string ObtenerPuntuacion(string palabra)
        {
            // Extrae los signos de puntuación al final de la palabra
            Match match = Regex.Match(palabra, @"[\p{P}]+$");
            return match.Success ? match.Value : "";
        }
    }
}