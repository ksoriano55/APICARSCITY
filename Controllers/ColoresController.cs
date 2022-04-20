using CENAODB.DataBase;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace CENAOAPI.Controllers
{
    public class ColoresController : ApiController
    {
        [HttpGet]
        [Route("~/api/colores")]
        public async Task<IHttpActionResult> ListadoUsuarios()
        {
            try
            {
                using (var db = new CarCityDBEntities())
                {
                    var colores = await db.colores.Select(x => new
                    {
                        colorId = x.colorId,
                        descripcion = x.descripcion 
                    }).ToListAsync();
                    return Ok(colores);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}
