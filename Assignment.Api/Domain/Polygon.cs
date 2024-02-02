namespace Assignment.Domain;

public abstract class Polygon : IComparable
{
    public int[] Sides { get; set; } = [];

    public int Perimeter { get { return CalculatePerimeter(); } }

    public abstract double CalculateArea();

    public virtual int CalculatePerimeter()
    {
        return Sides.Sum();
    }

    public int CompareTo(object? obj)
    {
        if (obj == null) return 1;

        Polygon? polygon = obj as Polygon;

        if (polygon == null)
        {
            throw new ArgumentException("Object is not a Polygon");
        }

        return CalculateArea().CompareTo(polygon.CalculateArea());
    }
}