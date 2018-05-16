using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Swashbuckle.AspNetCore.Swagger;

using Epos.Eventing.RabbitMQ;

using MessageBroadcast.WebApi.Hubs;

using RabbitMQ.Client;

#pragma warning disable 1591

namespace MessageBroadcast.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSignalR();
            services.AddCors();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc(
                    "v1",
                    new Info {
                        Title = "MessageBroadcast.WebApi",
                        Version = "v1",
                        Description = "Message Broadcast Wep API",
                        Contact = new Contact { Name = "Epos GmbH", Url = "https://github.com/eposgmbh/" }
                    }
                );

                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "MessageBroadcast.WebApi.xml"));
            });

            services
                .AddIntegrationEventHandlers()
                .AddIntegrationEventSubscriberRabbitMQ(
                    new ConnectionFactory { HostName = Configuration["RabbitMQHostName"] }
                );
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseCors(cp => {
                cp
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MessageBroadcast.WebApi V1"));

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSignalR(routes => {
                routes.MapHub<MessageBroadcastHub>("/hub/v1/message-broadcast");
            });

            app.UseIntegrationEventSubscriptions();
        }
    }
}
