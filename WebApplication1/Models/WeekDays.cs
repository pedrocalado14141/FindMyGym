using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication1.Models
{
    public partial class WeekDays
    {
        public WeekDays()
        {
            GymSchedule = new HashSet<GymSchedule>();
        }

        [Key]
        public short Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty("WeekDay")]
        public virtual ICollection<GymSchedule> GymSchedule { get; set; }
    }
}
