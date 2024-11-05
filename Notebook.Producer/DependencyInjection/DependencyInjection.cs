using Microsoft.Extensions.DependencyInjection;
using Notebook.Producer.Interfaces;

namespace Notebook.Producer.DependencyInjection
{
    public static class DependencyInjection
    {
        
        public static void AddProducer(this IServiceCollection services)
        {
            //services.AddScoped<IMessageProducer, Producer>();
        }
        
    }
}