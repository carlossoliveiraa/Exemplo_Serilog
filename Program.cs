using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information() // Certifique-se de que o nível seja adequado
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

// Exemplo de uso:
Log.Information("Esta é uma mensagem de informação.");
Log.Error("Esta é uma mensagem de erro.");

// Certifique-se de fechar e descarregar o logger ao encerrar o aplicativo
Log.CloseAndFlush();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
