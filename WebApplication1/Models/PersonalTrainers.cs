using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication1.Models
{
    public partial class PersonalTrainers
    {
        public PersonalTrainers()
        {
            Clientes = new HashSet<Clientes>();
        }

        [Key]
        public int Id { get; set; }
        public int GymId { get; set; }
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime BirthDate { get; set; }
        [StringLength(50)]
        public string Contact { get; set; }

        [ForeignKey(nameof(GymId))]
        [InverseProperty("PersonalTrainers")]
        public virtual Gym Gym { get; set; }
        [InverseProperty("Pt")]
        public virtual ICollection<Clientes> Clientes { get; set; }
    }
}
