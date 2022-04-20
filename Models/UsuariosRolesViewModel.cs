using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CENAOAPI.Models
{
    public class UsuariosRolesViewModel
    {
        public int idUsuarioRol { get; set; }
        public bool esActivo { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }

        public List<RolesFuncionesViewModel> RolesFunciones;
        public UsuariosRolesViewModel()
        {
            this.RolesFunciones = new List<RolesFuncionesViewModel>();
        }
    }
}