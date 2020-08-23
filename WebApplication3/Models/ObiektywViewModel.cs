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
        [Required(ErrorMessage = "Nazwa is required!")]
        [Display(Name = " nazwa producenta")]
        [StringLength(50,
            ErrorMessage = "Must have at least 3 letters/signs", MinimumLength = 3)]
        public string Producent { get; set; }
        [MaxLength(50)]
        [Display(Name = "Country")]
        [StringLength(50,
           ErrorMessage = "Must have at least 3 letters/signs", MinimumLength = 3)]
        public string KrajPochodzenia { get; set; }
        [MaxLength(100)]
        [Display(Name = " model")]
        public string Model { get; set; }
        [Display(Name = " rozpoczęcie produkcji")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:0/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RokProdukcji { get; set; }
        [Display(Name = " waga w gramach")]
        [Required(ErrorMessage = "Waga is required!")]
        public int Waga { get; set; }
        [Display(Name = "Stałoogniskowy?")]
        public bool Staloogniskowy { get; set; }
        [Display(Name = " ogniskowa minimalna")]
        [Required(ErrorMessage = "ogniskowa minimalna is required!")]
        public int OgniskowaMin { get; set; }
        [Display(Name = " ogniskowa maksymalna")]
        [Required(ErrorMessage = "ogniskowa maksymalna is required!")]
        public int OgniskowaMax { get; set; }
        [Display(Name = " Przesłona maksymalna")]
        [Required(ErrorMessage = "Przesłona maksymalna is required!")]
        public int PrzesłonaMax { get; set; }
        [Display(Name = " Przesłona minimalna")]
        [Required(ErrorMessage = "Przesłona minimalna is required!")]
        public int PrzesłonaMin { get; set; }
        [Display(Name = "Mount")]
        public int BagnetId { get; set; }
        [ForeignKey("BagnetId")]
        public virtual Bagnet Bagnet { get; set; }
    }
}
