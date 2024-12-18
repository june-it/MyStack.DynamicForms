using Microsoft.Extensions.DependencyInjection;

namespace MyStack.DynamicForms
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
