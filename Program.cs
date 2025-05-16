using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // === Ввод Point ===
        Console.WriteLine("Введите координаты точки Point (X Y):");
        var pointInput = Console.ReadLine()?.Split();
        double px = double.Parse(pointInput[0]);
        double py = double.Parse(pointInput[1]);
        Point p1 = new Point(px, py);

        // === Ввод ColoredPoint ===
        Console.WriteLine("Введите координаты и цвет для ColoredPoint (X Y Color):");
        var cpInput = Console.ReadLine()?.Split();
        double cpx = double.Parse(cpInput[0]);
        double cpy = double.Parse(cpInput[1]);
        string cpColor = cpInput[2];
        ColoredPoint cp1 = new ColoredPoint(cpx, cpy, cpColor);

        Console.WriteLine($"\nPoint p1: ({p1.X}, {p1.Y})");
        Console.WriteLine($"ColoredPoint cp1: ({cp1.X}, {cp1.Y}), Color: {cp1.Color}");

        // === Ввод Line ===
        Console.WriteLine("\nВведите координаты начала и конца линии (StartX StartY EndX EndY):");
        var lineInput = Console.ReadLine()?.Split();
        Point start = new Point(double.Parse(lineInput[0]), double.Parse(lineInput[1]));
        Point end = new Point(double.Parse(lineInput[2]), double.Parse(lineInput[3]));
        Line line = new Line(start, end);

        Console.WriteLine($"Line start: ({line.Start.X}, {line.Start.Y}), end: ({line.End.X}, {line.End.Y})");
        Console.Write("Введите угол поворота линии: ");
        double angle = double.Parse(Console.ReadLine());
        line.Rotate(angle);
        Console.WriteLine($"After {angle}° rotation: end: ({line.End.X:F2}, {line.End.Y:F2})");

        // === Ввод ColoredLine ===
        Console.WriteLine("\nВведите координаты начала и конца ColoredLine и цвет (StartX StartY EndX EndY Color):");
        var clInput = Console.ReadLine()?.Split();
        Point clStart = new Point(double.Parse(clInput[0]), double.Parse(clInput[1]));
        Point clEnd = new Point(double.Parse(clInput[2]), double.Parse(clInput[3]));
        string clColor = clInput[4];
        ColoredLine coloredLine = new ColoredLine(clStart, clEnd, clColor);

        Console.WriteLine($"ColoredLine color: {coloredLine.Color}");
        Console.Write("Введите угол поворота ColoredLine: ");
        double clAngle = double.Parse(Console.ReadLine());
        coloredLine.Rotate(clAngle);
        Console.WriteLine($"After {clAngle}° rotation: end point: ({coloredLine.End.X:F2}, {coloredLine.End.Y:F2})");

        // === Ввод PolyLine ===
        Console.Write("\nВведите количество точек PolyLine: ");
        int pointCount = int.Parse(Console.ReadLine());
        List<Point> polyPoints = new List<Point>();
        for (int i = 0; i < pointCount; i++)
        {
            Console.Write($"Введите координаты точки {i + 1} (X Y): ");
            var pt = Console.ReadLine()?.Split();
            polyPoints.Add(new Point(double.Parse(pt[0]), double.Parse(pt[1])));
        }
        PolyLine poly = new PolyLine(polyPoints);

        Console.WriteLine("PolyLine points before rotation and scaling:");
        foreach (var pt in poly.Points)
            Console.WriteLine($"({pt.X}, {pt.Y})");

        Console.Write("Введите угол поворота PolyLine: ");
        double polyAngle = double.Parse(Console.ReadLine());
        poly.Rotate(polyAngle);

        Console.WriteLine("После поворота:");
        foreach (var pt in poly.Points)
            Console.WriteLine($"({pt.X:F2}, {pt.Y:F2})");

        Console.Write("Введите коэффициент масштабирования: ");
        double scale = double.Parse(Console.ReadLine());
        poly.Scale(scale);

        Console.WriteLine("После масштабирования:");
        foreach (var pt in poly.Points)
            Console.WriteLine($"({pt.X:F2}, {pt.Y:F2})");
    }
}