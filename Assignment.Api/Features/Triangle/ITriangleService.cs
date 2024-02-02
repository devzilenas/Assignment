using Assignment.Features.Triangle;

public interface ITriangleService
{
    TriangleType GetType(Triangle triangle);
    double GetArea(Triangle triangle);
    bool ValidateTriangle(Triangle triangle);
}