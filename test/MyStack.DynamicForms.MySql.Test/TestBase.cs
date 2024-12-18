using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MyStack.DynamicForms.MySql.Test
{
    public abstract class TestBase
    {
        protected IServiceProvider? ServiceProvider { get; private set; }
        [TestInitialize]
        public void Setup()
        {
            var builder = new HostBuilder()
              .ConfigureHostConfiguration(configure =>
              {
                  configure.SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json");
              })
              .ConfigureServices((context, services) =>
              {
                  services.AddDynamicForm(configureBuilder =>
                  {
                      configureBuilder.UseMySql(configure =>
                      {
                          configure.ConnectionString = context.Configuration.GetConnectionString("Default")!;

                      });
                  });
              });

            var app = builder.Build();
            ServiceProvider = app.Services;
        }
    }
}
