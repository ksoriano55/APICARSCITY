using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CENAOAPI.Models
{
    public class TratamientosViewModel
    {
        public int idListaTratamiento { get; set; }

        public string descripcion { get; set; }

        public Boolean activo { get; set; }

        public string usuarioCrea { get; set; }

        public DateTime fechaCrea { get; set; }

        public string usuarioModifica { get; set; }

        public Nullable<DateTime> fechaModifica { get; set; }
    }
}