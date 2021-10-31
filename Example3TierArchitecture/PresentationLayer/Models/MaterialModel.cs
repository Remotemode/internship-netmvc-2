using System.ComponentModel.DataAnnotations;
using DataLayer.Entityes;

namespace PresentationLayer.Models
{
    public class MaterialViewModel : PageViewModel
    {
        public Material Material { get; set; }
        public Material NextMaterial { get; set; }
    }

    public class MaterialEditModel : PageEditModel
    {
        [Required]
        public int Directoryid { get; set; }
    }
}
