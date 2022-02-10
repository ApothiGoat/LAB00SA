using Lab_1.Help;
using LAB_01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB_01.Controllers
{
    public class PersonasC : Controller
    {
        // GET: HomeController1
        public ActionResult Index(string sortOrder)
        {
            string nom = "", last = "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Nombre_desc" : "Nombre";
            ViewBag.LastSortParm = String.IsNullOrEmpty(sortOrder) ? "Apellido_desc" : "Apellido";
            switch(sortOrder)
            {
                case "Nombre_desc":
                    var test = Data.Instance.personaslist.Find(per => per.Nombre == "Nombre");
                    break;
                case "Apellido_desc":
                    
                    break;
                case "Nombre":
                    
                    break;
                case "Apellido":
                    
                    break;
            }
            return View(Data.Instance.personaslist);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            var model = Data.Instance.personaslist.Find(per => per.Id == id);
            return View(model);
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View(new Personas());
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var respone =(Personas.Save(new Personas
                {
                    Id = int.Parse(collection["ID"]),
                    Nombre = collection["Nombre"],
                    Apellido = collection["Apellido"],
                    Telefono = collection["Telefono"],
                    Descripcion = collection["Descripcion"],
                }));
                if (respone)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            var model = Data.Instance.personaslist.Find(per => per.Id == id);
            return View(model);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var respone = (Personas.Edit(new Personas
                {
                    Id = int.Parse(collection[""]),
                    Nombre = collection[""],
                    Apellido = collection[""],
                    Telefono = collection[""],
                    Descripcion = collection[""],
                }));
                if (respone)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            var model = Data.Instance.personaslist.Find(per => per.Id == id);
            return View();
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
