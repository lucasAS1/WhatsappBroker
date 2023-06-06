using Autofac;
using WhatsappBroker.Domain.Facade;
using WhatsappBroker.Domain.Services.Interfaces;
using WhatsappBroker.Domain.Services.Services;
using WhatsappBroker.Infrastructure.Agents.Interfaces;
using WhatsappBroker.Infrastructure.Interfaces;

namespace WhatsappBroker.Application.WebApi;

public class IocContainer : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        ConfigureInfrastructureLayer(builder);
        ConfigureDomainLayer(builder);
    }

    private static void ConfigureInfrastructureLayer(ContainerBuilder builder)
    {
        builder.RegisterType<WhatsappAgent>().As<IWhatsappAgent>();
    }
    
    private static void ConfigureDomainLayer(ContainerBuilder builder)
    {
        builder.RegisterType<WhatsappService>().As<IWhatsappService>();
        builder.RegisterType<WhatsappFacade>().As<IWhatsappFacade>();
    }
}