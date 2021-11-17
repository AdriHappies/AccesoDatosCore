using AccesoDatosCore.Data;
using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore
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
            //bicis
            {
                Bici cannondale = new Bici();
                cannondale.Marca = "Cannondale";
                cannondale.Imagen = "cannondale.jpg";
                cannondale.Velocidad = 0;
                cannondale.Aceleracion = 6;

                Bici felt = new Bici();
                felt.Marca = "Felt";
                felt.Imagen = "felt.jpg";
                felt.Velocidad = 0;
                felt.Aceleracion = 4;

                //inyectamos bici
                services.AddTransient<Bici>(bici => felt);
            }

            String cadenaconexion = this.Configuration.GetConnectionString("hospitallocal");
            EmpleadosContext context = new EmpleadosContext(cadenaconexion);
            PlantillasContext pcontext = new PlantillasContext(cadenaconexion);
            services.AddTransient<EmpleadosContext>(contexto => context);
            services.AddTransient<PlantillasContext>(contexto => pcontext);

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
