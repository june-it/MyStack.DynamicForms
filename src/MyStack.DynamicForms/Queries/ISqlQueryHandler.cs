using System.Dynamic;

namespace MyStack.DynamicForms.Queries
{
    public interface ISqlQueryHandler
    {
        Task<List<ExpandoObject>> HandleAsync(SqlQuery query);
    }
}
