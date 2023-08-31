using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToolMonitor.ApplicationServices.API.Domain;
using ToolMonitor.ApplicationServices.API.Mappings;
using ToolMonitor.ApplicationServices.API.Validators;
using ToolMonitor.DataAccess;
using ToolMonitor.DataAccess.CQRS;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddFluentValidation(typeof(AddCompanyRequestValidator).Assembly);
builder.Services.AddMvcCore().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddCompanyRequestValidator>());
builder.Services.AddAutoMapper(typeof(ToolsProfile).Assembly);
builder.Services.AddMediatR(typeof(ResponseBase<>));
builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();
builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();
builder.Services.AddControllers();
builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.AddDbContext<ToolStorageContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ToolStorageDatabaseConection")));
//builder.Services.AddDbContext<ToolStorageContext>(opt => opt.UseSqlServer("Data Source=kriss\\sqlexpress;Initial Catalog=ToolMonitorStorage;Integrated Security=True;TrustServerCertificate=True"));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


//builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(ResponseBase<>).Assembly); });





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
