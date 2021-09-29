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
    public class PreguntaController : ControllerBase
    {
        private readonly IPreguntaService service;


        public PreguntaController(IPreguntaService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult>Get()
        {
            return Ok(service.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            return Ok(service.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pregunta  pregunta)
        {
            var add = new Pregunta
            {
                Puntuacion = pregunta.Puntuacion,
                Descripcion = pregunta.Descripcion
            };


            await service.Insert(add);


            return Ok("Agregado");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pregunta pregunta)
        {
            var getId = await service.GetById(id);

            getId.Puntuacion = pregunta.Puntuacion;
            getId.Descripcion = pregunta.Descripcion;

            service.Update(getId);


            return Ok("Actualizado");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(service.Delete(id));
        }
    }
}
