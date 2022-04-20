using System;
using System.ComponentModel.DataAnnotations;

namespace CENAOAPI.Models
{
    public class SucursalViewModel
    {
        [Key]
        public int idSucursal { get; set; }
        public string nombre { get; set; }
        public bool principal { get; set; }
        public int usuarioCrea { get; set; }
        public System.DateTime fechaCrea { get; set; }
        public Nullable<int> usuarioModifica { get; set; }
        public Nullable<System.DateTime> fechaModifica { get; set; }
    }
}