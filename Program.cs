using Desafio_SuperLiga.Application;
using Desafio_SuperLiga.Domain;
using Desafio_SuperLiga.Infrastructure;
using Desafio_SuperLiga.UI;
using System.Text;


public static class Program
{
    private static readonly string SociosUrl = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plantilla", "socios.csv");
    public static void Main()
    {
        try
        {
            var render = new RenderConsola();
            var Socios = AccionesSocio.LeerSocios(SociosUrl);
            var Service = new SociosService(Socios, render);
            new Menu(Service,render).MostrarMenu();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo: {ex.Message}");
            Console.WriteLine(ex.Message);
            return;
        }
    }


}