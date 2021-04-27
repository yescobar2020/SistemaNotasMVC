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
    public class AlumnoController : Controller
    {
        AlumnoBL alumnoBL = new AlumnoBL();
        // GET: Alumno
        public ActionResult Index()
        {
            AlumnoModel model = new AlumnoModel();
            model.Alumnos = alumnoBL.Get();
            return View(model);
        }

        // GET: Alumno/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Alumno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alumno/Create
        [HttpPost]
        public ActionResult Create(AlumnoET alumno)
        {
            try
            {
                AlumnoET al = alumnoBL.Insertar(alumno);
                if(al.ALId == 0)
                {
                    ViewBag.Error = "Error al insertar";
                    return RedirectToAction("Index", alumno);
                }

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Alumno/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Alumno/Edit/5
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

        // GET: Alumno/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Alumno/Delete/5
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
