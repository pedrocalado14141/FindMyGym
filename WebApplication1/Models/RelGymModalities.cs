using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication1.Models
{
    public partial class RelGymModalities
    {
        [Key]
        public int GymId { get; set; }
        [Key]
        public int ModalitiesId { get; set; }

        [ForeignKey(nameof(GymId))]
        [InverseProperty("RelGymModalities")]
        public virtual Gym Gym { get; set; }
        [ForeignKey(nameof(ModalitiesId))]
        [InverseProperty("RelGymModalities")]
        public virtual Modalities Modalities { get; set; }
    }
}
