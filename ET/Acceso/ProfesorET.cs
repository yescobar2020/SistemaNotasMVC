using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Acceso
{
    public class ListProfesorET: List<ProfesorET> { }
    public class ProfesorET
    {
        public int PFId { get; set; }
        public string PFNombre { get; set; }
        public string PFDocumento { get; set; }

    }
}
