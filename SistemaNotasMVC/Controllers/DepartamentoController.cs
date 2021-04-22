using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.Configuracion;
using ET.Configuracion;
using SistemaNotasMVC.Models;

namespace SistemaNotasMVC.Controllers
{
    public class DepartamentoController : Controller
    {
        PaisesBL paisesBL = new PaisesBL();

        DepartamentoBL departamentoBL = new DepartamentoBL();
        // GET: Departamento
        public ActionResult Index()
        {
            DepartamentoModel model = new DepartamentoModel();
            model.Departamentos = departamentoBL.Get();
            return View(model);
        }

        // GET: Departamento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Departamento/Create
        public ActionResult Create()
        {
            DepartamentoCreateModel model = new DepartamentoCreateModel();
            model.Paises = paisesBL.Get();
            return View(model);
        }

        // POST: Departamento/Create
        [HttpPost]
        public ActionResult Create(DepartamentoET departamento)
        {
            try
            {
                DepartamentoET dep = departamentoBL.Insertar(departamento);
                if(dep.DPId == 0)
                {
                    ViewBag.Error = "Error al insertar";
                    return RedirectToAction("Index", departamento);
                }


                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Departamento/Edit/5
        public ActionResult Edit(int id)
        {
            DepartamentoET departamentoId = departamentoBL.DepartamentoById_G(id);
            return View(departamentoId);
        }

        // POST: Departamento/Edit/5
        [HttpPost]
        public ActionResult Edit(DepartamentoET departamentoET)
        {
            try
            {
                DepartamentoET result = departamentoBL.Update(departamentoET);

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View(departamentoET);
            }
        }

        // GET: Departamento/Delete/5
        public ActionResult Delete(int id)
        {
            bool departamentoId = departamentoBL.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
