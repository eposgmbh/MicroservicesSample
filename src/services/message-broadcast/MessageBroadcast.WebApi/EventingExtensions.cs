using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Epos.Eventing;

using MessageBroadcast.WebApi.IntegrationEvents;

#pragma warning disable 1591

namespace MessageBroadcast.WebApi
{
    public static class IntegrationEventExtensions
    {
        public static IServiceCollection AddIntegrationEventHandlers(this IServiceCollection serviceCollection) {
            return serviceCollection.AddSingleton<NoteAddedIntegrationEventHandler>();
        }

        public static IApplicationBuilder UseIntegrationEventSubscriptions(this IApplicationBuilder app) {
            var theRegistry = app.ApplicationServices.GetRequiredService<IIntegrationEventSubscriber>();

            theRegistry.Subscribe<NoteAddedIntegrationEvent, NoteAddedIntegrationEventHandler>();

            return app;
        }
    }
}
