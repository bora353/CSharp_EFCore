using ContosoPizza.Data;
using ContosoPizza.Services;

// WebApplicationBuilder : API 구성시 사용
var builder = WebApplication.CreateBuilder(args);

// Swagger UI 구성 (API 문서 시각화하고 상호 작용)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the PizzaContext
builder.Services.AddSqlite<PizzaContext>("Data Source=ContosoPizza.db");

// Add the PromotionsContext

builder.Services.AddScoped<PizzaService>();

var app = builder.Build();

// HTTP 요청 파이프라인 구성
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

// 데이터베이스 존재하지 않으면 CreateDbIfNotExists 메서드로 데이터베이스 생성
app.CreateDbIfNotExists();

app.MapGet("/", () => @"Contoso Pizza management API. Navigate to /swagger to open the Swagger test UI.");


app.Run();
