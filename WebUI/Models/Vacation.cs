using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class Vacation
    {
        [Key]
        public int VacationId { get; set; }

        [Required]
        [Display(Name = "Начало отпуска")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]

        public DateTime From { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Date only")]

        [Display(Name = "Конец отпуска")]
        public DateTime To { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
