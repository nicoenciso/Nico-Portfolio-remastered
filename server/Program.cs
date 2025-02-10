using Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Cargar configuración desde appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Registrar servicios
builder.Services.AddSingleton<EmailService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hola mundo");

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();