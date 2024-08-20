using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

//Add Ocelot services
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);


var app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//Add Ocelot middleware
await app.UseOcelot();

app.Run();
