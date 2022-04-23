using CENAODB.DataBase;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using CENAOAPI.Models;

namespace CENAOAPI.Controllers
{
    public class ClientesController : ApiController
    {
        [HttpGet]
        [Route("~/api/clientes")]
        public async Task<IHttpActionResult> ListadoClientes()
        {
            try
            {
                using (var db = new CarCityDBEntities())
                {
                    var clientes = await db.clientes.Select(x => new ClientesViewModel
                    {
                        clienteId = x.clienteId,
                        nombre = x.nombre,
                        apellido = x.apellido,
                        direccion = x.direccion,
                        telefono = x.telefono,
                    }).ToListAsync();
                    return Ok(clientes);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }


        [HttpPost]
        [Route("~/api/clientes/registrar")]
        public async Task<IHttpActionResult> RegistrarClientes([FromBody] ClientesViewModel cliente)
        {
            try
            {
                using (var db = new CarCityDBEntities())
                {
                    var clientes = new clientes()
                    {
                        nombre = cliente.nombre,
                        apellido = cliente.apellido,
                        direccion= cliente.direccion,
                        telefono= cliente.telefono
                    };
                    db.clientes.Add(clientes);
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
        [Route("~/api/clientes/modificar")]
        public async Task<IHttpActionResult> ModificarClientes([FromBody] ClientesViewModel cliente)
        {
            try
            {
                using (var db = new CarCityDBEntities())
                {
                    var clienteDB = await db.clientes.FindAsync(cliente.clienteId);

                    if (clienteDB == null)
                    {
                        return BadRequest("Tipo Mecanica Invalido");
                    }

                    clienteDB.nombre = cliente.nombre;
                    clienteDB.apellido = cliente.apellido;
                    clienteDB.telefono = cliente.telefono;
                    clienteDB.direccion = cliente.direccion;
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
