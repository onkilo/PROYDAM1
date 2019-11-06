using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ForumApi.Controllers
{
    public class LibroController : ApiController
    {
        LibroManager manager = new LibroManager();
        // GET: api/Libro
        [HttpGet]
        [Route("api/Libro/Usuario/{idUser}")]
        public IEnumerable<LibroBE> GetByUser(int idUser)
        {
            return manager.GetByUser(idUser);
        }

        // GET: api/Libro/5
        [HttpGet]
        [Route("api/Libro/NoUsuario/{idUser}")]
        public IEnumerable<LibroBE> GetNotByUser(int idUser)
        {
            return manager.GetNotByUser(idUser);
        }

        [HttpGet]
        [Route("api/Libro/Genero/{idGenero}")]
        public IEnumerable<LibroBE> GetByGenero(int idGenero)
        {
            return manager.GetByGenero(idGenero);
        }

        [HttpGet]
        [Route("api/Libro/Nombre/{nombre}")]
        public IEnumerable<LibroBE> GetByNombre(string nombre)
        {
            return manager.GetByNombre(nombre);
        }

        public LibroBE Get(int id)
        {
            return manager.Find(id);
        }

        // POST: api/Libro
        public void Post(LibroBE libro)
        {

            if(libro.Imagen64 != null && libro.Imagen64 != "")
            {
                string path = HttpContext.Current.Server.MapPath("~/Upload/Libro/");
                byte[] img = Convert.FromBase64String(libro.Imagen64);

                if(!System.IO.File.Exists(path + libro.Imagen))
                {
                    System.IO.File.WriteAllBytes(path + libro.Imagen, img);
                }
            }

            manager.Insert(libro);
        }

        // PUT: api/Libro/5
        public void Put(int id, LibroBE libro)
        {
            libro.IdLibro = id;
            manager.Update(libro);
        }

        // DELETE: api/Libro/5
        public void Delete(int id)
        {
            manager.Delete(id);
        }
    }
}
