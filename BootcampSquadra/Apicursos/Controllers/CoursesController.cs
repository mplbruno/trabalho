using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apicursos.Data;
using Apicursos.Models;
using Microsoft.AspNetCore.Authorization;

namespace Apicursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly CursoContext _context;

        public CoursesController(CursoContext context)
        {
            _context = context;
        }
       
        // GET: api/Courses
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Courses>>> GetCourser()
        {
            return await _context.Courser.ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Manager,Secretary")]
        public async Task<ActionResult<Courses>> GetCourses(int id)
        {
            var courses = await _context.Courser.FindAsync(id);

            if (courses == null)
            {
                return NotFound();
            }

            return courses;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Manager,Secretary")]
        public async Task<IActionResult> PutCourses(int id, Courses courses)
        {
            if (id != courses.Id)
            {
                return BadRequest();
            }

            _context.Entry(courses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        /// <summary>
        /// Prencher o Status conforme  situação:
        /// 1 - Previsto
        /// 2 - Em Andamento  
        /// 3 - Concluído
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///    
        ///     {
        ///        "title": "string",
        ///        "duration": "string",
        ///        "status": int
        ///     }
        ///
        /// </remarks>
        /// 
        /// 
        /// 
        /// 

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Manager,Secretary")]

        public async Task<ActionResult<Courses>> PostCourses(Courses courses)

        {
            _context.Courser.Add(courses);
            await _context.SaveChangesAsync();

            return courses;

            //return CreatedAtAction("GetCourses", new { id = courses.Id }, courses);
            //return CreatedAtAction("GetCourses", courses);


        }

       
        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteCourses(int id)
        {
            var courses = await _context.Courser.FindAsync(id);
            if (courses == null)
            {
                return NotFound();
            }

            _context.Courser.Remove(courses);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoursesExists(int id)
        {
            return _context.Courser.Any(e => e.Id == id);
        }
    }
}
