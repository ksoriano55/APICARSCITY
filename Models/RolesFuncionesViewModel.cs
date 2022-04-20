using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CENAOAPI.Models
{
    public class RolesFuncionesViewModel
    {
        public int idRolFuncion { get; set; }
        public int idRol { get; set; }
        public string Funcion { get; set; }
        public Nullable<bool> esActivo { get; set; }

        public List<PantallasFuncionesViewModel> PantallasFunciones;

        public RolesFuncionesViewModel()
        {
            this.PantallasFunciones = new List<PantallasFuncionesViewModel>();
        }
    }
}