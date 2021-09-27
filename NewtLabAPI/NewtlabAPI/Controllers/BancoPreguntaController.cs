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
    public class BancoPreguntaController : ControllerBase
    {
        private readonly IBancoPreguntaService service;

        public BancoPreguntaController(IBancoPreguntaService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var get = await service.GetById(id);

            return Ok(get);
        }

        [HttpPost]
        public async Task<IActionResult> InsertarBancoPregunta(BancoPregunta bancoPregunta)
        {
            var add = new BancoPregunta
            {
                Tema = bancoPregunta.Tema,
                FechaCreacion =  DateTime.Now,
                ExperimentoId = bancoPregunta.ExperimentoId
            };

            await service.Insert(add);


            return Ok("Agregado");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarBancoPregunta(int id, BancoPregunta bancoPregunta)
        {

            var getId = await service.GetById(id);

            getId.Tema = bancoPregunta.Tema;
            getId.FechaCreacion = DateTime.Now;

            var getS = service.Update(getId);


            return Ok(getS);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarPregunta(int id)
        {
            var get = service.Delete(id);

            return Ok(get + "eliminado");
        }
    }

}
