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
    public class PaisesController : Controller
    {
        PaisesBL paisesBL = new PaisesBL();
        // GET: Paises
        public ActionResult Index()
        {
            PaisesModel model = new PaisesModel();
            model.Paises = paisesBL.Get();
            return View(model);
            
        }

        // GET: Paises/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Paises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paises/Create
        [HttpPost]
        public ActionResult Create(PaisesET pais)
        {
            try
            {
                PaisesET pai = paisesBL.Insertar(pais);
                if (pai.PAId == 0)
                {
                    ViewBag.Error = "Error al insertar";
                    return RedirectToAction("Index", pais);
                }


                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Paises/Edit/5
        public ActionResult Edit(int id)
        {
            PaisesET paisId = paisesBL.PaisesById_G(id);
            return View(paisId);
        }

        // POST: Paises/Edit/5
        [HttpPost]
        public ActionResult Edit(PaisesET paisesET)
        {
            try
            {
                PaisesET result = paisesBL.Update(paisesET);

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View(paisesET);
            }
        }

        // GET: Paises/Delete/5
        public ActionResult Delete(int id)
        {
            bool paisId = paisesBL.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
