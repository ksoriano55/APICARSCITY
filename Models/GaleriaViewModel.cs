using System;
using System.ComponentModel.DataAnnotations;

namespace CENAOAPI.Models
{
    public class GaleriaViewModel
    {
        [Key]
        public int idGaleria { get; set; }
        public int idTraPaciente { get; set; }
        public string nombreTratamiento { get; set; }
        public byte[] imagen { get; set; }
        public string fotoTratamientoPacienteBase64 { get; set; }
        public Nullable<System.DateTime> fechaImagen { get; set; }
        public int usuarioCrea { get; set; }
        public System.DateTime fechaCrea { get; set; }
        public Nullable<int> usuarioModifica { get; set; }
        public Nullable<System.DateTime> fechaModifica { get; set; }
    }
}