using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication1.Models
{
    public partial class Clientes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Column("PTId")]
        public int? Ptid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BirthDate { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        public short? Weigh { get; set; }
        public short? Height { get; set; }

        [ForeignKey(nameof(Ptid))]
        [InverseProperty(nameof(PersonalTrainers.Clientes))]
        public virtual PersonalTrainers Pt { get; set; }
    }
}
