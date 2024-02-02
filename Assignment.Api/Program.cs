using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<ITriangleService, TriangleService>();

builder.Services.AddControllers().AddJsonOptions(opt => 
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
}
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.ExampleFilters();
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "Triangles API", 
        Version = "v1",
        Description = "A simple example API for managing triangles",
        Contact = new OpenApiContact
        {
            Name = "Marius Žilėnas",
            Email = "mzilenas@gmail.com",
        },
    });
});

builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }