using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXHistory.Models
{
    public class Company
    {
        public string Name { get; set; }
        public string Founder { get; set; }
        public string Summary { get; set; }
        public string YearFounded { get; set; }
        public string Employees {get ; set; }
        public string Valuation { get; set; }
        public string HqAddress { get; set; }
        public string HqCity { get; set; }
        public string HqState { get; set; }
    }
}
