using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CENAOAPI.Models
{
    public class CancelarCitaViewModel
    {
        public int idCanCitas { get; set; }

        public int idCita { get; set; }

        public int idMotCancelacion { get; set; }

        public string comentario { get; set; }

        public string usuario { get; set; }
    }
}