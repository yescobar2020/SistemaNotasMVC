

using DA.Configuracion;
using ET.Configuracion;

namespace BL.Configuracion
{
     public class MateriasBL
    {
        MateriasDA materiasDA = new MateriasDA();
        public MateriasET Insertar(MateriasET materias)
        {
            return materiasDA.Insertar(materias);
        }

        public ListMateriasET Get()
        {
            return materiasDA.Get();
        }
    }
}
