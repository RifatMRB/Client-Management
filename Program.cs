using System.ComponentModel.DataAnnotations;
using Client_Management.Controllers;
using Client_Management.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddControllers().
// ConfigureApiBehaviorOptions(option =>
// {
//     option.SuppressModelStateInvalidFilter = true;
// });

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(e => e.Value != null && e.Value.Errors.Count > 0)
            .SelectMany(e =>  e.Value!.Errors.Select(err => err.ErrorMessage))
            .ToList();

        return new BadRequestObjectResult(ApiResponse<object>.ErrorResponse(errors,401,"validation falied"));
    };
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.MapControllers();
app.Run(); 

