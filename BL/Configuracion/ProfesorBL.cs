using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.Configuracion;
using ET.Acceso;

namespace BL.Configuracion
{
    public class ProfesorBL
    {
        ProfesorDA profesorDA = new ProfesorDA();

        public ListProfesorET Get()
        {
            return profesorDA.Get();
        }
    }
}
