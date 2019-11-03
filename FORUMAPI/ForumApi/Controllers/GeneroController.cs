using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ForumApi.Controllers
{
    public class GeneroController : ApiController
    {
        GeneroManager manager = new GeneroManager();
        // GET: api/Genero
        public IEnumerable<GeneroBE> Get()
        {
            return manager.GetAll();
        }

        // GET: api/Genero/5
        public GeneroBE Get(int id)
        {
            return manager.Find(id);
        }

        // POST: api/Genero
        public void Post(GeneroBE generoBE)
        {
            manager.Insert(generoBE);
        }

        // PUT: api/Genero/5
        public void Put(int id, [FromBody]GeneroBE generoBE)
        {
            generoBE.IdGenero = id;
            manager.Update(generoBE);
            
        }

        // DELETE: api/Genero/5
        public void Delete(int id)
        {
            manager.Delete(id);
        }
    }
}
