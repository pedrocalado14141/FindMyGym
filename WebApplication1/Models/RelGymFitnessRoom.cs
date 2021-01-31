using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication1.Models
{
    public partial class RelGymFitnessRoom
    {
        [Key]
        public int GymId { get; set; }
        [Key]
        public int PtId { get; set; }
        [Key]
        public int FitnessRoomId { get; set; }

        [ForeignKey(nameof(FitnessRoomId))]
        [InverseProperty("RelGymFitnessRoom")]
        public virtual FitnessRoom FitnessRoom { get; set; }
        [ForeignKey(nameof(GymId))]
        [InverseProperty("RelGymFitnessRoom")]
        public virtual Gym Gym { get; set; }
        [ForeignKey(nameof(PtId))]
        //[InverseProperty(nameof(PersonalTrainers.RelGymFitnessRoom))]
        public virtual PersonalTrainers Pt { get; set; }
    }
}
