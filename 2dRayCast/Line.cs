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
            startPoint.Y = y1;
            endPoint.Y = y2;
        }

        public Line(Point StartPoint, Point EndPoint)
        {
            this.startPoint = StartPoint;
            this.endPoint = EndPoint;
        }

        // Found at https://en.wikipedia.org/wiki/Line%E2%80%93line_intersection
        public bool LineIntersection(Line ray, Line barrier, out Point intersectionPoint)
        {
            intersectionPoint = default;
            int den = ((ray.startPoint.X - ray.endPoint.X) * (barrier.startPoint.Y - barrier.endPoint.Y)) - ((ray.startPoint.Y - ray.endPoint.Y) * (barrier.startPoint.X - barrier.endPoint.X));
            float t = ((ray.startPoint.X - barrier.startPoint.X) * (barrier.startPoint.Y - barrier.endPoint.Y)) - ((ray.startPoint.Y - barrier.startPoint.Y) * (barrier.startPoint.X - barrier.endPoint.X));
            float u = ((ray.startPoint.X - ray.endPoint.X) * (ray.startPoint.Y - barrier.startPoint.Y)) - ((ray.startPoint.Y - ray.endPoint.Y) * (ray.startPoint.X - barrier.startPoint.X));

            if (den == 0)
            {
                return false;
            }

            t /= den;
            u /= -den;

            if (t >= 0 && t <= 1 && u >= 0 && u <= 1)
            {
                intersectionPoint.X = (int)(ray.startPoint.X + (t * (ray.endPoint.X - ray.startPoint.X)));
                intersectionPoint.Y = (int)(ray.startPoint.Y + (t * (ray.endPoint.Y - ray.startPoint.Y)));
                return true;
            }
            return false;
        }


        public bool Intersection(Line ray, Line barrier, out Point intersectionPoint)
        {
            intersectionPoint = default;
            //int den = ((ray.startPoint.X - ray.endPoint.X) * (barrier.startPoint.Y - barrier.endPoint.Y)) - ((ray.startPoint.Y - ray.endPoint.Y) * (barrier.startPoint.X - barrier.endPoint.X));
            int den = ((ray.startPoint.X - ray.endPoint.X) * (barrier.startPoint.Y - barrier.endPoint.Y)) - ((ray.startPoint.Y - ray.endPoint.Y) * (barrier.startPoint.X - barrier.endPoint.X));

            //float t = ((ray.startPoint.X - barrier.startPoint.X) * (barrier.startPoint.Y - barrier.endPoint.Y)) - ((ray.startPoint.Y - barrier.startPoint.Y) * (barrier.startPoint.X - barrier.endPoint.X));
            double tNumerator = ((ray.startPoint.X - barrier.startPoint.X) * (barrier.startPoint.Y - barrier.endPoint.Y)) - ((ray.startPoint.Y - barrier.startPoint.Y) * (barrier.startPoint.X - barrier.endPoint.X));

            //float u = ((ray.startPoint.X - ray.endPoint.X) * (ray.startPoint.Y - barrier.startPoint.Y)) - ((ray.startPoint.Y - ray.endPoint.Y) * (ray.startPoint.X - barrier.startPoint.X));
            double uNumerator = ((ray.startPoint.X - ray.endPoint.X) * (ray.startPoint.Y - barrier.startPoint.Y)) - ((ray.startPoint.Y - ray.endPoint.Y) * (ray.startPoint.X - barrier.startPoint.X));

            //if (Denomenator == 0)
            if(den == 0)
            {
                return false;
            }

            //double t = tNumerator / Denomenator;
            tNumerator /= den;
            uNumerator /= -den;
            //double u = uNumerator / -Denomenator;

            //if (t <= 1 && t >= 0 && u <= 1 && u >= 0)
            if (tNumerator >= 0 && tNumerator <= 1 && uNumerator >= 0 && uNumerator <= 1)
            {
                intersectionPoint.X =  (int)(ray.startPoint.X + (tNumerator * (ray.endPoint.X - ray.startPoint.X)));
                intersectionPoint.Y = (int)(ray.startPoint.Y + (tNumerator * (ray.endPoint.Y - ray.startPoint.Y)));

                return true;
            }

            return false;
        }
    }
}
