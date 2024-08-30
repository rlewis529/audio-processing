var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy to allow requests from Swagger UI
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSwaggerUI",
        builder =>
        {
            builder.WithOrigins("https://localhost:7052")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); // Uncommenting these causes Swagger to break.  Find out why
// app.UseAuthorization(); // Uncommenting these causes Swagger to break.
app.UseCors();

app.MapControllers(); 

app.Run();
