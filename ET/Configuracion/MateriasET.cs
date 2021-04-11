

using System.Collections.Generic;

namespace ET.Configuracion
{
    public class ListMateriasET: List<MateriasET> {}

    public class MateriasET
    {
        public int MTId { get; set; }
        public string MTNombre { get; set; }
    }
}
