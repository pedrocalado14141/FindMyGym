using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication1.Models
{
    public partial class RelGymMachines
    {
        [Key]
        public int GymId { get; set; }
        [Key]
        public int MachinesId { get; set; }
        public short Quantity { get; set; }

        [ForeignKey(nameof(GymId))]
        [InverseProperty("RelGymMachines")]
        public virtual Gym Gym { get; set; }
        [ForeignKey(nameof(MachinesId))]
        [InverseProperty(nameof(MuscleMachines.RelGymMachines))]
        public virtual MuscleMachines Machines { get; set; }
    }
}
