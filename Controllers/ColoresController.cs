﻿using CENAODB.DataBase;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using CENAOAPI.Models;

namespace CENAOAPI.Controllers
{
    public class ColoresController : ApiController
    {
        [HttpGet]
        [Route("~/api/colores")]
        public async Task<IHttpActionResult> ListadoColores()
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


        [HttpPost]
        [Route("~/api/colores/registrar")]
        public async Task<IHttpActionResult> RegistrarColores([FromBody] ColoresViewModel color)
        {
            try
            {
                using (var db = new CarCityDBEntities())
                {
                    var colores = new colores()
                    {
                       descripcion = color.descripcion,
                    };
                    db.colores.Add(colores);
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
        [Route("~/api/colores/modificar")]
        public async Task<IHttpActionResult> ModificarColores([FromBody] ColoresViewModel Colores)
        {
            try
            {
                using (var db = new CarCityDBEntities())
                {
                    var colorDB = await db.colores.FindAsync(Colores.colorId);

                    if (colorDB == null)
                    {
                        return BadRequest("Color Invalido");
                    }

                    colorDB.descripcion = Colores.descripcion;
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
