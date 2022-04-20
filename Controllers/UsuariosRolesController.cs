using CENAOAPI.Services;
using CENAODB.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CENAOAPI.Controllers
{
    public class UsuariosRolesController : ApiController
    {
       /* private readonly AutenticacionServices _AutenticacionServices;
        public UsuariosRolesController()
        {
            _AutenticacionServices = new AutenticacionServices();
        }

        [HttpGet]
        [Route("api/usuario/rolesAsignados/{idUsuario}")]
        public async Task<IHttpActionResult> ObtenerUsuariosRoles(int idUsuario)
        {

            try
            {
                using (var db = new CENAODBEntities())
                {
                    var rolAsignados = await db.tbUsuariosRoles
                        .Include(x => x.tbRoles)
                        .Where(x => x.idUsuario == idUsuario && x.esActivo == true)
                        .Select(x => x.tbRoles)
                        .ToListAsync();

                    var listaRoles = rolAsignados.Select(x => new 
                    {   Id = x.idRol, 
                        Nombre = x.nombre, 
                        Status = x.esActivo 
                    }).ToList();
                    return Ok(listaRoles);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("api/usuario/RolesNoAsignados/{id}")]
        public async Task<IHttpActionResult> ObtenerRolesUsuarioInactivos(int id)
        {
            try
            {
                using (var db = new CENAODBEntities())
                {
                    var rolAsignados = db.tbUsuariosRoles
                        .Include(x => x.tbRoles)
                        .Where(x => x.idUsuario == id && x.esActivo == true)
                        .Select(x => x.tbRoles);

                    var rolNoAsignados = await db.tbRoles
                        .Except(rolAsignados)
                        .Select(x => new { Id = x.idRol, Status = x.esActivo, Nombre = x.nombre })
                        .ToListAsync();

                    return Ok(rolNoAsignados);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("api/usuario/asignarRol/{usuarioId}/{rolId}")]
        public async Task<IHttpActionResult> AsignarUsuarioRol(int usuarioId, int rolId)
        {
            try
            {
                using (var db = new CENAODBEntities())
                {
                    var user = _AutenticacionServices.Validate(Request.Headers.Authorization.Parameter);

                    var usuarioRol = await db.tbUsuariosRoles.FirstOrDefaultAsync(x => x.idUsuario == usuarioId && x.idRol == rolId);

                    if (usuarioRol != null)
                    {
                        usuarioRol.esActivo = true;
                        usuarioRol.usuarioModifica = user.id;
                        usuarioRol.fechaModifica = DateTime.Now;
                    }
                    else
                    {
                        var newUsuarioRol = new tbUsuariosRoles() { 
                            idUsuario = usuarioId, 
                            idRol = rolId, 
                            esActivo = true, 
                            usuarioCrea = user.id, 
                            fechaCrea = DateTime.Now };
                        db.tbUsuariosRoles.Add(newUsuarioRol);
                    }

                    var result = await db.SaveChangesAsync();
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("api/usuario/removerRol/{usuarioId}/{rolId}")]
        public async Task<IHttpActionResult> RemoverUsuarioRol(int usuarioId, int rolId)
        {
            try
            {
                using (var db = new CENAODBEntities())
                {
                    var user = _AutenticacionServices.Validate(Request.Headers.Authorization.Parameter);

                    var usuarioRol = await db.tbUsuariosRoles.FirstOrDefaultAsync(x => x.idUsuario == usuarioId && x.idRol == rolId);

                    if (usuarioRol == null)
                    {
                        return BadRequest("El usuario no tiene asignado el rol.");
                    }

                    usuarioRol.esActivo = false;
                    usuarioRol.usuarioModifica = user.id;
                    usuarioRol.fechaModifica = DateTime.Now;
                    var result = await db.SaveChangesAsync();
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
       */
    }
}
