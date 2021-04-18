using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.System.Locals
{
    public class WardVM
    {
        public int Id { get; set; }
        public string type { get; set; }

        [Display(Name = "Tên")]
        public string Name { get; set; }
    }
}
