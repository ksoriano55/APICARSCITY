using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CENAOAPI.Models
{
    public class ClientesViewModel
    {
        public int clienteId { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string telefono { get; set; }

        public string direccion { get; set; }
    }
}