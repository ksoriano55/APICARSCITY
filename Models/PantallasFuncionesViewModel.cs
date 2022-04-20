using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CENAOAPI.Models
{
    public class PantallasFuncionesViewModel
    {
        public int idPantallaFuncion { get; set; }

        public int idPantalla { get; set; }

        public int idFuncion { get; set; }

        public bool esActivo { get; set; }

        public string NombrePantalla { get; set; }

        public string Ruta { get; set; }
    }
}