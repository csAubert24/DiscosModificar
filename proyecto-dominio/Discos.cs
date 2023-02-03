using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_dominio
{
     public class Discos
    {
        public int Id { get; set; }
        [DisplayName("Título")]
        public string titulo { get; set; }
        [DisplayName("Canciones")]
        public int canciones { get; set; }  
        
        public string url { get; set; }

        public elemento Estilo { get; set; }
        [DisplayName("Formato")]
        public elemento formato { get; set; }
    }
}
