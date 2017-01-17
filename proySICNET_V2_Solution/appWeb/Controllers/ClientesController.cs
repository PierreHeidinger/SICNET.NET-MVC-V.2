using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using entityModels;
using bussinesModel;

namespace appWeb.Controllers
{
    public class ClientesController : Controller
    {

        clienteBussines obj_cliente = new clienteBussines();

        // GET: Clientes
        public ActionResult Clientes()
        {
            var res = from c in obj_cliente.FPub_Listar_Clientes("vacio","vacio") select c;

            return View(res.ToList());
        }

       [HttpPost]
       public ActionResult Clientes(string v_CODIGO,string v_CLIENTE)
        {
            ViewBag.v_CODIGO  = v_CODIGO;
            ViewBag.v_CLIENTE = v_CLIENTE;

            var res = from c in obj_cliente.FPub_Listar_Clientes(v_CODIGO, v_CLIENTE) select c;

            return View(res.ToList());
        }


        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Clientes/Edit/5
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

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Clientes/Delete/5
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
