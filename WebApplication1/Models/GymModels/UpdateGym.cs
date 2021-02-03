using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.GymModels
{
    public class UpdateGym
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
    }
}
