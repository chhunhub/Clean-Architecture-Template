using CleanArchitectureWeb;
using CleanArchitectureWeb.Components;
using CleanArchitectureWeb.Domain.Repositories;
using CleanArchitectureWeb.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
var configuration = builder.Configuration;
builder.Services.AddMediatorR(typeof(Program).Assembly);
//Inject DbContext
string connectionString = configuration.GetConnectionString("DataBase")!;
builder.Services.AddDbContext<CleanArchitectureDbContext>(configure =>
{
    configure.UseSqlServer(connectionString);
});
builder.Services.AddScoped<IUnitOfWork>(db => db.GetRequiredService<CleanArchitectureDbContext>());
//Persistence

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

await app.RunAsync();
