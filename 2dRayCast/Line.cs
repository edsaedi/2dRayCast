using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _2dRayCast
{
    public class Line
    {
        Random rand = new Random(26);
        public int x1 = 0;
        public int x2 = 0;
        public int y1 = 0;
        public int y2 = 0;

        public Line(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }
    }
}
