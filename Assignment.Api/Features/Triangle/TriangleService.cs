using Assignment.Features.Triangle;

public class TriangleService : ITriangleService
{
    public TriangleType GetType(Triangle triangle)
    {
        if (triangle.Sides.Distinct().Count() == 1)
        {
            return TriangleType.Equilateral;
        }

        if (triangle.Sides.Distinct().Count() != triangle.Sides.Length)
        {
            return TriangleType.Isosceles;
        }

        return TriangleType.Scalene;
    }

    public bool ValidateTriangle(Triangle triangle)
    {
        if (triangle.Sides.Length != 3)
        {
            return false;
        }

        var a = triangle.Sides[0];
        var b = triangle.Sides[1];
        var c = triangle.Sides[2];
        return a + b > c && a + c > b && b + c > a;
    }

    public double GetArea(Triangle triangle) => triangle.CalculateArea();
}
