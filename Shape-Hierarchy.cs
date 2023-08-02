using System;


public abstract class Shape
{
    public string Name;
    public Shape(string name){
        Name = name;
    }
    public abstract double CalculateArea();
    
}

public class Circle : Shape
{
    public double Radius { get; set; }
    public Circle(string name) : base(name)
    {
    }
    public override double CalculateArea(){
        double Area = Math.PI * Radius * Radius;
        return Area;
    }
}

public class Rectangle: Shape
{
    public double Height { get; set; }
    public double Width { get; set; }
    public Rectangle(string name): base(name){

    }
    public override double CalculateArea(){
        double Area = Height * Width;
        return Area;
    }
}

public class Triangle: Shape
{
    public double Height { get; set; }
    public double Base { get; set; }
    public Triangle(string name): base(name){

    }
    public override double CalculateArea(){
        double Area = (Base * Height) / 2;
        return Area;
    }
}

public class Program
{
    public static void PrintShapeArea(Shape shape){
        Console.WriteLine("Shape Name: {0}", shape.Name);
        Console.WriteLine("Area: {0}", shape.CalculateArea());
    }
    public static void Main(){

        Shape circle = new Circle("Circle"){Radius=10};
        PrintShapeArea(circle);

        Shape rectangle = new Rectangle("Rectangle"){Height=10,Width=5};
        PrintShapeArea(rectangle);
        
        Shape triangle = new Triangle("Triangle"){Height=10,Base=5};
        PrintShapeArea(triangle);
    }
}
