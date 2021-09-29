using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewtlabAPI.Data;
using NewtlabAPI.Models;
using NewtlabAPI.Services.IServices;

namespace NewtlabAPI.Services.Service
{
    public class PreguntaService : IPreguntaService
    {
        private readonly NewtLabContext context;
        public PreguntaService(NewtLabContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            var getId = context.Preguntas.Find(id);
            context.Remove(getId);
            context.SaveChanges();


            return true;
        }

        public IEnumerable<Pregunta> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Pregunta> GetById(int id)
        {
            return await context.Preguntas.FindAsync(id);
        }

        public async Task Insert(Pregunta pregunta)
        {
            context.Preguntas.Add(pregunta);
            await context.SaveChangesAsync();
        }

        public bool Update(Pregunta pregunta)
        {
            context.Preguntas.Update(pregunta);
            context.Entry(pregunta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            context.SaveChanges();

            return true;
        }
    }
}
