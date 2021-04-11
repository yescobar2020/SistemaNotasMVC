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
    public class MateriasController : Controller
    {
        MateriasBL materiasBL = new MateriasBL();

        // GET: Materias
        public ActionResult Index()
        {
            MateriasModel model = new MateriasModel();
            model.Materias = materiasBL.Get();
            return View(model);
        }


        // GET: Materias/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Materias/Create
        [HttpPost]
        public ActionResult Create( MateriasET materia) 
        {
            try
            {
                MateriasET mat = materiasBL.Insertar( materia);
                if(mat.MTId == 0)
                {
                    ViewBag.Error = "Error al insertar";
                    return RedirectToAction("Index",materia);
                }
               

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Materias/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Materias/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Materias/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Materias/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
