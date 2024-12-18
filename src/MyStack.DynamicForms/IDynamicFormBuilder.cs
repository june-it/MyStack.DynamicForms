using Microsoft.Extensions.DependencyInjection;

namespace MyStack.DynamicForms
{
    public interface IDynamicFormBuilder
    {
        IServiceCollection Services { get; }
    }
}
