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
        [Required(ErrorMessage = "Name is required!")]
        [Display(Name = " Producer")]
        [StringLength(50,
            ErrorMessage = "Must have at least 3 letters/signs", MinimumLength = 3)]
        public string Producent { get; set; }
        [MaxLength(50)]
        [Display(Name = "Country")]
        [StringLength(50,
           ErrorMessage = "Must have at least 3 letters/signs", MinimumLength = 3)]
        public string KrajPochodzenia { get; set; }
        [MaxLength(100)]
        [Display(Name = " Model")]
        public string Model { get; set; }
        [Display(Name = "Produced since")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:0/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RokProdukcji { get; set; }
        [Display(Name = " Weight in grams")]
        [Required(ErrorMessage = "Weight is required!")]
        public int Waga { get; set; }
        [Display(Name = "Prime lens?")]
        public bool Staloogniskowy { get; set; }
        [Display(Name = " Focal lenght minimum")]
        [Required(ErrorMessage = "Focal lenght minimum is required!")]
        public int OgniskowaMin { get; set; }
        [Display(Name = " Focal lenght maximum")]
        [Required(ErrorMessage = "Focal lenght maximum is required!")]
        public int OgniskowaMax { get; set; }
        [Display(Name = " Shutter maximum")]
        [Required(ErrorMessage = "Shutter maximum is required!")]
        public int PrzesłonaMax { get; set; }
        [Display(Name = " Shutter minimum")]
        [Required(ErrorMessage = "Shutter minimum is required!")]
        public int PrzesłonaMin { get; set; }
        [Display(Name = "Mount")]
        public int BagnetId { get; set; }
        [ForeignKey("BagnetId")]
        public virtual Bagnet Bagnet { get; set; }
    }
}
