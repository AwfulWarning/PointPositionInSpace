using System;

public class ColoredPoint : Point
{
    private string _color;

    public string Color
    {
        get => _color;
        set => _color = value ?? "Black"; // BUG-05 FIX: предотвращаем null
    }

    public ColoredPoint() : base()
    {
        Color = "Black";
    }

    public ColoredPoint(double x, double y, string color) : base(x, y)
    {
        Color = color; // будет обработан через сеттер
    }
}
