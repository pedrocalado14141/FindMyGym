using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.PersonalTrainersModels
{
    public class CreatePersonalTrainer
    {
        [Key]
        public int Id { get; set; }
        public int GymId { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        [StringLength(50)]
        public string Contact { get; set; }
    }
}
