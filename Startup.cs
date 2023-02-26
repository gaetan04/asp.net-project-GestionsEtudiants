using GestionEtudiants.Application;
using GestionEtudiants.Context;
using GestionEtudiants.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionEtudiants
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            });
            /*services.Add(new ServiceDescriptor(typeof(IStudentRepository), 
                new StudentRepository()));//by default a Singleton*/
            /*services.Add(new ServiceDescriptor(typeof(IStudentRepository), 
                typeof(StudentRepository), ServiceLifetime.Singleton));//by default a Singleton*/
            //services.AddSingleton(typeof(IStudentRepository), typeof(StudentRepository));
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IFiliereRepository, FiliereRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
