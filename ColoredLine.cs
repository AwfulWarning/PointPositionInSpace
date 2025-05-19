using System;

public class ColoredLine : Line
{
    private string _color;

    public string Color
    {
        get => _color;
        set => _color = value ?? "Black"; // BUG-05 FIX
    }

    public ColoredLine() : base()
    {
        Color = "Black";
    }

    public ColoredLine(Point start, Point end, string color) : base(start, end)
    {
        Color = color; // обработка через сеттер
    }
}
