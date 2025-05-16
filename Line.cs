using System;

public class Line
{
    public Point Start { get; set; }
    public Point End { get; set; }

    public Line()
    {
        Start = new Point();
        End = new Point();
    }

    public Line(Point start, Point end)
    {
        Start = start;
        End = end;
    }

    public void Rotate(double angleDegrees)
    {
        double angleRadians = angleDegrees * Math.PI / 180.0;

        double dx = End.X - Start.X;
        double dy = End.Y - Start.Y;

        double cosA = Math.Cos(angleRadians);
        double sinA = Math.Sin(angleRadians);

        double newX = dx * cosA - dy * sinA;
        double newY = dx * sinA + dy * cosA;

        End.X = Start.X + newX;
        End.Y = Start.Y + newY;
    }
}
