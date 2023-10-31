using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MeuCampeonato.Repositories.Interfaces;
using MeuCampeonato.Repositories;
using MeuCampeonato.Models;

namespace MeuCampeonato
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string? connectionString = Configuration.GetConnectionString("MySqlConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            
            services.AddScoped<IUsuarioRepositorio,UsuarioRepositorio>();
            services.AddScoped<ITimeRepositorio,TimeRepositorio>();
            services.AddScoped<ICampeonatoRepositorio,CampeonatoRepositorio>();
            services.AddScoped<IJogoRepositorio,JogoRepositorio>();


            services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder => builder.WithOrigins("http://react-app:3000")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseCors("AllowReactApp");
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}