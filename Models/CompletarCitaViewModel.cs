using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CENAOAPI.Models
{
    public class CompletarCitaViewModel
    {
        public int idCompCitas { get; set; }

        public int idTratamientoCita { get; set; }

        public Nullable<int> idTipoPago { get; set; }

        public Nullable<decimal> monto { get; set; }

        public string medicamentosRecetados { get; set; }

        public string comentario { get; set; }

        public string usuario { get; set; }

        public Boolean finalizarTratamiento { get; set; }

    }
}