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
            int i, j;
            string aux;
            int auxn;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Nombre_desc" : "";
            ViewBag.LastSortParm = String.IsNullOrEmpty(sortOrder) ? "Apellido_desc" : "Apellido";
            switch(sortOrder)
            {
                case "Nombre_desc":
                    try
                    {
                        for(i = 0; i < Data.Instance.personaslist.Count() - 1; i++)
                        {
                            for(j = 0; j < Data.Instance.personaslist.Count() - i - 1; j++)
                            {
                                if(Data.Instance.personaslist[i].Nombre[i] < Data.Instance.personaslist[j + 1].Nombre[j + 1])
                                {
                                    SwapN(i,j);
                                }
                            }
                        }
                        return RedirectToAction(nameof(Index));
                    }
                    catch(ArgumentException e)
                    {

                    }
                    break;
                case "Apellido_desc":
                    try
                    {
                        for (i = 0; i < Data.Instance.personaslist.Count(); i++)
                        {
                            for (j = i + 1; j < Data.Instance.personaslist.Count(); j++)
                            {
                                if (Data.Instance.personaslist[i].Apellido[i] < Data.Instance.personaslist[j].Apellido[j])
                                {
                                    auxn = Data.Instance.personaslist[i].Id;
                                    Data.Instance.personaslist[i].Id = Data.Instance.personaslist[j].Id;
                                    Data.Instance.personaslist[j].Id = auxn;

                                    aux = Data.Instance.personaslist[i].Nombre;
                                    Data.Instance.personaslist[i].Nombre = Data.Instance.personaslist[j].Nombre;
                                    Data.Instance.personaslist[j].Nombre = aux;

                                    aux = Data.Instance.personaslist[i].Apellido;
                                    Data.Instance.personaslist[i].Apellido = Data.Instance.personaslist[j].Apellido;
                                    Data.Instance.personaslist[j].Apellido = aux;

                                    aux = Data.Instance.personaslist[i].Telefono;
                                    Data.Instance.personaslist[i].Telefono = Data.Instance.personaslist[j].Telefono;
                                    Data.Instance.personaslist[j].Telefono = aux;

                                    aux = Data.Instance.personaslist[i].Descripcion;
                                    Data.Instance.personaslist[i].Descripcion = Data.Instance.personaslist[j].Descripcion;
                                    Data.Instance.personaslist[j].Descripcion = aux;
                                }
                            }
                        }
                        return RedirectToAction(nameof(Index));
                    }
                    catch (ArgumentException e)
                    {

                    }
                    break;
                case "Apellido":
                    try
                    {
                        for (i = 0; i < Data.Instance.personaslist.Count(); i++)
                        {
                            for (j = i + 1; j < Data.Instance.personaslist.Count(); j++)
                            {
                                if (Data.Instance.personaslist[i].Apellido[i] > Data.Instance.personaslist[j].Apellido[0])
                                {
                                    auxn = Data.Instance.personaslist[i].Id;
                                    Data.Instance.personaslist[i].Id = Data.Instance.personaslist[j].Id;
                                    Data.Instance.personaslist[j].Id = auxn;

                                    aux = Data.Instance.personaslist[i].Nombre;
                                    Data.Instance.personaslist[i].Nombre = Data.Instance.personaslist[j].Nombre;
                                    Data.Instance.personaslist[j].Nombre = aux;

                                    aux = Data.Instance.personaslist[i].Apellido;
                                    Data.Instance.personaslist[i].Apellido = Data.Instance.personaslist[j].Apellido;
                                    Data.Instance.personaslist[j].Apellido = aux;

                                    aux = Data.Instance.personaslist[i].Telefono;
                                    Data.Instance.personaslist[i].Telefono = Data.Instance.personaslist[j].Telefono;
                                    Data.Instance.personaslist[j].Telefono = aux;

                                    aux = Data.Instance.personaslist[i].Descripcion;
                                    Data.Instance.personaslist[i].Descripcion = Data.Instance.personaslist[j].Descripcion;
                                    Data.Instance.personaslist[j].Descripcion = aux;
                                }
                            }
                        }
                        return RedirectToAction(nameof(Index));
                    }
                    catch (ArgumentException e)
                    {

                    }
                    break;
                default:
                    try
                    {
                        for (i = 0; i < Data.Instance.personaslist.Count() - 1; i++)
                        {
                            for (j = 0; j < Data.Instance.personaslist.Count() - i - 1; j++)
                            {
                                if (Data.Instance.personaslist[i].Nombre[i] < Data.Instance.personaslist[j + 1].Nombre[j + 1])
                                {
                                    SwapN(j, i);
                                }
                            }
                        }
                        return RedirectToAction(nameof(Index));
                    }
                    catch (ArgumentException e)
                    {

                    }
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
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
        public void SwapN(int x, int y)
        {
            string auxN, auxA, auxT, auxD;
            int auxnu;
            auxnu = Data.Instance.personaslist[y].Id;
            Data.Instance.personaslist[y].Id = Data.Instance.personaslist[y + 1].Id;
            Data.Instance.personaslist[y + 1].Id = auxnu;

            auxN = Data.Instance.personaslist[y].Nombre;
            Data.Instance.personaslist[y].Nombre = Data.Instance.personaslist[y + 1].Nombre;
            Data.Instance.personaslist[y + 1].Nombre = auxN;

            auxA = Data.Instance.personaslist[y].Apellido;
            Data.Instance.personaslist[y].Apellido = Data.Instance.personaslist[y + 1].Apellido;
            Data.Instance.personaslist[y + 1].Apellido = auxA;

            auxT = Data.Instance.personaslist[y].Telefono;
            Data.Instance.personaslist[y].Telefono = Data.Instance.personaslist[y + 1].Telefono;
            Data.Instance.personaslist[y + 1].Telefono = auxT;

            auxD = Data.Instance.personaslist[y].Descripcion;
            Data.Instance.personaslist[y].Descripcion = Data.Instance.personaslist[y + 1].Descripcion;
            Data.Instance.personaslist[y + 1].Descripcion = auxD;
        }
    }
}
