using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CENAOAPI.Models
{
    public class PermisosViewModel
    {
            public int Id { get; set; }
            public string usuario { get; set; }
            public bool esActivo { get; set; }
            public List<UsuariosRolesViewModel> RolesUsuarios;
            public PermisosViewModel()
            {
                this.RolesUsuarios = new List<UsuariosRolesViewModel>();
            }
        
    }
}