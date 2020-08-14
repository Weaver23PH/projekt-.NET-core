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
        [MaxLength(40)]
        public string Typ { get; set; }
        public virtual ICollection<AparatViewModel> Aparaty { get; set; }
        public virtual ICollection<ObiektywViewModel> Obiektywy { get; set; }
    }
}
