using System;
using System.ComponentModel.DataAnnotations;

namespace CENAOAPI.Models
{
    public class TratamientoPacienteViewModel
    {
        [Key]
        public int idTraPaciente { get; set; }
        public string numExpediente { get; set; }
        public int idListaTratamiento { get; set; }
        public int idEstado { get; set; }
        public System.DateTime fechaInicio { get; set; }
        public Nullable<System.DateTime> fechaFinal { get; set; }
        public string comentario { get; set; }
        public Nullable<decimal> montoPrima { get; set; }
        public Nullable<decimal> montoMensualidad { get; set; }
        public int usuarioCrea { get; set; }
        public System.DateTime fechaCrea { get; set; }
        public Nullable<int> usuarioModifica { get; set; }
        public Nullable<System.DateTime> fechaModifica { get; set; }
        public string nombreTratamiento { get; set; }
        public string nombreEstado { get; set; }
    }
}