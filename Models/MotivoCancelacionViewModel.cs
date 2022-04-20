using System;
using System.ComponentModel.DataAnnotations;

namespace CENAOAPI.Models
{
    public class MotivoCancelacionViewModel
    {
        [Key]
        public int idMotCancelacion { get; set; }
        public string descripcion { get; set; }
        public int usuarioCrea { get; set; }
        public System.DateTime fechaCrea { get; set; }
        public Nullable<int> usuarioModifica { get; set; }
        public Nullable<System.DateTime> fechaModifica { get; set; }
    }
}