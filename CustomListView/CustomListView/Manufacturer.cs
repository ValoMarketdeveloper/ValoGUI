using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListView
{

    public class Manufacturer
    {
        public string Company { get; set; }
        public List<Model> Models { get; set; }
    }

    public class Model
    {
        public string Name { get; set; }
        public string Ram { get; set; }
        public double price { get; set; }
        public string CPU { get; set; }
    }
}
