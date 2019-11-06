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
    public class UsuarioController : ApiController
    {
        UsuarioManager manager = new UsuarioManager();
        // GET: api/Usuario
        public IEnumerable<UsuarioBE> Get()
        {
            return manager.GetAll();
        }

        // GET: api/Usuario/5
        public UsuarioBE Get(int id)
        {
            return manager.Find(id);
        }

        // POST: api/Usuario
        public void Post(UsuarioBE usuario)
        {
            manager.Insert(usuario);
        }

        // PUT: api/Usuario/5
        public void Put(int id, UsuarioBE usuario)
        {
            usuario.IdUsuario = id;
            manager.Udpate(usuario);
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
            manager.Delete(id);
        }

        [HttpPost]
        [Route("api/Usuario/Login")]
        public UsuarioBE Login(UsuarioBE usuario)
        {
            return manager.Login(usuario.Correo, usuario.Contrasenia);
        }
    }
}
