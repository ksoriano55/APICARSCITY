using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CENAOAPI.Models
{
    public class IngresoTratamientoDetalladoViewModel
    {

        public string Descripcion { get; set; }
        public List<DetallePacienteViewModel> Pacientes { get; set; }
        public IngresoTratamientoDetalladoViewModel()
        {
            this.Pacientes = new List<DetallePacienteViewModel>();
        }
    }

  

    public class DetallePacienteViewModel
    {

        public string numExpediente { get; set; }
        public string nombre { get; set; }
        public decimal ? monto { get; set; }
        public DateTime fecha { get; set; }

    }
}