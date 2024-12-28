var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddCors(corsOptions => {
    corsOptions.AddPolicy("policy",
   builder => {
       builder.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
   });
});

builder.Services.AddControllers();

builder.Services.AddOpenApi(); // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // https://localhost:7131/openapi/v1.json
    app.MapOpenApi(); 

    // https://localhost:7131/swagger/index.html
    app.UseSwagger(); 
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseCors("policy");

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
