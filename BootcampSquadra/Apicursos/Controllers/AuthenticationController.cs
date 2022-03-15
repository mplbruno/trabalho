using Apicursos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Apicursos.Helpers;
using Apicursos.Data;

namespace Apicursos.Controllers
{
   
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly CursoContext _context;

        public AuthenticationController(CursoContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Prencher o Type conforme o nível de aotorização:
        /// 1 - Gerente
        /// 2 - Secretária 
        /// 3 - Demais Usuários
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///    
        ///     {
        ///        "type": int,
        ///        "name": "string",
        ///        "email": "email@.com"
        ///        "passoword": "string"
        ///        "cpf": "string"
        ///     }
        ///
        /// </remarks>
        /// 
        /// 
        /// 
        /// 
        [HttpPost]
        [AllowAnonymous]
        [Route("/api/v1/authentication")]
      
        public async Task<ActionResult<Users>> PostCourses(Users users)
        {
            _context.Users.Add(users);
            await _context.SaveChangesAsync();

          
            try
            {
                var userExists = users;

                if (userExists == null)
                    return BadRequest(new { Message = "Email e/ou senha está(ão) inválido(s)." });


                if (userExists.Password != users.Password)
                    return BadRequest(new { Message = "Email e/ou senha está(ão) inválido(s)." });


                var token = AuthenticationJwt.GenerateToken(userExists);

                return Ok(new
                {
                    Token = token,
                    Usuario = userExists
                });

            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Ocorreu algum erro interno na aplicação, por favor tente novamente." });
            }
          
        }
    }
}
