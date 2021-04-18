using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.System.Locals
{
    public class ProvinceVM
    {
        public int Id { get; set; }
        public string type { get; set; }
        [Display(Name = "Tên")]
        public string Name { get; set; }
        //public List<string> Districts { get; set; } = new List<string>();
    }
}
