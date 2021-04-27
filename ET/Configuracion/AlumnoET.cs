using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Configuracion
{
    public class  ListAlumnoET: List<AlumnoET> { }
    public class AlumnoET
    {
        public int ALId { get; set; }
        public string ALDocumento { get; set; }
        public string ALNombre { get; set; }
    }
}
