using System;
using System.Collections.Generic;

namespace light_map
{
    public class Line
    {

        private Coord point1;
        private Coord point2;
        private List<Tile> line = new List<Tile>();


        private Coord start;
        private Coord end;
        private double longestlength;
        private bool steppingOnX;
        private double ySign;
        private double xSign;
        private double xDelta;
        private double yDelta;

        public Line(Coord firstPoint, Coord secondPoint)
        {
            point1 = firstPoint;
            point2 = secondPoint;

            CalculatCoordsDeltas();
        }

        public List<Tile> GetTiles()
        {
            return line;
        }

        private void CalculatCoordsDeltas()
        {
            if (point2.x > point1.x)
            {
                start = point1;
                end = point2;
                xDelta = point2.x - point1.x;
            }
            else
            {
                start = point2;
                end = point1;
                xDelta = point1.x - point2.x;
            }
            ySign = end.y < start.y ? -1 : 1;
            xSign = end.x < start.x ? -1 : 1;

            yDelta = point2.y > point1.y ? point2.y - point1.y : point1.y - point2.y;

            if (yDelta >= xDelta)
            {
                longestlength = yDelta;
                steppingOnX = false;
            }
            else
            {
                longestlength = xDelta;
                steppingOnX = true;
            }
            // Console.WriteLine("Longest Side: " + longestlength);
            // Console.WriteLine("steppingOnX : " + steppingOnX);
            // Console.WriteLine("xDelta : " + xDelta);
            // Console.WriteLine("yDelta : " + yDelta);

            CreatLine();
        }

        private void CreatLine()
        {
            for (int i = 0; i <= longestlength; i++)
            {
                double x, y;

                if (steppingOnX)
                {
                    x = start.x + i * xSign;

                    double calc = start.y + i * (yDelta / longestlength) * ySign;
                    y = (int)Math.Round(calc);
                }
                else
                {
                    double calc = start.x + i * (xDelta / longestlength) * xSign;
                    x = (int)Math.Round(calc);

                    y = start.y + i * ySign;
                }

                Tile tile = new Tile(x, y);
                line.Add(tile);
            }
        }
    }
}

// x = start.x + i * xSign * CalculatX(start.x + i * xSign);

// private double CalculatY(double currentPosition)
// {
//     return (double)((end.y - currentPosition) / longestlength);
// }

// private int CalculatX(double currentPosition)
// {
//     return (int)Math.Round(((double)end.x - currentPosition) / longestlength);
// }