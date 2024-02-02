namespace Assignment.Features.Triangle;

public class TriangleAreaResponse
{
    private readonly double area;
    public double Area => Math.Round(area, 2);

    public TriangleAreaResponse(double area)
    {
        this.area = area;
    }
}
