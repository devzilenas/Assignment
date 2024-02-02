using Assignment.Features.Polygons;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace Assignment.Features.Triangle;

[ApiController]
[Route("[controller]")]
public class TrianglesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ITriangleService _triangleService;

    public TrianglesController(IMapper mapper, ITriangleService triangleService)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _triangleService = triangleService ?? throw new ArgumentNullException(nameof(triangleService));
    }

    [HttpPost("GetTriangleType", Name = "GetTriangleType")]
    [SwaggerRequestExample(typeof(PolygonTypeRequest), typeof(TriangleTypeRequestExample))]
    [SwaggerOperation(Summary = "Determines the type of a triangle", Description = "Accepts the sides of a triangle and returns whether it is equilateral, isosceles, or scalene.")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TriangleTypeResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetTriangleType([FromBody] TriangleTypeRequest request)
    {
        var triangle = _mapper.Map<Triangle>(request.Polygon);

        if (_triangleService.ValidateTriangle(triangle))
        {
            var response = new TriangleTypeResponse(_triangleService.GetType(triangle));

            return Ok(response);
        }

        return BadRequest();
    }

    [HttpPost("GetTriangleArea", Name = "GetTriangleArea")]
    [SwaggerRequestExample(typeof(TriangleAreaRequest), typeof(TriangleAreaRequestExample))]
    [SwaggerOperation(Summary = "Calculates the area of a triangle", Description = "Accepts the sides of a triangle and returns its area.")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TriangleAreaResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetTriangleArea([FromBody] TriangleAreaRequest request)
    {
        var triangle = _mapper.Map<Triangle>(request.Polygon);

        if (_triangleService.ValidateTriangle(triangle))
        {
            var response = new TriangleAreaResponse(_triangleService.GetArea(triangle));

            return Ok(response);
        }

        return BadRequest();
    }

    [HttpPost("GetSortedTriangles", Name = "GetSortedTriangles")]
    [SwaggerRequestExample(typeof(PolygonsRequest), typeof(TrianglesSortRequestExample))]
    [SwaggerOperation(Summary = "Sorts a list of triangles by area", Description = "Accepts a list of triangles and returns the list sorted by the triangles' areas.")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PolygonsResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetSortedTriangles([FromBody] PolygonsRequest request)
    {
        var triangles = _mapper.Map<List<Triangle>>(request.Polygons);

        if (!triangles.All(x => _triangleService.ValidateTriangle(x)))
        {
            return BadRequest();
        }

        triangles.Sort();

        var response = new PolygonsResponse
        {
            Polygons = _mapper.Map<PolygonDto[]>(triangles)
        };

        return Ok(response);
    }
}
