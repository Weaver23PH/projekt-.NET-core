using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Bagnet
    {

        [Key] public int Id { get; set; }
        [MaxLength(20)]
        [RegularExpression(@"^[[A-Z](\p{Letter})+-*|\s\d*|\d*]{1,20}$",
         ErrorMessage = "Characters are not allowed.")]
        [Display(Name = "Mount type")]
        public string Typ { get; set; }
        public virtual ICollection<AparatViewModel> Aparaty { get; set; }
        public virtual ICollection<ObiektywViewModel> Obiektywy { get; set; }
    }
}
