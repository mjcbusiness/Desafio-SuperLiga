using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_SuperLiga.Domain
{
    public record Socio(
        string Nombre,
        int Edad,
        string Equipo,
        string EstadoCivil,
        string NivelEducativo
    );
}
