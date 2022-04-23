using CENAODB.DataBase;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using CENAOAPI.Models;

namespace CENAOAPI.Controllers
{
    public class IngresoOrdenController : ApiController
    {
        [HttpGet]
        [Route("~/api/ingresoOrden")]
        public async Task<IHttpActionResult> ListadoIngresoOrden()
        {
            try
            {
                using (var db = new CarCityDBEntities())
                {
                    var tipoMecanica = await db.IngresoOrden.Select(x => new
                    {
                        mecanicaId = x.mecanicaId,
                        descripcionMecanica = x.tipoMecanica.descripcion,
                        clienteId = x.clienteId,
                        nombreCliente = x.clientes.nombre,
                        apellidoCliente = x.clientes.apellido,
                        colorId = x.colorId,
                        descripcionColor = x.colores.descripcion,
                        diagnostico = x.diagnostico,
                        comentarios = x.comentarios,
                        anio = x.anio,
                        Estado = x.Estado,
                        marca = x.marca,
                        fechaIngreso = x.fechaIngreso
                    }).ToListAsync();
                    return Ok(tipoMecanica);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        [Route("~/api/ingresoOrden/registrar")]
        public async Task<IHttpActionResult> RegistrarIngresoOrden([FromBody] IngresoOrdenViewModel orden)
        {
            try
            {
                using (var db = new CarCityDBEntities())
                {
                    var ingresoOrden = new IngresoOrden()
                    {
                        mecanicaId = orden.mecanicaId,
                        clienteId = orden.clienteId,
                        colorId = orden.colorId,
                        diagnostico = orden.diagnostico,
                        comentarios = orden.comentarios,
                        anio = orden.anio,
                        Estado = orden.estado,
                        marca = orden.marca,
                        fechaIngreso = orden.fechaIngreso,
                        fechaCrea = DateTime.Now,
                        usuarioCrea = orden.usuarioCrea,
                    };
                    db.IngresoOrden.Add(ingresoOrden);
                    var result = await db.SaveChangesAsync();
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message.ToString());
            }
        }
    }
}
