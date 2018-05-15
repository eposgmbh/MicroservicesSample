using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

using Epos.Eventing.RabbitMQ;

using Notes.Model;
using Notes.Persistence;

using Npgsql.EntityFrameworkCore;

using Swashbuckle.AspNetCore.Swagger;
using RabbitMQ.Client;

#pragma warning disable 1591

namespace Notes.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddEntityFrameworkNpgsql();
            services.AddDbContext<NoteContext>(options => options.UseNpgsql(Configuration["ConnectionString"]));

            services.AddSwaggerGen(c => {
                c.SwaggerDoc(
                    "v1",
                    new Info {
                        Title = "Notes.WebApi",
                        Version = "v1",
                        Description = "Notes Wep API",
                        Contact = new Contact { Name = "Epos GmbH", Url = "https://github.com/eposgmbh/" }
                    }
                );

                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Notes.WebApi.xml"));
            });

            services.AddScoped<INoteRepository, NoteRepository>();

            services.AddIntegrationEventPublisherRabbitMQ(
                new ConnectionFactory { HostName = Configuration["RabbitMQHostName"] }
            );
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
