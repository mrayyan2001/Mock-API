using GlossaryManagementSystem.Data;
using GlossaryManagementSystem.Interfaces;
using GlossaryManagementSystem.Repositories;
using GlossaryManagementSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Allow any origin, method, and header (for public APIs)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add services to the container.
builder.Services.AddScoped<IGlossaryRepository, GlossaryRepository>();
builder.Services.AddScoped<IGlossaryService, GlossaryService>();

builder.Services.AddScoped<GlossaryDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
