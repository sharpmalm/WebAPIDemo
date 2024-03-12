using WebAPIDemo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container, e.g. nameService
//Lifetimes:
//Scoped creates a new instance for each http request (recc. for ASP.NET most often)
//Transient creates a new instance every time the service is requested
//Singelton creates on y one instance while app is running.
builder.Services.AddScoped<NameService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
