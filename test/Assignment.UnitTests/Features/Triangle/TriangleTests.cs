namespace Triangles.Tests;

using Assignment.Features.Triangle;

public class TriangleTests
{
    [Fact]
    public void CalculateAreaOfTriangleTest()
    {
        var triangle = new Triangle
        {
            Sides = new int[] { 3, 4, 5 }
        };
        var area = triangle.CalculateArea();
        Assert.Equal(6, area);
    }

    [Fact]
    public void SortTrianglesByAreaTest() 
    {
        var triangles = new List<Triangle>
        {
            new Triangle
            {
                Sides = new int[] { 3, 4, 5 }
            },
            new Triangle
            {
                Sides = new int[] { 1, 1, 1 }
            },
            new Triangle
            {
                Sides = new int[] { 2, 2, 3 }
            }
        };

        triangles.Sort();

        Assert.Equal(1, triangles[0].Sides[0]);
        Assert.Equal(1, triangles[0].Sides[1]);
        Assert.Equal(1, triangles[0].Sides[2]);

        Assert.Equal(2, triangles[1].Sides[0]);
        Assert.Equal(2, triangles[1].Sides[1]);
        Assert.Equal(3, triangles[1].Sides[2]);

        Assert.Equal(3, triangles[2].Sides[0]);
        Assert.Equal(4, triangles[2].Sides[1]);
        Assert.Equal(5, triangles[2].Sides[2]);
    }
}