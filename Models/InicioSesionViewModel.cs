using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CENAOAPI.Models
{
    public class InicioSesionViewModel
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public bool esActivo { get; set; }
        public DateTime FechaFin { get; set; }
    }

    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public int id { get; set; }
        public string usuario { get; set; }
        public bool esActivo { get; set; }
        public string Message { get; set; }

    }
}