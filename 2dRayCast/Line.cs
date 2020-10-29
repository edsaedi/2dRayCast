using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace _2dRayCast
{
    public class Line
    {
        Random rand = new Random(26);

        public Point startPoint;
        public Point endPoint;

        public Line(int x1, int y1, int x2, int y2)
        {
            startPoint.X = x1;
            endPoint.X = x2;
            startPoint.X = y1;
            endPoint.X = y2;
        }

        public Line(Point StartPoint, Point EndPoint)
        {
            this.startPoint = StartPoint;
            this.endPoint = EndPoint;
        }

        public bool Intersection(Line other, out Point intersectionPoint)
        {
            double tNumerator = ((startPoint.X - other.startPoint.X) * (other.startPoint.Y - other.endPoint.Y)) - ((startPoint.Y - other.startPoint.Y) * (other.startPoint.X - other.endPoint.X));
            double uNumerator = -1 * (((startPoint.X - endPoint.X) * (startPoint.Y - other.startPoint.Y)) - ((startPoint.Y - endPoint.Y) * (startPoint.X - other.startPoint.X)));
            double Denomenator = (((startPoint.X - endPoint.Y) * (other.startPoint.Y - other.endPoint.Y)) - ((startPoint.Y - endPoint.Y) * (other.startPoint.X - other.endPoint.X)));

            if (Denomenator == 0)
            {
                intersectionPoint = default;
                return false;
            }

            double t = tNumerator / Denomenator;
            double u = uNumerator / Denomenator;

            if (t <= 1 && t >= 0 && u <= 1 && u >= 0)
            {
                var tempX = (int)(startPoint.X + (t * (endPoint.X - startPoint.X)));
                var tempY = (int)(startPoint.Y + (t * (endPoint.Y - startPoint.Y)));

                intersectionPoint = new Point(tempX, tempY);
                return true;
            }

            intersectionPoint = default;
            return false;
        }
    }
}
