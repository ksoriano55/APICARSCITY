using System;
using System.Collections.Generic;

namespace CENAOAPI.Models
{
    public class IngresoOrdenViewModel
    {
        public int ordenId { get; set; }
        public int clienteId { get; set; }
        public int mecanicaId { get; set; }
        public int colorId { get; set; }
        public int mecanicoId { get; set; }
        public string marca { get; set; }
        public string anio { get; set; }
        public Nullable<System.DateTime> fechaIngreso { get; set; }
        public string estado { get; set; }
        public string diagnostico { get; set; }
        public string comentarios { get; set; }
        public int usuarioCrea { get; set; }
        public System.DateTime fechaCrea { get; set; }
        public Nullable<int> usuarioModifica { get; set; }
        public Nullable<System.DateTime> fechaModifica { get; set; }
    }
}