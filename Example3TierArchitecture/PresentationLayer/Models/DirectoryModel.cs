using System.Collections.Generic;
using DataLayer.Entityes;

namespace PresentationLayer.Models
{
    public class DirectoryViewModel : PageViewModel
    {
        public Directory Directory { get; set; }
        public List<MaterialViewModel> Materials { get; set; }
    }

    public class DirectoryEditModel : PageEditModel
    {
    }
}
