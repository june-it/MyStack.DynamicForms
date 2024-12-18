using MyStack.DynamicForms;
using MyStack.DynamicForms.Queries;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDynamicForm(this IServiceCollection services, Action<IDynamicFormBuilder> configureBuilder)
        {
            var builder = new DynamicFormBuilder(services);
            configureBuilder?.Invoke(builder);
            if (configureBuilder != null)
                builder.Services.Configure(configureBuilder);
            builder.Services.AddTransient<IQueryBus, DefaultQueryBus>();
            return builder.Services;
        }
    }
}
