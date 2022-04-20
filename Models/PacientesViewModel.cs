using System;
using System.Collections.Generic;

namespace CENAOAPI.Models
{
    public class PacientesViewModel
    {
        public string numExpediente { get; set; }
        public int idSucursal { get; set; }
        public string nombreSucursal { get; set; }
        public string identidad { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string sexo { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
        public string profesion { get; set; }
        public string telefono { get; set; }
        public string telefonoReferencia { get; set; }
        public byte[] foto { get; set; }
        public string fotoPacienteBase64 { get; set; }
        public int idEstado { get; set; }
        public string nombreEstado { get; set; }
        public int usuarioCrea { get; set; }
        public System.DateTime fechaCrea { get; set; }
        public Nullable<int> usuarioModifica { get; set; }
        public Nullable<System.DateTime> fechaModifica { get; set; }
        public List<FichaClinicaViewModel> listFichaClinica { get; set; }
        public int idListaTratamiento { get; set; }
        public Nullable<decimal> montoPrima { get; set; }
        public Nullable<decimal> montoMensualidad { get; set; }
        public string comentario { get; set; }
    }

    public class FichaClinicaViewModel
    {
        public string numExpediente { get; set; }
        public string diagnostico { get; set; }
        public string planTratamiento { get; set; }
        public string alergias { get; set; }
        public string tipoSangre { get; set; }
        public string antecedentesClinicos { get; set; }
        public int usuarioCrea { get; set; }
        public System.DateTime fechaCrea { get; set; }
        public Nullable<int> usuarioModifica { get; set; }
        public Nullable<System.DateTime> fechaModifica { get; set; }
    }
}