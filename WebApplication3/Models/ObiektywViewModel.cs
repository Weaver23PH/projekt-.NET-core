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
        [RegularExpression(@"([A-Za-z]+(-?|'?\s?)){3,50}",
         ErrorMessage = "Characters are not allowed.")]
        [Display(Name = " Producer")]
        [StringLength(50,
            ErrorMessage = "Must have at least 3 letters/signs", MinimumLength = 3)]
        public string Producent { get; set; }
        [MaxLength(50)]
        [Display(Name = "Country")]
        [RegularExpression(@"([A-Za-z]+(-?|'?\s?)){3,50}",
         ErrorMessage = "Characters are not allowed.")]
        [StringLength(50,
           ErrorMessage = "Must have at least 3 letters/signs", MinimumLength = 3)]
        public string KrajPochodzenia { get; set; }
        [MaxLength(50)]
        [RegularExpression(@"([A-Za-z]+-?|\s?\d*){1,50}",
         ErrorMessage = "Characters are not allowed.")]
        [Display(Name = " Model")]
        public string Model { get; set; }
        [Display(Name = "Produced since")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:0/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RokProdukcji { get; set; }
        [Display(Name = " Weight in grams")]
        [MaxLength(10)]
        [RegularExpression(@"\d{1,4}(\.\d{0,2})?",
         ErrorMessage = "Characters are not allowed.")]
        [Required(ErrorMessage = "Weight is required!")]
        public int Waga { get; set; }
        [Display(Name = "Prime lens?")]
        public bool Staloogniskowy { get; set; }
        [RegularExpression(@"\d{1,4}(\.\d{0,2})?",
      ErrorMessage = "Characters are not allowed.")]
        [Display(Name = " Focal lenght minimum")]
        [Required(ErrorMessage = "Focal lenght minimum is required!")]
        public int OgniskowaMin { get; set; }
        [Display(Name = " Focal lenght maximum")]
        [RegularExpression(@"\d{1,4}(\.\d{0,2})?",
         ErrorMessage = "Characters are not allowed.")]
        [Required(ErrorMessage = "Focal lenght maximum is required!")]
        public int OgniskowaMax { get; set; }
        [Display(Name = " Shutter speed maximum")]
        [RegularExpression(@"\d{1,5}",
         ErrorMessage = "Characters are not allowed.")]
        [Required(ErrorMessage = "Shutter speed maximum is required!")]
        public int PrzesłonaMax { get; set; }
        [Display(Name = " Shutter speed minimum")]
        [RegularExpression(@"\d{1,5}",
         ErrorMessage = "Characters are not allowed.")]
        [Required(ErrorMessage = "Shutter speed minimum is required!")]
        public int PrzesłonaMin { get; set; }
        [Display(Name = "Mount")]
        public int BagnetId { get; set; }
        [ForeignKey("BagnetId")]
        [Display(Name = "Mount")]
        public virtual Bagnet Bagnet { get; set; }
    }
}
