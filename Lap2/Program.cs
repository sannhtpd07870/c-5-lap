using Lap2;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(op =>
op.UseSqlServer(builder.Configuration.GetConnectionString("DBconnet")));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
