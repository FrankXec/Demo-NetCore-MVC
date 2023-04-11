using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models.ViewModels
{
    public class BeerViewModel
    {
        public int? BeerId { get; set; }
        [Required]
        [Display(Name="Nombre")]
        public string Name { get; set; }
        [Display(Name="Marca")]
        public int BrandId { get; set; }
    }
}
