using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewtlabAPI.Data;
using NewtlabAPI.Models;
using NewtlabAPI.Services.IServices;

namespace NewtlabAPI.Services.Service
{
    public class BancoPreguntasServices : IBancoPreguntaService
    {
        private readonly NewtLabContext context;

        public BancoPreguntasServices(NewtLabContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            var getId = context.BancoPreguntas.Find(id);
            context.BancoPreguntas.Remove(getId);
            context.SaveChanges();

            return true;

        }

        public IEnumerable<BancoPregunta> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<BancoPregunta> GetById(int id) => await context.BancoPreguntas.FindAsync(id);

        public async Task Insert(BancoPregunta bancoPregunta)
        {
            context.BancoPreguntas.Add(bancoPregunta);
            await context.SaveChangesAsync();
        }

        public bool Update(BancoPregunta bancoPregunta)
        {
            context.BancoPreguntas.Update(bancoPregunta);
            context.Entry(bancoPregunta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return true;
        }
    }

}
