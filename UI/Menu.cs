using Desafio_SuperLiga.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_SuperLiga.UI
{
    public class Menu
    {
        private readonly SociosService _service;
        private readonly RenderConsola _render;

        public Menu(SociosService service, RenderConsola render)
        {
            _service = service;
            _render = render;
        }

        public void MostrarMenu() 
        {
            
            int ancho = 100;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(new string('#',ancho));
                _render.DibujarLineas(ancho, '#', ' ', "Desafío SuperLiga",true);
                Console.WriteLine(new string('#', ancho));
                Console.WriteLine();
                _render.DibujarLineas(ancho, '|', ' ', "1 - Mostrar Cantidad total de personas");
                _render.DibujarLineas(ancho, '|', ' ', "2 - Mostrar Promedio edad socios Racing");
                _render.DibujarLineas(ancho, '|', ' ', "3 - Listado 100 casados universitarios");
                _render.DibujarLineas(ancho, '|', ' ', "4 - Listado 5 nombres comunes River");
                _render.DibujarLineas(ancho, '|', ' ', "5 - Estadísticas por equipo");
                _render.DibujarLineas(ancho, '|', ' ', "0 - Salir");
                Console.WriteLine(new string('_', ancho));


                Console.Write("\nSeleccione una opción: ");
                
                var opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        _service.MostrarCantidadTotal();
                        break;
                    case "2": 
                        _service.MostrarPromedioEdadRacing();
                        break;
                    case "3":
                        //Aqui se debe mostrar Nombre, Edad y Equipo orden ASC de las 100 PRIMERAS personas casadas con
                        //estudios universitarios
                        _service.MostrarListadoCasadosUniversitarios();
                        break;
                    case "4":
                        //Aqui se debe mostrar un listado con orden DESC de los 5 nombres más comunes entre los socios de River
                        _service.MostrarNombresMasComunesRiver();
                        break;
                    case "5":
                        //Aqui se debe mostrar un listado con orden DESC de la cantidad de socios,
                        //junto con cada equipo, el promedio de edad de sus socios, la menor edad
                        //registrada y la mayor edad registrada
                        _service.MostrarListadoEquipos();
                        break;
                    case "0":
                        Console.WriteLine("Saliendo del programa...");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Presione cualquier tecla para intentar nuevamente...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
