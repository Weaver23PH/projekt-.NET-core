using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication3.Models;

namespace WebApplication3.Models
{
    public class AparatViewModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [Display(Name = " nazwa producenta")]
        [StringLength(50,
            ErrorMessage = " musi posiadać przynajmniej 3 znaki", MinimumLength = 3)]
        public string Producent { get; set; }
        [MaxLength(50)]
        [Display(Name = " kraj pochodzenia")]
        [StringLength(50,
           ErrorMessage = " musi posiadać przynajmniej 3 znaki", MinimumLength = 3)]
        public string KrajPochodzenia { get; set; }
        [MaxLength (100)]
        [Display(Name = " model")]
        public string Model { get; set; }
        [Display(Name = " rozpoczęcie produkcji")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:0/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RokProdukcji { get; set; }
        [Display(Name = " waga w gramach")]
        [Required(ErrorMessage = "Waga jest wymagana")]
        public int Waga { get; set; }
        [Display(Name = "wycofany z produkcji?")]
        public bool Wycofany { get; set; }
        [Display(Name = "Bagnet")]
        public int BagnetId { get; set; }
        [ForeignKey("BagnetId")]
        public virtual Bagnet Bagnet { get; set; }
        public int AparatKategoriaId { get; set; }
        [ForeignKey("AparatKategoriaId")]
        public virtual AparatKategoria Kategoria { get; set; }
    }
}
