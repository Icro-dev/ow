using bouwmarkt;
using bouwmarkt_API.Data;
using bouwmarkt_API.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IVestigingRepository, VestigingRepository>();

// load .env file
var root = Directory.GetCurrentDirectory();
Debug.Print(root);
var dotenv = Path.Combine(root, ".env");
Debug.Print(dotenv);
DotEnv.Load(dotenv);

var config =
    new ConfigurationBuilder()
        .AddEnvironmentVariables()
        .Build();

var env = Environment.GetEnvironmentVariables();

/*var envTest = env["USERNAME"].ToString();
Debug.Print(envTest);*/

var connectionString = "Data Source=" + env["hostname"] + ";" +
                       "User ID=" + env["USERNAME"] + ";" +
                       "Password=" + env["password"] + ";" +
                       "Database=" + env["database"] + ";" +
                       "TrustServerCertificate=true";


Debug.Print(connectionString);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services
    .AddDbContext<BouwmarktContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Migration and seeding data
using (var scope = app.Services.CreateScope())
{
    //running migrations at startup
    var db = scope.ServiceProvider.GetRequiredService<BouwmarktContext>();
    db.Database.Migrate();
    //adding seeddata

    var services = scope.ServiceProvider;
    SeedData.Initialize(services);

}
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


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
