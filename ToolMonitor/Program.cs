using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToolMonitor.ApplicationServices.API.Domain;
using ToolMonitor.ApplicationServices.API.Mappings;
using ToolMonitor.ApplicationServices.API.Validators;
using ToolMonitor.DataAccess;
using ToolMonitor.DataAccess.CQRS;
using NLog;
using NLog.Web;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;
using ToolMonitor.Authentication;

// Early init of NLog to allow startup and exception logging, before host is built
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
    //builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
    //builder.Services.AddFluentValidation(typeof(AddCompanyRequestValidator).Assembly);
    builder.Services.AddMvcCore().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddCompanyRequestValidator>());
    builder.Services.AddAutoMapper(typeof(ToolsProfile).Assembly);
    builder.Services.AddMediatR(typeof(ResponseBase<>));
    builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();
    builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();
    builder.Services.AddSingleton<AccessCompany>();
    builder.Services.AddControllers();
    builder.Configuration.AddJsonFile("appsettings.json");
    builder.Services.AddDbContext<ToolStorageContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ToolStorageDatabaseConection")));
    //builder.Services.AddDbContext<ToolStorageContext>(opt => opt.UseSqlServer("Data Source=kriss\\sqlexpress;Initial Catalog=ToolMonitorStorage;Integrated Security=True;TrustServerCertificate=True"));
    builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


    //builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(ResponseBase<>).Assembly); });

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    //builder.Logging.SetMinimumLevel(NLog.LogLevel.Trace);



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
    
    ///NLog
    app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    /// NLog
    

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    //app.MapControllers();
    //NLog
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");


    app.Run();

}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;

}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}
