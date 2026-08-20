using CashFlow.Api.Filters;
using CashFlow.Api.Middleware;
using CashFlow.Application;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddInfrastructure(builder.Configuration); // AddInfrastructure recebe Service implicitamente
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CultureMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await MigrateDataBase();

app.Run();

async Task MigrateDataBase()
{
    // escopo de DI
    await using var scope = app.Services.CreateAsyncScope();
    await DataBaseMigration.Migrate(scope.ServiceProvider);
}

//As migrations do Entity Framework Core não passam por nenhum endpoint HTTP. Por isso, não podemos depender do fluxo normal de uma requisição para obter o DbContext através da injeção de dependência.

//Para executar as migrations durante a inicialização da aplicação, criamos manualmente um escopo de serviços (IServiceScope). A partir desse escopo, conseguimos acessar o CashFlowDbContext registrado no container de injeção de dependência.