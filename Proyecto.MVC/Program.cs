var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// para configurar el sitio web mvc en presentaciòn EN-US pero transmision de datos ES-ES
var supportedCultures = new[] { "en-US" };
var supportedUICultures = new[] { "es-ES" };

var localizationOptions = new RequestLocalizationOptions()
 .SetDefaultCulture(supportedCultures[0])
 .AddSupportedCultures(supportedCultures)
 .AddSupportedUICultures(supportedUICultures);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
