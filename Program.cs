using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // === Ввод Point ===
        Console.WriteLine("Введите координаты точки Point (X Y):");
        var pointInput = Console.ReadLine()?.Split();

        // BUG-03 FIX: проверка на null и достаточное количество аргументов
        if (pointInput == null || pointInput.Length < 2)
        {
            Console.WriteLine("Ошибка: нужно ввести два значения (X Y).");
            return;
        }

        double px = double.Parse(pointInput[0]);
        double py = double.Parse(pointInput[1]);
        Point p1 = new Point(px, py);

        // === Ввод ColoredPoint ===
        Console.WriteLine("Введите координаты и цвет для ColoredPoint (X Y Color):");
        var cpInput = Console.ReadLine()?.Split();

        // BUG-03 FIX: проверка на null и количество элементов
        if (cpInput == null || cpInput.Length < 3)
        {
            Console.WriteLine("Ошибка: нужно ввести три значения (X Y Color).");
            return;
        }

        double cpx = double.Parse(cpInput[0]);
        double cpy = double.Parse(cpInput[1]);
        string cpColor = cpInput[2];
        ColoredPoint cp1 = new ColoredPoint(cpx, cpy, cpColor);

        Console.WriteLine($"\nPoint p1: ({p1.X}, {p1.Y})");
        Console.WriteLine($"ColoredPoint cp1: ({cp1.X}, {cp1.Y}), Color: {cp1.Color}");

        // === Ввод Line ===
        Console.WriteLine("\nВведите координаты начала и конца линии (StartX StartY EndX EndY):");
        var lineInput = Console.ReadLine()?.Split();

        // BUG-03 FIX: проверка на null и 4 значения
        if (lineInput == null || lineInput.Length < 4)
        {
            Console.WriteLine("Ошибка: нужно ввести четыре значения (StartX StartY EndX EndY).");
            return;
        }

        Point start = new Point(double.Parse(lineInput[0]), double.Parse(lineInput[1]));
        Point end = new Point(double.Parse(lineInput[2]), double.Parse(lineInput[3]));
        Line line = new Line(start, end);

        Console.WriteLine($"Line start: ({line.Start.X}, {line.Start.Y}), end: ({line.End.X}, {line.End.Y})");
        Console.Write("Введите угол поворота линии: ");

        // BUG-03 FIX: проверка корректности угла
        if (!double.TryParse(Console.ReadLine(), out double angle))
        {
            Console.WriteLine("Ошибка: введите корректный угол.");
            return;
        }

        line.Rotate(angle);
        Console.WriteLine($"After {angle}° rotation: end: ({line.End.X:F2}, {line.End.Y:F2})");

        // === Ввод ColoredLine ===
        Console.WriteLine("\nВведите координаты начала и конца ColoredLine и цвет (StartX StartY EndX EndY Color):");
        var clInput = Console.ReadLine()?.Split();

        // BUG-03 FIX: проверка на null и 5 значений
        if (clInput == null || clInput.Length < 5)
        {
            Console.WriteLine("Ошибка: нужно ввести пять значений (StartX StartY EndX EndY Color).");
            return;
        }

        Point clStart = new Point(double.Parse(clInput[0]), double.Parse(clInput[1]));
        Point clEnd = new Point(double.Parse(clInput[2]), double.Parse(clInput[3]));
        string clColor = clInput[4];
        ColoredLine coloredLine = new ColoredLine(clStart, clEnd, clColor);

        Console.WriteLine($"ColoredLine color: {coloredLine.Color}");
        Console.Write("Введите угол поворота ColoredLine: ");

        // BUG-03 FIX: проверка угла
        if (!double.TryParse(Console.ReadLine(), out double clAngle))
        {
            Console.WriteLine("Ошибка: введите корректный угол.");
            return;
        }

        coloredLine.Rotate(clAngle);
        Console.WriteLine($"After {clAngle}° rotation: end point: ({coloredLine.End.X:F2}, {coloredLine.End.Y:F2})");

        // === Ввод PolyLine ===
        Console.Write("\nВведите количество точек PolyLine: ");

        // BUG-03 FIX: проверка количества точек
        if (!int.TryParse(Console.ReadLine(), out int pointCount) || pointCount < 2)
        {
            Console.WriteLine("Ошибка: количество точек должно быть целым числом больше 1.");
            return;
        }

        List<Point> polyPoints = new List<Point>();
        for (int i = 0; i < pointCount; i++)
        {
            Console.Write($"Введите координаты точки {i + 1} (X Y): ");
            var pt = Console.ReadLine()?.Split();

            // BUG-03 FIX: проверка на null и 2 значения
            if (pt == null || pt.Length < 2)
            {
                Console.WriteLine("Ошибка: нужно ввести два значения (X Y).");
                return;
            }

            polyPoints.Add(new Point(double.Parse(pt[0]), double.Parse(pt[1])));
        }

        PolyLine poly = new PolyLine(polyPoints);

        Console.WriteLine("PolyLine points before rotation and scaling:");
        foreach (var pt in poly.Points)
            Console.WriteLine($"({pt.X}, {pt.Y})");

        Console.Write("Введите угол поворота PolyLine: ");

        // BUG-03 FIX: проверка угла поворота
        if (!double.TryParse(Console.ReadLine(), out double polyAngle))
        {
            Console.WriteLine("Ошибка: введите корректный угол.");
            return;
        }

        poly.Rotate(polyAngle);

        Console.WriteLine("После поворота:");
        foreach (var pt in poly.Points)
            Console.WriteLine($"({pt.X:F2}, {pt.Y:F2})");

        Console.Write("Введите коэффициент масштабирования: ");

        // BUG-03 FIX: проверка коэффициента масштабирования
        if (!double.TryParse(Console.ReadLine(), out double scale))
        {
            Console.WriteLine("Ошибка: введите корректный коэффициент.");
            return;
        }

        poly.Scale(scale);

        Console.WriteLine("После масштабирования:");
        foreach (var pt in poly.Points)
            Console.WriteLine($"({pt.X:F2}, {pt.Y:F2})");
    }
}
