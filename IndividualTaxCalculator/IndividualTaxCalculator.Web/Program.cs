using IndividualTaxCalculator.Application.Extensions;
using IndividualTaxCalculator.Infrastructure.Extensions;
using IndividualTaxCalculator.Integration.Sql.Extensions;
using IndividualTaxCalculator.Integration.Sql.Migrations.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddCommonInfrastructure();
builder.Services.AddApplicationDependencies();
builder.Services.AddSqlDependencies();

var app = builder.Build();

RunMigrations(app);

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

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.Run();
return;

void RunMigrations(IHost webApplication)
{
    using var scope = webApplication.Services.CreateScope();
    var services = scope.ServiceProvider;

    var migratorService = services.GetService<IMigrationService>();
    migratorService!.MigrateUp();
}