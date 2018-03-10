using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

using Notes.Model;
using Notes.Persistence;

using Npgsql.EntityFrameworkCore;

using Swashbuckle.AspNetCore.Swagger;

namespace Notes.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();

            services.AddEntityFrameworkNpgsql();
            services.AddDbContext<NoteContext>(options => options.UseNpgsql(Configuration["ConnectionString"]));

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "Notes.WebApi", Version = "v1" });
            });

            services.AddScoped<INoteRepository, NoteRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            using (var theServiceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope()) {
                var theNoteContext = theServiceScope.ServiceProvider.GetService<NoteContext>();
                theNoteContext.Database.Migrate();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notes.WebApi V1"));

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
