using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//  ���������� ������ � ���������.
//��������� Swagger, ��������� ������� SwaggerDocument
//��������������� �� ����� ���������, ������������ � �������.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


// ����������� ���������� Swagger
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
    // ���� � ������������ ��� Swagger JSON � ����������������� ����������.
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


var app = builder.Build();

// ��������� ��������� HTTP-��������.
if (app.Environment.IsDevelopment())
{
    // ��������� �������������� ����������� ����������� ��� ������������
    // ���������������� Swagger � �������� �������� ����� JSON.

    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
    // ��������� �������������� ������������ �����������
    // ��� ������������ swagger-ui (HTML, JS, CSS � �.�.)
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
