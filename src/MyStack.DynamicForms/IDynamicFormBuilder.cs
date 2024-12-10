using Microsoft.Extensions.DependencyInjection;

namespace Blueprint.DynamicForms
{
    public interface IDynamicFormBuilder
    {
        IServiceCollection Services { get; }
    }
}
