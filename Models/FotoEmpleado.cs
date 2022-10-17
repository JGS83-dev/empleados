using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace empleados.Models
{

    public partial class FotoEmpleado
    {
        public int IdFoto { get; set; }

        [Display(Name = "Empleado")]
        [Required(ErrorMessage = "Seleccione un empleado")]
        public int IdUsuario { get; set; }

        [Display(Name = "Foto del empleado")]
        [Required(ErrorMessage = "Ingrese URL de foto del empleado")]
        [DataType(DataType.Url)]
        public string Foto { get; set; } = null!;

        [Display(Name = "Empleado")]
        public virtual Empleado IdUsuarioNavigation { get; set; } = null!;
    }
}
