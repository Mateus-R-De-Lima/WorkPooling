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

// Configura��o do Quartz via extens�o
//builder.Services.AddConfigQuartz();

// Configura��o do Hangfire via extens�o
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
// Agendamento dos jobs via extens�o
app.ConfigureJobs();
// Dashboard Hangfire
app.UseHangfireDashboard("/hangfire");

app.Run();
