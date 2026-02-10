using Desafio_SuperLiga.Domain;
using Desafio_SuperLiga.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Desafio_SuperLiga.Application
{
    public class SociosService
    {
        private readonly List<Socio> _socios;
        private readonly RenderConsola _render;
        private const int ancho = 50;
        public SociosService(List<Socio> socios,RenderConsola render)
        {
            _socios = socios;
            _render = render;
        }
        public void MostrarCantidadTotal()
        {
            if (_socios.Count == 0)
            {
                Console.WriteLine(new string('#', ancho));
                Console.WriteLine();
                Console.WriteLine("No hay socios.");
                Console.WriteLine();
                Console.WriteLine(new string('#', ancho));
            }
            else
            {
                Console.WriteLine(new string('#', ancho));
                Console.WriteLine();
                Console.WriteLine($"Cantidad total de personas registradas: {_socios.Count}");
                Console.WriteLine();
                Console.WriteLine(new string('#', ancho));
                Console.WriteLine("Presione cualquier tecla para Volver al menu...");
                Console.ReadKey();

            }
        }
        public void MostrarPromedioEdadRacing()
        {
            var sociosRacing = _socios.Where(s => s.Equipo.Equals("Racing", StringComparison.OrdinalIgnoreCase)).ToList();
            if (sociosRacing.Count == 0)
            {
                Console.WriteLine(new string('#', ancho));
                Console.WriteLine();
                Console.WriteLine("No hay socios registrados para el equipo Racing.");
                Console.WriteLine();
                Console.WriteLine(new string('#', ancho));
            }
            else
            {
                var promedioEdad = sociosRacing.Average(s => s.Edad);
                Console.WriteLine(new string('#', ancho));
                Console.WriteLine();
                Console.WriteLine($"El promedio de edad de los socios de Racing es: {promedioEdad:F2} años.");
                Console.WriteLine();
                Console.WriteLine(new string('#', ancho));
            }
            Console.WriteLine("Presione cualquier tecla para Volver al menu...");
            Console.ReadKey();
        }
        public void MostrarListadoCasadosUniversitarios()
        {
            string formato = "|{0,-5}|{1,-15}|{2,-5}|{3,-15}|";
            var casadosUniversitarios = _socios
                .Where(s => s.EstadoCivil.Equals("Casado", StringComparison.OrdinalIgnoreCase) &&
                            s.NivelEducativo.Equals("Universitario", StringComparison.OrdinalIgnoreCase))
                .OrderBy(s => s.Edad)
                .Take(100)
                .ToList();
            if (casadosUniversitarios.Count == 0)
            {
                Console.WriteLine(new string('#', ancho));
                Console.WriteLine();
                Console.WriteLine("No hay socios casados con estudios universitarios registrados.");
                Console.WriteLine();
                Console.WriteLine(new string('#', ancho));
            }
            else
            {
                Console.WriteLine(new string('#', ancho));
                Console.WriteLine();
                Console.WriteLine("Listado de las 100 primeras personas casadas con estudios universitarios:");
                //Cabecera de la tabla
                Console.WriteLine(new string('-', ancho));
                Console.WriteLine(string.Format(formato, "N°", "Nombre", "Edad", "Equipo"));
                Console.WriteLine(new string('-', ancho));
                int contador = 1;
                foreach (var socio in casadosUniversitarios)
                {
                    Console.WriteLine(string.Format(formato, contador,socio.Nombre,socio.Edad,socio.Equipo));
                    contador++;
                }
                Console.WriteLine();
                Console.WriteLine(new string('#', ancho));
            }
            Console.WriteLine("Presione cualquier tecla para Volver al menu...");
            Console.ReadKey();
        }

        public void MostrarNombresMasComunesRiver()
        {
            string formato = "|{0,-20}|{1,6}|";

            var nombresMasComunesRiver = _socios
                .Where(s => s.Equipo.Equals("River", StringComparison.OrdinalIgnoreCase))
                .GroupBy(s => s.Nombre)
                .Select(g => new { Nombre = g.Key, Cantidad = g.Count() })
                .OrderByDescending(g => g.Cantidad)
                .Take(5)
                .ToList();
            if (nombresMasComunesRiver.Count == 0)
            {
                Console.WriteLine(new string('#', ancho));
                Console.WriteLine();
                Console.WriteLine("No hay socios registrados para el equipo River.");
                Console.WriteLine();
                Console.WriteLine(new string('#', ancho));
            }
            else
            {
                Console.WriteLine("Listado de los 5 nombres más comunes entre los hinchas de River:");
                //Cabecera de la tabla
                Console.WriteLine(new string('-', ancho));
                Console.WriteLine(string.Format(formato, "Nombre", "Cantidad"));
                Console.WriteLine(new string('-', ancho));
                foreach (var nombre in nombresMasComunesRiver)
                {
                    Console.WriteLine(string.Format(formato, nombre.Nombre, nombre.Cantidad));
                }
            }
            Console.WriteLine("Presione cualquier tecla para Volver al menu...");
            Console.ReadKey();

        }
        public void MostrarListadoEquipos()
        {
            string formato = "| {0,-15} | {1,8} | {2,8} | {3,6} | {4,6} |";
            var listadoEquipos = _socios
                .GroupBy(s => s.Equipo)
                .Select(g => new
                {
                    Equipo = g.Key,
                    CantidadSocios = g.Count(),
                    PromedioEdad = g.Average(s => s.Edad),
                    MenorEdad = g.Min(s => s.Edad),
                    MayorEdad = g.Max(s => s.Edad)
                })
                .OrderByDescending(g => g.CantidadSocios)
                .ToList();
            if (listadoEquipos.Count == 0)
            {
                Console.WriteLine(new string('#', ancho));
                Console.WriteLine();
                Console.WriteLine("No hay socios registrados.");
                Console.WriteLine();
                Console.WriteLine(new string('#', ancho));
            }
            else
            {
                Console.WriteLine("Listado de equipos con cantidad de socios, promedio de edad, menor edad y mayor edad:");
                //Cabecera de la tabla
                Console.WriteLine(new string('-', ancho));
                Console.WriteLine(string.Format(formato, "Equipo", "Socios", "Edad Prom", "< Edad","> Edad"));
                Console.WriteLine(new string('-', ancho));
                foreach (var equipo in listadoEquipos)
                {
                    Console.WriteLine(string.Format(formato, equipo.Equipo,equipo.CantidadSocios,$"{equipo.PromedioEdad:F2}",equipo.MenorEdad,equipo.MayorEdad));
                }
            }
            Console.WriteLine("Presione cualquier tecla para Volver al menu...");
            Console.ReadKey();
        }
    }
}
