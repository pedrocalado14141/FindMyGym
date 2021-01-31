using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication1.Models
{
    public partial class GymPtRel
    {
        [Key]
        public int GymId { get; set; }
        [Key]
        public int PersonalTrainerId { get; set; }

        [ForeignKey(nameof(GymId))]
        [InverseProperty("GymPtRel")]
        public virtual Gym Gym { get; set; }
    }
}
