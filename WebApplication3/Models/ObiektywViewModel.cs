using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication3.Models;

namespace WebApplication3.Models
{
    public class ObiektywViewModel
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
        [MaxLength(100)]
        [Display(Name = " model")]
        public string Model { get; set; }
        [Display(Name = " rozpoczęcie produkcji")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:0/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RokProdukcji { get; set; }
        [Display(Name = " waga w gramach")]
        [Required(ErrorMessage = "Waga jest wymagana")]
        public int Waga { get; set; }
        [Display(Name = "Stałoogniskowy?")]
        public bool Staloogniskowy { get; set; }
        [Display(Name = " ogniskowa minimalna")]
        [Required(ErrorMessage = "ogniskowa minimalna jest wymagana")]
        public int OgniskowaMin { get; set; }
        [Display(Name = " ogniskowa maksymalna")]
        [Required(ErrorMessage = "ogniskowa maksymalna jest wymagana")]
        public int OgniskowaMax { get; set; }
        [Display(Name = " Przesłona maksymalna")]
        [Required(ErrorMessage = "Przesłona maksymalna jest wymagana")]
        public int PrzesłonaMax { get; set; }
        [Display(Name = " Przesłona minimalna")]
        [Required(ErrorMessage = "Przesłona minimalna jest wymagana")]
        public int PrzesłonaMin { get; set; }
        [Display(Name = "Bagnet")]
        public int BagnetId { get; set; }
        [ForeignKey("BagnetId")]
        public virtual Bagnet Bagnet { get; set; }
    }
}
