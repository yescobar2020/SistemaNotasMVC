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
            AlumnoET alumnoId = alumnoBL.AlumnoById_G(id);
            return View(alumnoId);
        }

        // POST: Alumno/Edit/5
        [HttpPost]
        public ActionResult Edit(AlumnoET alumnoET)
        {
            try
            {
                AlumnoET result = alumnoBL.Update(alumnoET);

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View(alumnoET);
            }
        }

        // GET: Alumno/Delete/5
        public ActionResult Delete(int id)
        {
            bool alumnoId = alumnoBL.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
