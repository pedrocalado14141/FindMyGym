using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication1.Models
{
    public partial class FitnessRoom
    {
        public FitnessRoom()
        {
            RelGymFitnessRoom = new HashSet<RelGymFitnessRoom>();
        }

        [Key]
        public int Id { get; set; }
        public int GymId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public short Quantity { get; set; }

        [InverseProperty("FitnessRoom")]
        public virtual ICollection<RelGymFitnessRoom> RelGymFitnessRoom { get; set; }
    }
}
