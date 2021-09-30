using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewtlabAPI.Models;
using NewtlabAPI.Services.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewtlabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespuestaController : ControllerBase
    {
        private readonly IRespuestaService service;


        public RespuestaController(IRespuestaService service)
        {
            this.service = service;
        }

       [HttpGet]
       public async Task<IActionResult> GetAll()
        {
            return Ok(service.GetAll());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getId = await service.GetById(id);

            return Ok(getId);
        }


        [HttpPost]
        public async Task<IActionResult> AddRespuesta(Respuesta respuesta)
        {

            var add = new Respuesta
            {
                Descripcion = respuesta.Descripcion,
                Puntuacion = respuesta.Puntuacion
            };


            var result = service.Insert(add);

            return Ok(result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRespuesta(int id, Respuesta respuesta)
        {
            var getId = await service.GetById(id);


            getId.Descripcion = respuesta.Descripcion;
            getId.Puntuacion = respuesta.Puntuacion;

            service.Update(getId);


            return Ok("Actualizado");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRespuesta(int id)
        {
            var delete = service.Delete(id);

            return Ok(delete);
        }
    }
}
