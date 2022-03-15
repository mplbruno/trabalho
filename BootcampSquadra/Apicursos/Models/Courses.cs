using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apicursos.Models
{
    public class Courses
    {
  
        public int Id { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public int Status { get; set; }    

    }


}
   
   
