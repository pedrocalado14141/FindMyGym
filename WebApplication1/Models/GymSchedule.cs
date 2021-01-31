using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication1.Models
{
    public partial class GymSchedule
    {
        [Key]
        public int Id { get; set; }
        public int GymId { get; set; }
        public short WeekDayid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OpenTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CloseTime { get; set; }

        [ForeignKey(nameof(GymId))]
        [InverseProperty("GymSchedule")]
        public virtual Gym Gym { get; set; }
        [ForeignKey(nameof(WeekDayid))]
        [InverseProperty(nameof(WeekDays.GymSchedule))]
        public virtual WeekDays WeekDay { get; set; }
    }
}
