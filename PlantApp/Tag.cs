using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantApp
{
    public class Tag
    {
        public int Id { get; set; }
        public List<Plant> Plants { get; set; } = new List<Plant>();
    }
}
