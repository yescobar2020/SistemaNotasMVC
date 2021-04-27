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
    }
}
