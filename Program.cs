using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//  Добавление службы в контейнер.
//генератор Swagger, создающий объекты SwaggerDocument
//непосредственно из наших маршрутов, контроллеров и моделей.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


// Регистрация генератора Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // using System.Reflection;
    // Путь к комментариям для Swagger JSON и пользовательского интерфейса.
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


var app = builder.Build();

// Настройка конвейера HTTP-запросов.
if (app.Environment.IsDevelopment())
{
    // Включение промежуточного программное обеспечение для обслуживания
    // сгенерированного Swagger в качестве конечной точки JSON.

    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
    // Включение промежуточного программного обеспечения
    // для обслуживания swagger-ui (HTML, JS, CSS и т.д.)
    app.UseSwaggerUI(options =>
    {
       
        options.InjectStylesheet("/swagger-ui/custom.css");
        
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
      
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
