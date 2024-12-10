using Microsoft.Extensions.DependencyInjection;

namespace Blueprint.DynamicForms
{
    public class DynamicFormBuilder : IDynamicFormBuilder
    {
        public IServiceCollection Services { get; }
        public DynamicFormBuilder(IServiceCollection services)
        {
            Services = services;
        }
    }
}
