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
        [RegularExpression(@"([A-Z'?a-z](-?|\s?)){3,50}",
         ErrorMessage = "Characters are not allowed.")]
        [Required(ErrorMessage = "Name is required!")]
        [Display(Name = "Producer")]
        [StringLength(50,
            ErrorMessage = "Must have at least 3 letters/signs", MinimumLength = 3)]
        public string Producent { get; set; }
        [MaxLength(50)]
        [RegularExpression(@"([A-Z'?a-z](-?|\s?)){3,50}",
         ErrorMessage = "Characters are not allowed.")]
        [Display(Name = "Country")]
        [StringLength(50,
           ErrorMessage = "Must have at least 3 letters/signs", MinimumLength = 3)]
        public string KrajPochodzenia { get; set; }
        [MaxLength (50)]
        [RegularExpression(@"([A-Z'?a-z](-?|\s)?\d*){1,50}",
         ErrorMessage = "Characters are not allowed.")]
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Display(Name = "Produced since")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:0/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RokProdukcji { get; set; }
        [Display(Name = "Weight in grams")]
        [RegularExpression(@"\d{1,4}(\.\d{0,2})?",
         ErrorMessage = "Characters are not allowed.")]
        [Required(ErrorMessage = "Weight is required!")]
        public int Waga { get; set; }
        [Display(Name = "Withdrawn from production?")]
        public bool Wycofany { get; set; }
        [Display(Name = "Mount")]
        public int BagnetId { get; set; }
        [ForeignKey("BagnetId")]
        [Display(Name = "Mount")]
        public virtual Bagnet Bagnet { get; set; }
        [Display(Name = "Category")]
        public int AparatKategoriaId { get; set; }
        [ForeignKey("AparatKategoriaId")]
        [Display(Name = "Category")]
        public virtual AparatKategoria Kategoria { get; set; }
    }
}
