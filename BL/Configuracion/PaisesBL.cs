using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.Configuracion;
using ET.Configuracion;

namespace BL.Configuracion
{
    public class PaisesBL
    {
        PaisesDA paisesDA = new PaisesDA();
        public PaisesET Insertar(PaisesET paises)
        {
            return paisesDA.Insertar(paises);
        }

        public ListPaisesET Get()
        {
            return paisesDA.Get();
        }
        public PaisesET PaisesById_G(int id)
        {
            return paisesDA.PaisesById_G(id);
        }
        public PaisesET Update(PaisesET paises)
        {
            return paisesDA.Update(paises);
        }
        public bool Delete(int id)
        {
            return paisesDA.Delete(id);
        }
    }
}
