using SpeedTestApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetValue<string>("EventHub:ConnectionString");
var entityPath = builder.Configuration.GetValue<string>("EventHub:EntityPath");

builder.Services.AddScoped<ISpeedTestEvents, SpeedTestEvents>(cts =>
{
    return new SpeedTestEvents(connectionString, entityPath);
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
else
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
