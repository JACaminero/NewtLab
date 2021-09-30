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
    public class TipoPreguntaController : Controller
    {

        private readonly ITipoPreguntaService service;


        public TipoPreguntaController(ITipoPreguntaService service)
        {
            this.service = service;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(service.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await service.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostTipoPregunta(TipoPregunta tipoPregunta)
        {

            var add = new TipoPregunta
            {
                Descripcion = tipoPregunta.Descripcion
            };

            await service.Insert(add);


            return Ok("Agregado! ");

        }
 
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoTipregunta(int id, TipoPregunta tipoPregunta)
        {
            var getId = await service.GetById(id);

            getId.Descripcion = tipoPregunta.Descripcion;

            return Ok(service.Update(getId));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoPregunta(int id)
        {
            return Ok(service.Delete(id));
        }
    }
}
