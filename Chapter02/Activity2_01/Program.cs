// See https://aka.ms/new-console-template for more information

using static System.Math;

namespace Activity2_01;

public struct Circle
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Area => PI * Radius * Radius;

    public static Circle operator + (Circle circle1, Circle circle2)
    {
        var newArea = circle1.Area + circle2.Area;
        var newRadius = Sqrt((newArea/PI));

        return new Circle(newRadius);
    }

}