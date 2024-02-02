using System.Net;
using System.Net.Http.Json;
using Assignment.Features.Polygons;
using Assignment.Features.Triangle;

namespace Features.Triangle;

public class IntegrationTest1
{
    [Theory]
    [InlineData(new int[] { 1, 1, 1 }, "Equilateral")]
    [InlineData(new int[] { 2, 2, 3 }, "Isosceles")]
    [InlineData(new int[] { 3, 4, 5 }, "Scalene")]
    public async Task TestTriangleTypeAsync(int[] sides, string expected)
    {
        var client = NewClient();
        var response = await client.PostAsJsonAsync(GetUrl("GetTriangleType"), new PolygonTypeRequest
        {
            Polygon = new PolygonDto
            {
                Sides = sides
            }
        });

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var result = await response.Content.ReadFromJsonAsync<TriangleTypeResponse>();

        Assert.Equal(expected, result?.TriangleType);
    }

    [Fact]
    public async Task TestInvalidTriangleRequestAsync()
    {
        var client = NewClient();
        var response = await client.PostAsJsonAsync(GetUrl("GetTriangleType"), new PolygonTypeRequest
        {
            Polygon = new PolygonDto
            {
                Sides = new int[] { 1, 2, 3, 4 }
            }
        });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Theory]
    [InlineData(new int[] { 1, 1, 1 }, 0.43)]
    [InlineData(new int[] { 2, 2, 3 }, 1.98)]
    [InlineData(new int[] { 3, 4, 5 }, 6)]
    public async Task TestTriangleAreaCalculationAsync(int[] sides, double expected)
    {
        var client = NewClient();
        var response = await client.PostAsJsonAsync(GetUrl("GetTriangleArea"), new TriangleAreaRequest
        {
            Polygon = new PolygonDto
            {
                Sides = sides
            }
        });

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var result = await response.Content.ReadFromJsonAsync<TriangleAreaResponse>();

        Assert.Equal(expected, result?.Area);
    }

    [Fact]
    public async Task TestTriangleSortingAsync()
    {
        var client = NewClient();
        var response = await client.PostAsJsonAsync(GetUrl("GetSortedTriangles"), new PolygonsRequest
        {
            Polygons = new List<PolygonDto>
            {
                new PolygonDto
                {
                    Sides = new int[] { 1, 1, 1 }
                },
                new PolygonDto
                {
                    Sides = new int[] { 2, 2, 3 }
                },
                new PolygonDto
                {
                    Sides = new int[] { 3, 4, 5 }
                }
            }
        });

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var result = await response.Content.ReadFromJsonAsync<PolygonsResponse>();

        Assert.Equal(3, result?.Polygons.Length);
    }

    private static string GetUrl(string path) => $"/Triangles/{path}";

    private static HttpClient NewClient()
    {
        var application = new MyWebApplication();
        var client = application.CreateClient();
        return client;
    }
}