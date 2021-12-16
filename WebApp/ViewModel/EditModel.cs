using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsClassLibrary.Entitys;

namespace WebApp.ViewModel
{
    public class EditModel
    {
        public Order Order { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}
