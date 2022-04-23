using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CENAOAPI.Models
{
    public class TipoMecanicaViewModel
    {
        public int mecanicaId { get; set; }

        public string descripcion { get; set; }

        public Boolean activo { get; set; }
    }
}