using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using entityModels;
using bussinesModel;
using System.Xml.Serialization;
using System.IO;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace appWeb.Controllers
{
    public class ClientesController : Controller
    {

        #region "DECLARACIONES"

        clienteBussines obj_cliente      = new clienteBussines();
        utilitariosBussines obj_utilitarios  = new utilitariosBussines();

        #endregion


        #region "PROCEDIMIENTOS"


        //Lista de departamentos
        private void getDepartamento()
        {
            var departamentos = new SelectList(obj_utilitarios.FPub_ListaDepartamentos(), "Id_departamento", "Departamento_descripcion");
            ViewBag.departamentos = departamentos;
        }


        //Lista de Provincias (Json)
        public JsonResult getProvincia(int id)
        {
            var provincias = obj_utilitarios.FPub_ListaProvincia(id);
            return this.Json(provincias, JsonRequestBehavior.AllowGet);
        }


        //Lista de Distritos (Json)
        public JsonResult getDistrito(int id)
        {
            var distritos = obj_utilitarios.FPub_ListaDistritos(id);
            return this.Json(distritos, JsonRequestBehavior.AllowGet);
        }










        


        #endregion

        //Pagina principal Clientes
        public ActionResult Clientes()
        {
            var res = from c in obj_cliente.FPub_Listar_Clientes(string.Empty,string.Empty) select c;

            return View(res.ToList());
        }

        [HttpPost]
        public ActionResult Clientes(string v_CODIGO = " ",string v_CLIENTE = " ")
        {


            //Para mantener variables de busqueda
            ViewBag.codigo = v_CODIGO;
            ViewBag.cliente = v_CLIENTE;

            try { 

                var res = from c in obj_cliente.FPub_Listar_Clientes(v_CODIGO, v_CLIENTE) select c;
                return View(res.ToList());
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }

            return View();
        }
        /*
      [ChildActionOnly]
      public ActionResult callPartialView(int v_Modulo,string v_Id)
      {
          getDepartamento();



          if (v_Modulo == 1)
          {
              return PartialView("_AgregarCliente", new Cliente());

          }

          else if(v_Modulo == 2 && v_Id != null)
          {
              var clienteDetalle = obj_cliente.FPub_DetalleCliente(v_Id);
              return PartialView("_DetalleCliente", clienteDetalle);
          }


          return PartialView();
      }

        */
        public ActionResult _AgregarCliente()
        {
            getDepartamento();
            return PartialView(new Cliente());
        }


        [HttpPost]
        public ActionResult _AgregarCliente(Cliente cliente)
        {

            if (!ModelState.IsValid)
            {
                getDepartamento();
                return View(cliente);
            }
           

            try
            {
                int res = obj_cliente.FPub_MantenimientoCliente("1", cliente);
                return RedirectToAction("Clientes");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("error",ex);
            }

            return View();
        }


        public ActionResult _DetalleCliente(string id)
        {
            getDepartamento();
            var cliente = obj_cliente.FPub_DetalleCliente(id);

            return PartialView(cliente);
        }


        public ActionResult _EditarCliente(string id)
        {
            getDepartamento();
            var cliente = obj_cliente.FPub_DetalleCliente(id);

            return PartialView(cliente);
        }

        public ActionResult _EliminarCliente(string id)
        {
            getDepartamento();
            var cliente = obj_cliente.FPub_DetalleCliente(id);

            return PartialView(cliente);
        }


        public ActionResult AgregarCliente()
        {
            getDepartamento();
            return View();
        }

        [HttpPost]
        public ActionResult AgregarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int res = obj_cliente.FPub_MantenimientoCliente("1", cliente);

                    return RedirectToAction("Clientes", new { v_CODIGO=res.ToString()});

                }catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
               

            }
            getDepartamento();
            return View(cliente);
        }

        public ActionResult exporExcel()
        {
            return PartialView();
        }


        [HttpPost]
        public ActionResult exporExcel(string v_Cliente = " ")
        {


            try
            {


                var res = from c in obj_cliente.FPub_Listar_Clientes("", v_Cliente) select c;

                var grid = new GridView();

                grid.DataSource = res;
                grid.DataBind();

                grid.HeaderStyle.BackColor = System.Drawing.Color.SeaGreen;

                StringWriter stringWriter = new StringWriter();
                HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
                grid.RenderControl(htmlWriter);


                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("content-disposition", "attachment; filename= " + "Exportado desde SICNET-CLIENTES -" + DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.Charset = "";

                Response.Write(stringWriter.ToString());
                Response.End();





            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }


            return null;
        }


    }
}
