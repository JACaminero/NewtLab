using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewtlabAPI.Models;
using NewtlabAPI.Services.IServices;

namespace NewtlabAPI.Services
{
    public class BancoPreguntasServices : IBancoPreguntaService
    {
        public BancoPreguntasServices()
        {
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BancoPregunta> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BancoPregunta> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(BancoPregunta bancoPregunta)
        {
            throw new NotImplementedException();
        }

        public bool Update(BancoPregunta bancoPregunta)
        {
            throw new NotImplementedException();
        }
    }
}
