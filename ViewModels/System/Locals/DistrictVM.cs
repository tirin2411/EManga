using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.System.Locals
{
    public class DistrictVM
    {
        public int Id { get; set; }
        public string type { get; set; }

        [Display(Name = "Tên")]
        public string Name { get; set; }
        public List<string> Wards { get; set; } = new List<string>();
    }
}
