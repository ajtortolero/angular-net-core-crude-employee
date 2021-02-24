using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NETCoreCrude.Base.Settting;
using NETCoreCrude.DAL.Repositories;

namespace NETCoreCrudeAPI
{
    /// <summary>
    ///
    /// </summary>
    public class Startup
    {
        /// <summary>
        ///
        /// </summary>
        internal IServiceCollection ServiceCollection;

        /// <summary>
        ///
        /// </summary>
        internal IConfiguration Configuration { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pHostingEnvironment"></param>
        public Startup(IHostingEnvironment pHostingEnvironment)
        {
            #if !DEBUG
                var varConfigurationBuilder = new ConfigurationBuilder()
                    .SetBasePath(pIHostingEnvironment.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();

                Configuration = varConfigurationBuilder.Build();
            #else
                var varConfigurationBuilder = new ConfigurationBuilder()
                    .SetBasePath(pHostingEnvironment.ContentRootPath)
                    .AddJsonFile($"appsettings.{pHostingEnvironment.EnvironmentName}.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();

                Configuration = varConfigurationBuilder.Build();
            #endif
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="pServiceCollection"></param>
        public void ConfigureServices(IServiceCollection pServiceCollection)
        {
            // Configuration
            pServiceCollection.Configure<AppConnectionStrings>(Configuration.GetSection("ConnectionStrings"));

            // Repositories
            pServiceCollection.AddScoped<IAreaRepository, AreaRepository>();
            pServiceCollection.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            pServiceCollection.AddScoped<IEmployeeRepository, EmployeeRepository>();

            // Logger
            pServiceCollection.AddLogging(LoggingBuilder =>
            {
                LoggingBuilder.AddConfiguration(Configuration.GetSection("Logging"));
                LoggingBuilder.AddConsole();
                LoggingBuilder.AddDebug();
            });

            pServiceCollection.AddCors();
            pServiceCollection.AddMvcCore().AddAuthorization().AddJsonFormatters();

            ServiceCollection = pServiceCollection;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="pApplicationBuilder"></param>
        /// <param name="pHostingEnvironment"></param>
        /// <param name="pLoggerFactory"></param>
        public void Configure(IApplicationBuilder pApplicationBuilder, IHostingEnvironment pHostingEnvironment, ILoggerFactory pLoggerFactory)
        {
            // Add MVC to the request pipeline.
            pApplicationBuilder.UseCors(Builder =>
                Builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
            );

            pApplicationBuilder.UseRequestLocalization();
            pApplicationBuilder.UseAuthentication();
            pApplicationBuilder.UseMvc(Routes =>
            {
                Routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                Routes.MapRoute(name: "ApiClientsByName", template: "{controller=Home}/{action=Index}/{name?}");
            });
        }
    }
}