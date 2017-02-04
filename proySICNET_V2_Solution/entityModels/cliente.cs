using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace entityModels
{
    public class Cliente
    {
        [Display(Name = "Codigo")]
        public string codigo { get; set; }

        [Display(Name = "Documento")]
        [Required(ErrorMessage ="Ingrese el Nª de Documentos !")]
        public string documento { get; set; }

        [Display(Name = "Codigo Documento")]
        [Required(ErrorMessage = "Debe seleccionar un tipo de Documento!")]
        public string tipo_documento { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Ingrese los nombres!")]
        public string nombres { get; set; }

        [Display(Name = "Apellido Pat.")]
        [Required(ErrorMessage = "Ingrese por lo menos el Apellido Pat. !")]
        public string apellido_paterno { get; set; }

        [Display(Name = "Apellido Mat.")]
        public string apellido_materno { get; set; }

        [Display(Name="Razon social")]
        public string razon_social { get; set; }

        [Display(Name = "Fecha Nac.")]      
        public DateTime fecha_nacimiento { get; set; }

        [Display(Name = "Fecha Reg.")]
        public DateTime fecha_registro { get; set; }

        [Display(Name = "Departamento")]
        public int departamento { get; set; }

        [Display(Name = "Distrito")]
        public int distrito { get; set; }

        [Display(Name = "Provincia")]
        public int provincia { get; set; }

        [Display(Name = "Direccion")]
        public string direccion { get; set; }

        [Display(Name = "Tipo Doc.")]
        public string tipo_documento_descripcion { get; set; }

        [Display(Name = "Dep.")]
        public string departamento_descripcion;

        [Display(Name = "Prov.")]
        public string provincia_descripcion;

        [Display(Name = "Distr.")]
        public string distrito_descripcion;
       

        //Constructor vacio
        public Cliente()
        {

        }


        //Cliente busqueda Panel
        public Cliente(string codigo, string documento, string tipo_documento, string nombres, string apellido_paterno, string apellido_materno, DateTime fecha_nacimiento, DateTime fecha_registro, int departamento, int distrito, int provincia, string direccion)
        {
            this.codigo = codigo;
            this.documento = documento;
            this.tipo_documento = tipo_documento;
            this.nombres = nombres;
            this.apellido_paterno = apellido_paterno;
            this.apellido_materno = apellido_materno;
            this.fecha_nacimiento = fecha_nacimiento;
            this.fecha_registro = fecha_registro;
            this.departamento = departamento;
            this.distrito = distrito;
            this.provincia = provincia;
            this.direccion = direccion;
            this.tipo_documento_descripcion = (this.tipo_documento == "1") ? "DNI" : "RUC";
        }

        
        //Cliente mostrar detalle
        public Cliente(string codigo, string documento,string nombres, string apellido_paterno, string apellido_materno, DateTime fecha_nacimiento, DateTime fecha_registro, string direccion,string departamento_descripcion,string provincia_descripcion,string distrito_descripcion)
        {
            this.codigo = codigo;
            this.documento = documento;
         // this.tipo_documento = tipo_documento;
            this.nombres = nombres;
            this.apellido_paterno = apellido_paterno;
            this.apellido_materno = apellido_materno;
            this.fecha_nacimiento = fecha_nacimiento;
            this.fecha_registro = fecha_registro;
            this.direccion = direccion;
            this.tipo_documento_descripcion = (this.tipo_documento == "1") ? "DNI" : "RUC";
            this.departamento_descripcion = departamento_descripcion;
            this.provincia_descripcion = provincia_descripcion;
            this.distrito_descripcion = distrito_descripcion;


        }

    }
}
