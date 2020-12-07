using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maps.ViewModel
{
    public class MinimumViewModel
    {
        public int Id { get; set; }
        public double CoordX { get; set; }
        public double CoordY { get; set; }
        public double Value { get; set; }//minimum расстояние
        public string SubAddress { get; set; }
        public double[,] ConsCoord { get; set; }
    }
}
