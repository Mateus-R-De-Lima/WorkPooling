using Hangfire;
using Quartz;
using WorkPooling.Hangfire;
using WorkPooling.Quartz;
using WorkPooling.Redis;
using WorkPooling.Services;
using ConsumeThirdPartyApiJob = WorkPooling.Hangfire.ConsumeThirdPartyApiJob;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// HttpClient (para o Job)
builder.Services.AddHttpClient();

// Configuração do Quartz via extensão
//builder.Services.AddConfigQuartz();

// Configuração do Hangfire via extensão
builder.Services.AddConfigHangfire(builder.Configuration);

builder.Services.AddScoped<IAdviceSlipServices, AdviceSlipServices>();

builder.Services.AddScoped<IRedisShared, RedisShared>();

//Redis
builder.Services.AddScoped<IRedisService, RedisService>();

builder.Services.AddScoped<IConsumeThirdPartyApiJob, ConsumeThirdPartyApiJob>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// Agendamento dos jobs via extensão
app.ConfigureJobs();
// Dashboard Hangfire
app.UseHangfireDashboard("/hangfire");

app.Run();
