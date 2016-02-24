using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoxService.Models
{
    public class Box
    {
        public int Id { get; set; }
        [Display(AutoGenerateField = false)]
        public string Name { get; set; }
        public List<string> Contents { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0}:C")]
        public decimal Cost { get; set; }
        public ICollection<Box> Boxes { get; set; }


    }
}