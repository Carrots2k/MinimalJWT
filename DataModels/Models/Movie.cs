using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double rating { get; set; }
    }
}
