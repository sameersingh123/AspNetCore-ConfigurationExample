using ConfigurationExample;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//Supply an object of WeatherApiOptions(with 'weatherapi' section) as a service
builder.Services.Configure<WeatherApiOptions>(builder.Configuration.GetSection("weatherapi"));

var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/config", async context =>
    {
        await context.Response.WriteAsync(app.Configuration["MyKey"] +"\n");

        await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyKey"));
    });
});

app.MapControllers();

app.Run();
