using System;

using System.Collections.Generic;
using System.Linq;

public class PolyLine : Line
{
    public List<Point> Points { get; set; }

    public PolyLine()
    {
        Points = new List<Point>();
    }

    public PolyLine(IEnumerable<Point> points)
    {
        Points = points.ToList();
    }

    public void Rotate(double angleDegrees)
    {
        if (Points.Count == 0)
            return;

        double angleRadians = angleDegrees * Math.PI / 180.0;
        Point pivot = Points[0];

        double cosA = Math.Cos(angleRadians);
        double sinA = Math.Sin(angleRadians);

        for (int i = 1; i < Points.Count; i++)
        {
            double dx = Points[i].X - pivot.X;
            double dy = Points[i].Y - pivot.Y;

            double newX = dx * cosA - dy * sinA;
            double newY = dx * sinA + dy * cosA;

            Points[i].X = pivot.X + newX;
            Points[i].Y = pivot.Y + newY;
        }
    }

    public void Scale(double scaleFactor)
    {
        if (Points.Count == 0)
            return;

        Point pivot = Points[0];

        for (int i = 1; i < Points.Count; i++)
        {
            double dx = Points[i].X - pivot.X;
            double dy = Points[i].Y - pivot.Y;

            Points[i].X = pivot.X + dx * scaleFactor;
            Points[i].Y = pivot.Y + dy * scaleFactor;
        }
    }
}
