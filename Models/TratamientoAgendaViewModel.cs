using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CENAOAPI.Models
{
    public class TratamientoAgendaViewModel
    {
        public int idTratamientoCita { get; set; }

        public int idCita { get; set; }

        public int idListaTratamiento { get; set; }

        public string tratamiento { get; set; }

        public int usuarioCrea { get; set; }

        public System.DateTime fechaCrea { get; set; }

        public Nullable<int> usuarioModifica { get; set; }

        public Nullable<System.DateTime> fechaModifica { get; set; }
    }
}