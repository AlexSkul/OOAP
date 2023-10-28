using System;
using System.Collections.Generic;

public class Rectangle
{
    public int X { get; }
    public int Y { get; }
    public int Width { get; }
    public int Height { get; }

    public Rectangle(int x, int y, int width, int height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public Rectangle WithPosition(int newX, int newY)
    {
        return new Rectangle(newX, newY, Width, Height);
    }

    public override string ToString()
    {
        return $"Rectangle(X: {X}, Y: {Y}, Width: {Width}, Height: {Height})";
    }
}

public class RectangleChain
{
    private readonly List<Rectangle> rectangles = new List<Rectangle>();

    public void AddRectangle(Rectangle rectangle)
    {
        rectangles.Add(rectangle);
    }

    public void UpdateAndDraw()
    {
        foreach (var rectangle in rectangles)
        {
            Console.WriteLine(rectangle);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var chain = new RectangleChain();

        var rectangle1 = new Rectangle(10, 10, 20, 30);
        var rectangle2 = rectangle1.WithPosition(50, 50);
        var rectangle3 = rectangle2.WithPosition(100, 100);

        chain.AddRectangle(rectangle1);
        chain.AddRectangle(rectangle2);
        chain.AddRectangle(rectangle3);

        chain.UpdateAndDraw();
    }
}
