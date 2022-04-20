using System.ComponentModel.DataAnnotations;

namespace CENAOAPI.Models
{
    public class UsuariosViewModel
    {
        [Key]
        public int idUsuario { get; set; }
        public string codigoUsuario { get; set; }
        public string newPassword { get; set; }
        public byte[] password { get; set; }
        public bool esActivo { get; set; }
    }
}