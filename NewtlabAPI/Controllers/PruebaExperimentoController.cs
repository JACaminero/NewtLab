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
    public class PruebaExperimentoController : Controller
    {

        private readonly IPruebaExperimentoService service;
        public PruebaExperimentoController(IPruebaExperimentoService service)
        {
            this.service = service;
        }
   
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(service.GetAll());
        }
 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var get = await service.GetById(id);


            return Ok(get);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PruebaExperimento experimento)
        {
            var add = new PruebaExperimento
            {
                FechaTomado = experimento.FechaTomado,
                CalificacionObtenida = experimento.CalificacionObtenida
            };

             await service.Insert(add);


            return Ok("Prueba Experimento Agregada!");


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PruebaExperimento experimento)
        {
            var getId = await service.GetById(id);

            getId.FechaTomado = experimento.FechaTomado;
            getId.CalificacionObtenida = experimento.CalificacionObtenida;

            service.Update(getId);

            return Ok("Prueba experimento actualizada");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(service.Delete(id));
        }
    }
}
