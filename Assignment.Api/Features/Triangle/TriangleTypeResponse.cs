namespace Assignment.Features.Triangle;

public class TriangleTypeResponse
{
    public string TriangleType { get; set;} = "";
    public TriangleTypeResponse()
    {
    }

    public TriangleTypeResponse(TriangleType triangleType)
    {
        TriangleType = Enum.GetName(typeof(TriangleType), triangleType) ?? "";
    }
}