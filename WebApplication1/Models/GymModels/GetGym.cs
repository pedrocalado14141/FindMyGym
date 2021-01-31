using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.GymModels
{
    public class SPGetGymModel
    {
        [Key]
        public int GymId { get; set; }
        [Required]
        [StringLength(50)]
        public string GymName { get; set; }
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
    }
    public class SPContext : DbContext
    {
        public SPContext()
        {
        }
        public SPContext(DbContextOptions<SPContext> options)
            : base(options)
        {
        }
        public DbSet<SPGetGymModel> SPGetGym { get; set; }
    }
}
