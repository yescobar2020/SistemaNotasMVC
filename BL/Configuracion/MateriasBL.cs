

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
        public MateriasET Update(MateriasET materias)
        {
            return materiasDA.Update(materias);
        }
        public MateriasET MateriasById_G(int id)
        {
            return materiasDA.MateriasById_G(id);
        }
        public bool Delete(int id)
        {
            return materiasDA.Delete(id);
        }
    }
}
