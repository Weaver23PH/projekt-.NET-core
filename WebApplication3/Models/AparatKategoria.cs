using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication3.Models
{
    public class AparatKategoria
    {
        [Key] public int Id { get; set; }
        [MaxLength(40)] public string Name { get; set; }
        public int? UpperCategoryId { get; set; }
        [ForeignKey("UpperCategoryId")] public virtual AparatKategoria UpperCategory { get; set; }
        public virtual List<AparatKategoria> SubCategories { get; set; }
        public virtual ICollection<AparatViewModel> Aparaty { get; set; }
    }
}
