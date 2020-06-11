using GoodBooks.Data.Database;
using GoodBooks.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GoodBooks.Web
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
            services.AddCors(); // we need to add it to our services to be able to configure them in method below
            services.AddControllers();
            services.AddDbContext<GoodBooksDbContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("GoodBooks")));

            services.AddTransient<IBookService, BookService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection(); // order of methods in Configure method is likely to be important

            app.UseRouting();

            app.UseCors(builder => builder // we need this because we would like to connect our frontend service to be connected from everywhere
                .AllowAnyHeader() 
                .AllowAnyMethod()
                .WithOrigins(
                    "http://localhost:8080" // our frontend
                )); // it's good practise to specify exact origins instead of doing like that, but thats just an example

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
