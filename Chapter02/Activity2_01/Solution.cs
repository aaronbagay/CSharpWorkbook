namespace Activity2_01;

public static class Solution
{
    public static void Main(){
        var circle1 = new Circle(3);
        var circle2 = new Circle(3);
        var circle3 = circle1 + circle2;

        Console.WriteLine($"Addind circles of radius {circle1.Radius} and {circle2.Radius}" +
        $" results in a new circle with a radius {circle3.Radius}");
    }
}