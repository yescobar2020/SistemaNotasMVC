using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.Configuracion;
using ET.Configuracion;

namespace BL.Configuracion
{
    public class DepartamentoBL
    {
        DepartamentoDA departamentoDA = new DepartamentoDA();
        public ListDepartamentoET Get()
        {
            return departamentoDA.Get();
        }
        public DepartamentoET Insertar(DepartamentoET departamentos)
        {
            return departamentoDA.Insertar(departamentos);
        }
        public DepartamentoET DepartamentoById_G(int id)
        {
            return departamentoDA.DepartamentoById_G(id);
        }
        public DepartamentoET Update(DepartamentoET departamento)
        {
            return departamentoDA.Update(departamento);
        }
        public bool Delete(int id)
        {
            return departamentoDA.Delete(id);
        }
    }
}
