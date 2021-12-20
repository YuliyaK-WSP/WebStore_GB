using WebStore.Infrastructure.Conventions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddControllersWithViews(opt =>
{
    opt.Conventions.Add(new TestConvention());
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();
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
