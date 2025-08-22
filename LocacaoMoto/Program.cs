using LocacaoMoto.Models;
using LocacaoMoto.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));

builder.Services.AddDbContext<ModelsContext>(options =>
{
    var uri = builder.Configuration["MongoDBSettings:AtlasURI"];
    var dbName = builder.Configuration["MongoDBSettings:DatabaseName"];

    if (string.IsNullOrEmpty(uri))
        throw new InvalidOperationException("MongoDB Atlas URI is not configured.");

    options.UseMongoDB(uri, dbName ?? "LocacaoMotoDB");
});

builder.Services.AddScoped<IMotosService, MotoServices>();
builder.Services.AddScoped<IEntregadoresService, EntregadoresService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Locação de Motos API",
        Version = "V1",
        Description = "API para locação de motos de acordo com as regras de negócios propostas"
    });

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
        c.IncludeXmlComments(xmlPath);
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Locação de Motos API");
    c.RoutePrefix = "api-docs";
});

if (!RunningInDocker())
{
    app.UseHttpsRedirection();
}

app.MapControllers();

app.Run();

bool RunningInDocker() =>
    Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";
