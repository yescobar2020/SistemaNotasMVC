using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.Configuracion;
using ET.Configuracion;

namespace BL.Configuracion
{
    
    public class AlumnoBL
    {
        AlumnoDA alumnoDA = new AlumnoDA();

        public ListAlumnoET Get()
        {
            return alumnoDA.Get();
        }
        public AlumnoET Insertar(AlumnoET alumnos)
        {

            return alumnoDA.Insertar(alumnos);
        }
        public AlumnoET Update(AlumnoET alumno)
        {
            return alumnoDA.Update(alumno);
        }
        public AlumnoET AlumnoById_G(int id)
        {
            return alumnoDA.AlumnoById_G(id);
        }
        public bool Delete(int id)
        {
            return alumnoDA.Delete(id);
        }
    }
}
