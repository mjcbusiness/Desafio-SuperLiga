using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_SuperLiga.UI
{
    public class RenderConsola
    {
        public RenderConsola()
        {
            
        }
        public void DibujarLineas(int ancho, char borde, char relleno, string texto="", bool centrar = false) 
        {
            int espacioDisponible = ancho - 4; // Restamos 4 para los bordes y espacios

            string contenido = "";
            if (centrar)
            {
                int espaciosTotales = espacioDisponible - texto.Length;
                int espaciosIzquierda = espaciosTotales / 2;
                int espaciosDerecha = espaciosTotales - espaciosIzquierda;
                contenido = new string(relleno, espaciosIzquierda) + texto + new string(relleno, espaciosDerecha);
            }
            else
            {
                contenido = texto.PadRight(espacioDisponible);
            }
            Console.WriteLine($"{borde} {contenido} {borde}");
        }

    }
}
