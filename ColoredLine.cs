using System;

public class ColoredLine : Line
{
    public string Color { get; set; }

    public ColoredLine() : base()
    {
        Color = "Black";
    }

    public ColoredLine(Point start, Point end, string color) : base(start, end)
    {
        Color = color;
    }
}

