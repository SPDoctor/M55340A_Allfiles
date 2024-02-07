using Underwater.Data;
using Underwater.Middleware;
using Underwater.Repositories;

namespace Underwater
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUnderwaterRepository, UnderwaterRepository>();

            services.AddDbContext<UnderwaterContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            app.UseNodeModules(env.ContentRootPath);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "UnderwaterRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Aquarium", action = "Index" },
                    constraints: new { id = "[0-9]+" });
            });
        }
    }
}
