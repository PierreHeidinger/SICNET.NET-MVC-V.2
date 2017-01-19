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

        #region "DECLARACIONES"

        clienteBussines obj_cliente      = new clienteBussines();
        utilitariosBussines obj_utilitarios  = new utilitariosBussines();

        #endregion


        #region "PROCEDIMIENTOS"


        private void setear_departamentos()
        {
            var departamentos = new SelectList(obj_utilitarios.FPub_ListaDepartamentos(), "Id_departamento", "Departamento_descripcion");
            ViewBag.departamentos = departamentos;
        }

        public JsonResult GetDepartamentos()
        {
            var departamentos = obj_utilitarios.FPub_ListaDepartamentos();
            return this.Json(departamentos, JsonRequestBehavior.AllowGet);
        }
        

        #endregion

        // GET: Clientes
        public ActionResult Clientes()
        {
            var res = from c in obj_cliente.FPub_Listar_Clientes(string.Empty,string.Empty) select c;

            return View(res.ToList());
        }

       [HttpPost]
       public ActionResult Clientes(string v_CODIGO,string v_CLIENTE)
        {

            var res = from c in obj_cliente.FPub_Listar_Clientes(v_CODIGO, v_CLIENTE) select c;

            return View(res.ToList());
        }


        // GET: Clientes/Details/5
        public ActionResult Cliente_detalle(int codigo)
        {
            setear_departamentos();

            if (ModelState.IsValid)
            {
                var cliente = obj_cliente.FPub_DetalleCliente(codigo.ToString());
                
                return View(cliente);
            }

            return View();
        }

        // GET: Clientes/Create
        public ActionResult Cliente_agregar(int? codigo)
        {
            setear_departamentos();

            if (codigo != null)
            {
                var cliente = obj_cliente.FPub_DetalleCliente(codigo.ToString());

                return View(cliente);
            }                      
            
          

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
