using CENAOAPI.Models;
using CENAODB.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace CENAOAPI.Controllers
{
    public class UsuariosController : ApiController
    {
        private CarCityDBEntities db = new CarCityDBEntities();

        [HttpGet]
        [Route("~/api/usuarios")]
        public async Task<IHttpActionResult> ListadoUsuarios()
        {
            try
            {
                using (var db = new CarCityDBEntities())
                {
                    var listaUsuarios = await db.Usuarios.Select(x => new
                    {
                        nombre = x.nombre,
                        apellido = x.apellido,
                        telefono = x.telefono,
                        esMecanico = x.esMecanico,
                        idUsuario = x.idUsuario,
                        codigoUsuario = x.codigoUsuario,
                        esActivo = x.esActivo
                    }).ToListAsync();
                    return Ok(listaUsuarios);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

      /*  [HttpGet]
        [Route("~/api/usuarios/activos")]
        public async Task<IHttpActionResult> ObtenerUsuarioActivos()
        {
            try
            {
                using (var db = new CarCityDBEntities())
                {
                    var usuariosActivos = await db.Usuarios.Where(x => x.esActivo == true).Select(x => new 
                    { 
                      Id = x.idUsuario, 
                      Usuario = x.codigoUsuario 
                    }).ToListAsync();
                    return Ok(usuariosActivos);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }*/

        [HttpPost]
        [Route("~/api/usuarios/registrar")]
        public async Task<IHttpActionResult> RegistrarUsuarios([FromBody] UsuariosViewModel usuarios)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var ValidarUsuario = db.Usuarios.Where(x => x.codigoUsuario.ToLower().Trim() == usuarios.codigoUsuario.ToLower().Trim()).ToList();
                    if (ValidarUsuario.Count() > 0) {
                        return BadRequest("Ya existe este usuario.");
                    }
                    else 
                    {
                        IEnumerable<object> CrearUsuarios = null;
                        var MensajeError = "";
                        CrearUsuarios = db.SP_CREAR_USUARIO(usuarios.nombre, usuarios.apellido, usuarios.telefono, usuarios.esMecanico, usuarios.codigoUsuario.Trim(), usuarios.newPassword);
                        foreach (SP_CREAR_USUARIO_Result ProcedureCreateUser in CrearUsuarios)
                            MensajeError = ProcedureCreateUser.MessageError;
                        if (MensajeError.StartsWith("1"))
                        {
                            return BadRequest("No se pudo crear este registro.");
                        }
                        else
                        {
                            var result = await db.SaveChangesAsync();
                            transaction.Commit();
                            return Ok(result);
                        }
                    }
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return BadRequest(e.ToString());
                }
            }
        }

        [HttpPut]
        [Route("~/api/usuarios/editar")]
        public async Task<IHttpActionResult> EditarUsuarios(int idUsuario, [FromBody] UsuariosViewModel editUsuarios)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var EditarUsuarios = db.Usuarios.Find(idUsuario);
                    if (EditarUsuarios != null)
                    {
                        EditarUsuarios.nombre = editUsuarios.nombre;
                        EditarUsuarios.apellido = editUsuarios.apellido;
                        EditarUsuarios.telefono = editUsuarios.telefono;
                        EditarUsuarios.esMecanico = editUsuarios.esMecanico;
                        EditarUsuarios.codigoUsuario = editUsuarios.codigoUsuario.Trim();
                        EditarUsuarios.esActivo = editUsuarios.esActivo;
                        db.Entry(EditarUsuarios).State = EntityState.Modified;
                        var result = await db.SaveChangesAsync();
                        transaction.Commit();
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest("No se encontró este usuario.");
                    }
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return BadRequest(e.ToString());
                }
            }
        }

        [HttpPost]
        [Route("~/api/usuarios/resetearPassword")]
        public async Task<IHttpActionResult> ResetPasswordUsuario(int idUsuario, string newPassword)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    IEnumerable<object> list = null;
                    var MensajeError = "";
                    var BuscarUsuario = db.Usuarios.Find(idUsuario);
                    if (BuscarUsuario != null)
                    {
                        list = db.SP_RESETEAR_PASSWORD(idUsuario, newPassword);
                        foreach(SP_RESETEAR_PASSWORD_Result ProcedimientoModifyPassword in list)
                            MensajeError = ProcedimientoModifyPassword.MessageError;
                        if (MensajeError.StartsWith("1"))
                        {
                            return BadRequest("No se pudo modificar la contraseña");
                        }
                        else {
                            var result = await db.SaveChangesAsync();
                            transaction.Commit();
                            return Ok(result);
                        }
                    }
                    else
                    {
                        return BadRequest("No se encontró este usuario.");
                    }
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return BadRequest(e.ToString());
                }
            }
        }
    }
}
