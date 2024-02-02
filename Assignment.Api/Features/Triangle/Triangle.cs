using Assignment.Domain;

namespace Assignment.Features.Triangle;

public class Triangle : Polygon
{
    public override double CalculateArea()
    {
        var s = Perimeter / (double)2;
        var area = Math.Sqrt(s * (s - Sides[0]) * (s - Sides[1]) * (s - Sides[2]));

        return area;
    }
}
