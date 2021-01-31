using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication1.Models
{
    public partial class Gym
    {
        public Gym()
        {
            GymSchedule = new HashSet<GymSchedule>();
            PersonalTrainers = new HashSet<PersonalTrainers>();
            RelGymMachines = new HashSet<RelGymMachines>();
            RelGymModalities = new HashSet<RelGymModalities>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Adress { get; set; }
        [StringLength(50)]
        public string Latitude { get; set; }
        [StringLength(50)]
        public string Longitude { get; set; }
        [StringLength(50)]
        public string Contact { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Facebook { get; set; }

        [InverseProperty("Gym")]
        public virtual ICollection<GymSchedule> GymSchedule { get; set; }
        [InverseProperty("Gym")]
        public virtual ICollection<PersonalTrainers> PersonalTrainers { get; set; }
        [InverseProperty("Gym")]
        public virtual ICollection<RelGymMachines> RelGymMachines { get; set; }
        [InverseProperty("Gym")]
        public virtual ICollection<RelGymModalities> RelGymModalities { get; set; }
    }
}
