using CENAOAPI.Models;
using CENAOAPI.Services;
using CENAODB.DataBase;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace CENAOAPI.Controllers
{
    public class InicioSesionController : ApiController
    {
        private readonly AutenticacionServices _AutenticacionServices;
        public InicioSesionController()
        {
            _AutenticacionServices = new AutenticacionServices();
        }

        [HttpGet]
        [Route("~/api/InicioSesion")]
        public IHttpActionResult IniciarSesion (string codigoUsuario, string newPassword)
        {
            try
            {
                using (var db = new CarCityDBEntities())
                {
                    var usuario =  db.SP_INICIO_SESION(codigoUsuario, newPassword).FirstOrDefault();

                     if (usuario != null)
                     {
                           if (!usuario.esActivo)
                           {
                                 return BadRequest("Usuario inactivo");
                           }

                        var result = _AutenticacionServices.Authentication(usuario.codigoUsuario);

                        return Ok(result);
                     }
                     else
                     {
                         return BadRequest("Usuario o contraseña incorrecto");
                     }
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }


        /*[HttpGet]
        [Route("~/api/Accesos/{Usuario}")]
        public async Task<IHttpActionResult> GetPermisos(string Usuario)
        {
            try
            {
                using (var db = new CarCityDBEntities())
                {
                    List<PermisosViewModel> PermisosUsuario = await db.tbUsuarios.Where(u => u.codigoUsuario == Usuario).Select(u => new PermisosViewModel
                    {
                        usuario = u.codigoUsuario,
                        esActivo = u.esActivo,
                        RolesUsuarios = db.tbUsuariosRoles.Where(r => r.idUsuario == u.idUsuario && r.esActivo == true).Select(rol => new UsuariosRolesViewModel
                        {
                            idUsuarioRol = rol.idUsuario,
                            Nombre = rol.tbRoles.nombre,
                            Usuario = rol.tbUsuarios.codigoUsuario,
                            RolesFunciones = db.tbRolesFunciones.Where(f => f.idRol == rol.idRol && f.esActivo == true).Select(f => new RolesFuncionesViewModel
                            {
                                idRolFuncion = f.idRolFuncion,
                                Funcion = f.tbFunciones.nombre,
                                esActivo = f.esActivo,
                                PantallasFunciones = db.tbPantallasFunciones.Where(p => p.idFuncion == f.idFuncion && p.esActivo == true).Select(p => new PantallasFuncionesViewModel
                                {
                                    NombrePantalla = p.tbPantallas.nombre,
                                    Ruta = p.tbPantallas.ruta
                                }).ToList()
                            }).ToList()
                        }).ToList(),
                    }).ToListAsync();

                    return Ok(PermisosUsuario);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }*/
    }
}
