using Assignment.Features.Polygons;
using Swashbuckle.AspNetCore.Filters;

public class TrianglesSortRequestExample : IExamplesProvider<PolygonsRequest>
{
    public PolygonsRequest GetExamples()
    {
        return new PolygonsRequest
        {
            Polygons = new List<PolygonDto>
            {
                new PolygonDto
                {
                    Sides = new int[] { 3, 4, 5 }
                },
                new PolygonDto
                {
                    Sides = new int[] { 1, 1, 1 }
                },
                new PolygonDto
                {
                    Sides = new int[] { 2, 2, 3 }
                }
            }
        };
    }
}