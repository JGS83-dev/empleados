using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace empleados.Models
{
    public partial class Empleado
    {
        public int IdEmpleado { get; set; }

        [Display(Name = "Nombre(s) del empleado")]
        [Required(ErrorMessage = "Ingrese el nombre(s) del empleado")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Apellido(s) del empleado")]
        [Required(ErrorMessage = "Ingrese el apellido(s) del empleado")]
        [DataType(DataType.Text)]
        public string Apellido { get; set; } = null!;

        [Display(Name = "Telefono del empleado")]
        [Required(ErrorMessage = "Ingrese el Telefono del empleado")]
        [RegularExpression(@"\([0-9]{3}\) [0-9]{4}-[0-9]{4}", ErrorMessage = "El formato del telefono es: formato (XXX) XXXX-XXXX")]
        public string Telefono { get; set; } = null!;

        [Display(Name = "Correo del empleado")]
        [Required(ErrorMessage = "Ingrese el correo del empleado")]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; } = null!;

        [Display(Name = "Fecha de contratacion del empleado")]
        [Required(ErrorMessage = "Ingrese Fecha de contratacion del empleado")]
        //Aqui se puede aplicar un singleton para el formato de fecha de forma global
        [DisplayFormat(DataFormatString = "{0:0:MM/dd/yyyy}", ApplyFormatInEditMode= true)]
        public DateTime FechaContratacion { get; set; }

        public virtual FotoEmpleado? FotoEmpleado { get; set; }
    }
}
