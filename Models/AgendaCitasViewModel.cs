using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CENAOAPI.Models
{
    public class AgendaCitasViewModel
    {
        public int idCita { get; set; }

        public string numExpediente { get; set; }

        public string nombrePaciente { get; set; }

        public List<string> tratamientos { get; set; }

        public string tratamiento { get; set; }

        public DateTime horaInicio { get; set; }

        public DateTime horaFinal { get; set; }

        public int idEstado { get; set; }

        public string estado { get; set; }

        public string comentario { get; set; }

        public string usuario { get; set; }

        public string foto { get; set; }
    }
}