using appapi.Models;
using appapi.Routs;
using appapi.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
       private Usuarios usuarios = new Usuarios(); 
       [HttpGet]
       public IActionResult Get()
       {
           return Ok(usuarios.GetUsers());
       }

       [HttpGet("{key}")]
       public IActionResult Get(string key)
       {
           var user = usuarios.GetUser(key);

           if (user.Clave == null)
           {
               var notFound = NotFound("El Usuario " + key + " no fue encontrado.");

               return notFound;
           }

           return Ok(user);
       }


        [HttpPost("actualizar")]
       public IActionResult UpdateUser(User user)
       {
           int resp = usuarios.UpdateUser(user);

            if (resp == 0)
            {
                var notFound = NotFound("El Usuario " + user.Nombre + " " + user.ApellidoP + " " + user.ApellidoM +  " no fue actualizado.");

                return notFound;
            }

            return Ok( "Usuario con la clave [ " + user.Clave + " ] fue actualizado exitosomante !.");
       }
        
        [HttpPost("agregar")]
       public IActionResult AddUser(User user)
       {
           int resp = usuarios.AddUser(user);

            if (resp == 0)
            {
                var notFound = NotFound("El Usuario " + user.Nombre + " " + user.ApellidoP + " " + user.ApellidoM +  " no fue agregado.");

                return notFound;
            }

            return Ok("El Usuario " + user.Nombre + " " + user.ApellidoP + " " + user.ApellidoM + " fue agregado exitosamente.");
       }


    }
}
