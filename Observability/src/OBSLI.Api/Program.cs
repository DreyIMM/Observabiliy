using Microsoft.EntityFrameworkCore;
using OBSI.Infra;
using OBSI.Infra.Repository;
using OBSI.Infra.RepositoryImp;
using Serilog.Formatting.Compact;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProdutosContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(builder.Configuration)
                    .Enrich.FromLogContext()
                    .WriteTo.Console(new CompactJsonFormatter())
                    .WriteTo.Elasticsearch(new Serilog.Sinks.Elasticsearch.ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
                    {
                        AutoRegisterTemplate = true,
                    })
                    .CreateLogger();
builder.Host.UseSerilog(logger);

builder.Services.AddScoped<IFornecedor, FornecedorRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
