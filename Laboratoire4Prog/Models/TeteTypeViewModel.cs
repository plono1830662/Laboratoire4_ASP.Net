using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Laboratoire4Prog.Models
{
    public class TeteTypeViewModel
    {
        public List<Tetes> Tetes { get; set; }
        public SelectList Types { get; set; }
        public string TypeTete { get; set; }
        public string SearchString { get; set; }
    }
}
