using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PokerApi.Business.Interfaces.Mappers;
using PokerApi.Business.Interfaces.Service;
using PokerApi.Business.Mappers;
using PokerApi.Business.Services;
using PokerApi.Data;
using PokerApi.Domain.Interfaces;
using PokerApi.Domain.Repository;

namespace PokerApi
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
            string mySqlConnection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(opt => opt.UseMySQL(mySqlConnection));

            services.AddTransient<IPlayersBusiness, PlayersBusiness>();
            services.AddTransient<IPlacesBusiness, PlacesBusiness>();
            services.AddTransient<IFinancialBusiness, FinancialBusiness>();

            services.AddTransient<IPlayerMapper, PlayerMapper>();
            services.AddTransient<IPlaceMapper, PlaceMapper>();
            services.AddTransient<IFinancialMapper, FinancialMapper>();

            services.AddTransient<IGenericRepository, GenericRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IPlaceRepository, PlaceRepository>();
            services.AddTransient<IFinancialRepository, FinancialRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "PokerApi", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PokerApi v1"));
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
