# Triangles API

## Overview

The Triangles API is a RESTful service that provides endpoints for calculating properties of triangles and manipulating collections of triangles.

## Endpoints

### `POST /GetTriangleType`

Accepts a JSON object with the sides of a triangle and returns the type of the triangle (equilateral, isosceles, or scalene).

Request body:

```json
{
    "Polygon": {
        "Sides": [3, 4, 5]
    }
}
```

### `POST /GetTriangleArea`

Accepts a JSON object with the sides of a triangle and returns the area of the triangle.

Request body:

```json
{
    "Polygon": {
        "Sides": [3, 4, 5]
    }
}
```

### `POST /GetSortedTriangles`

Accepts a JSON object with a list of triangles and returns the list sorted by the triangles' areas.

Request body:

```json
{
    "Polygons": [
        {
            "Sides": [1, 1, 1]
        },
        {
            "Sides": [2, 2, 3]
        },
        {
            "Sides": [3, 4, 5]
        }
    ]
}
```

## Running Tests

This project includes unit and integration tests. To run them, use the following command:

```bash
dotnet test
```