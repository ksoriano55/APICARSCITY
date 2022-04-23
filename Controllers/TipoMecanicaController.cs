using CENAODB.DataBase;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using CENAOAPI.Models;

namespace CENAOAPI.Controllers
{
    public class TipoMecanicaController : ApiController
    {
        [HttpGet]
        [Route("~/api/tipoMecanica")]
        public async Task<IHttpActionResult> ListadoTipoMecanica()
        {
            try
            {
                using (var db = new CarCityDBEntities())
                {
                    var tipoMecanica = await db.tipoMecanica.Select(x => new TipoMecanicaViewModel
                    {
                        mecanicaId = x.mecanicaId,
                        descripcion = x.descripcion,
                        activo = x.activo,
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
        [Route("~/api/tipoMecanica/registrar")]
        public async Task<IHttpActionResult> RegistrarTipoMecanica([FromBody] TipoMecanicaViewModel tipoMecanica)
        {
            try
            {
                using (var db = new CarCityDBEntities())
                {
                    var tipoMecanicas = new tipoMecanica()
                    {
                        descripcion = tipoMecanica.descripcion,
                        activo = tipoMecanica.activo,
                    };
                    db.tipoMecanica.Add(tipoMecanicas);
                    var result = await db.SaveChangesAsync();
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message.ToString());
            }
        }

        [HttpPost]
        [Route("~/api/tipoMecanica/modificar")]
        public async Task<IHttpActionResult> ModificarTipoMecanica([FromBody] TipoMecanicaViewModel tipoMecanica)
        {
            try
            {
                using (var db = new CarCityDBEntities())
                {
                    var tipoMecanicaDB = await db.tipoMecanica.FindAsync(tipoMecanica.mecanicaId);

                    if (tipoMecanicaDB == null)
                    {
                        return BadRequest("Tipo Mecanica Invalido");
                    }

                    tipoMecanicaDB.descripcion = tipoMecanica.descripcion;
                    tipoMecanicaDB.activo = tipoMecanica.activo;    
                    var result = await db.SaveChangesAsync();
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
