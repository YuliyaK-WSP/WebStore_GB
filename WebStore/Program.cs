using WebStore.Infrastructure.Conventions;
using WebStore.Infrastructure.Middleware;
using WebStore.Services;
using WebStore.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddControllersWithViews(opt =>
{
    opt.Conventions.Add(new TestConvention());
});

services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
//app.Map("/testpath", async context => await context.Response.WriteAsync("Test middleware"));
app.UseStaticFiles();

app.UseRouting();

app.UseMiddleware<TestMiddleware>();

app.UseWelcomePage("/welcom");
// Загрузка информации из файла конфигурации

//var configuration = app.Configuration;
//var greetings = configuration["CustomGreetings"];
//app.MapGet("/", () => app.Configuration["CustomGreetings"]);
app.MapGet("/thow", () =>
{
    throw new ApplicationException("Ошибка в программе!");
});
//app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}");
app.Run();
