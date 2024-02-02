using Assignment.Features.Polygons;
using Assignment.Features.Triangle;
using Swashbuckle.AspNetCore.Filters;

public class TriangleAreaRequestExample : IExamplesProvider<TriangleAreaRequest>
{
    public TriangleAreaRequest GetExamples()
    {
        return new TriangleAreaRequest
        {
            Polygon = new PolygonDto
            {
                Sides = new int[] { 3, 4, 5 }
            }
        };
    }
}