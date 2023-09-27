using ContosoPizza.Data;
using ContosoPizza.Services;

// WebApplicationBuilder : API ������ ���
var builder = WebApplication.CreateBuilder(args);

// Swagger UI ���� (API ���� �ð�ȭ�ϰ� ��ȣ �ۿ�)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the PizzaContext
builder.Services.AddSqlite<PizzaContext>("Data Source=ContosoPizza.db");

// Add the PromotionsContext

builder.Services.AddScoped<PizzaService>();

var app = builder.Build();

// HTTP ��û ���������� ����
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

// �����ͺ��̽� �������� ������ CreateDbIfNotExists �޼���� �����ͺ��̽� ����
app.CreateDbIfNotExists();

app.MapGet("/", () => @"Contoso Pizza management API. Navigate to /swagger to open the Swagger test UI.");


app.Run();
