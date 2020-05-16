using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboratoire4Prog.Models
{
    public class Tetes
    {
        public int Id { get; set; }

        [Display(Name = "Pettie description")]
        public string Descript { get; set; }

        [Required]
        [Display(Name = "Heure de la Tété")]
        [DataType(DataType.DateTime)]
        public DateTime HeureTete { get; set; }
        
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), Required, StringLength(30)]
        [Display(Name = "Type de Tété")]
        public string Type { get; set; }

        [Display(Name = "Commentaire sur Tété")]
        public string Comment { get; set; }

    }
}
