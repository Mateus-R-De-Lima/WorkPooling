using Quartz;
using WorkPooling.Quartz;
using WorkPooling.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// HttpClient (para o Job)
builder.Services.AddHttpClient();

builder.Services.AddConfigQuartz();


builder.Services.AddScoped<IAdviceSlipServices, AdviceSlipServices>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
