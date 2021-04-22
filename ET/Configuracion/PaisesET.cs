using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Configuracion
{
    public class ListPaisesET: List<PaisesET> {}
public class PaisesET
    {
        public int PAId { get; set; }
        public string PAName { get; set; }
        public string PALanguage{ get; set; }
        public DateTime PACreate{ get; set; }
        public DateTime PAModified{ get; set; }

    }
}
