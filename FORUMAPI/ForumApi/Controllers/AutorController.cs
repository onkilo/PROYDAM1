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
    public class AutorController : ApiController
    {
        AutorManager manager = new AutorManager();
        // GET: api/Autor
        public IEnumerable<AutorBE> Get()
        {
            return manager.GetAll();
        }

        // GET: api/Autor/5
        public AutorBE Get(int id)
        {
            return manager.Find(id);
        }

        // POST: api/Autor
        public void Post(AutorBE autor)
        {
            manager.Insert(autor);
        }

        // PUT: api/Autor/5
        public void Put(int id, AutorBE autor)
        {
            autor.IdAutor = id;
            manager.Update(autor);
        }

        // DELETE: api/Autor/5
        public void Delete(int id)
        {
            manager.Delete(id);
        }
    }
}
