using Desafio_SuperLiga.Domain;
using System.Text;


namespace Desafio_SuperLiga.Infrastructure
{
    public class AccionesSocio
    {
        public static List<Socio> LeerSocios(string url)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = Encoding.UTF8;
            if (!File.Exists(url))
                throw new FileNotFoundException($"El archivo {url} no existe.");
            //Aqui creamos una lista de socios vacia y luego leemos el archivo linea por linea, separamos cada linea por comas y creamos un nuevo socio con los datos obtenidos, finalmente agregamos el socio a la lista de socios y la retornamos.
            List<Socio> socios = new List<Socio>();
            using (StreamReader sr = new StreamReader(url,Encoding.GetEncoding(1252)))
            {
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    string[] datos = linea.Split(';');
                    if (datos.Length == 5)
                    {
                        socios.Add(new Socio(
                            Nombre: datos[0],
                            Edad: int.Parse(datos[1]),
                            Equipo: datos[2],
                            EstadoCivil: datos[3],
                            NivelEducativo: datos[4]
                        ));
                    }
                }
            }

            return socios;
        }
    }
}
