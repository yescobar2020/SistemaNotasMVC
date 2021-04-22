using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ET.Configuracion
{
    public class ListDepartamentoET : List<DepartamentoET> { }
    public class DepartamentoET
    {
        public int DPId { get; set; }
        public string DPNombre { get; set; }
        public string DPCodigoPostal { get; set; }
        public int DPPaisId { get; set; }
        public DateTime DPCreado { get; set; }
        public DateTime DPModificado { get; set; }
    }

}
