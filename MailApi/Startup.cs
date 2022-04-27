using Microsoft.EntityFrameworkCore;
using Shop.Data;


namespace MailApi
{
    public class Startup
    {
        private IConfigurationRoot _confstring;

        public Startup(IHostEnvironment hostEnv)
        {
            _confstring = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsetting.json")
                .Build();
        }
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<AppDBContent>(options => options.UseNpgsql(_confstring.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env) 
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();
            
        }
        
    }
}