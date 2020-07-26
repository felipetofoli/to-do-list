using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDo.Core.Domain.Gateways;
using ToDo.Core.Domain.UseCases;
using ToDo.Core.UseCases;

namespace ToDo.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Add Use Cases
            services.AddScoped<ICreateUseCase, Create>();
            services.AddScoped<IDoUseCase, Do>();
            services.AddScoped<IListUseCase, List>();
            services.AddScoped<IRemoveUseCase, Remove>();
            services.AddScoped<IUndoUseCase, Undo>();

            // Add Data Gateway
            services.AddScoped<IDataGateway, InMemoryDataGateway>();
            services.AddSingleton<InMemoryDataContext>();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
