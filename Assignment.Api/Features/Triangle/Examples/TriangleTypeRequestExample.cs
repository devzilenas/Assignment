using Assignment.Features.Polygons;
using Swashbuckle.AspNetCore.Filters;

public class TriangleTypeRequestExample : IExamplesProvider<PolygonTypeRequest>
{
    public PolygonTypeRequest GetExamples()
    {
        return new PolygonTypeRequest
        {
            Polygon = new PolygonDto
            {
                Sides = new int[] { 3, 4, 5 }
            }
        };
    }
}