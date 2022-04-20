using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CENAOAPI.Models
{
    public class TipoPagoViewModel
    {
        public int idTipoPago { get; set; }

        public string descripcion { get; set; }

        public bool activo { get; set; }

        public int usuario { get; set; }
    }
}