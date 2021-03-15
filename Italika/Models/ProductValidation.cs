using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Italika.Models
{
    [MetadataType(typeof(ProductMetaData))]
    public partial class Producto
    {
        public Tipo TipoP { get; set; }
    }

    public class ProductMetaData
    {
        [Required(ErrorMessage ="SKU Requerido")]
        [Display(Name ="SKU")]
        public string SKU { get; set; }

        [Required(ErrorMessage = "Fert Requerido")]
        [Display(Name ="Fert")]
        public string Fert { get; set; }

        [Required(ErrorMessage = "Modelo Requerido")]
        [Display(Name = "Modelo Producto")]
        public string Modelo { get; set; }

        [Display(Name ="Tipo Producto")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Número de Serie Requerido")]
        [Display(Name ="Número Serie")]
        public string NumeroSerie { get; set; }

        [Required(ErrorMessage = "Fecha Requerida")]
        [Display(Name ="Fecha")]
        public DateTime Fecha { get; set; }

    }

}