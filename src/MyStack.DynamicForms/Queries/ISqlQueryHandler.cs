using System.Dynamic;

namespace Blueprint.DynamicForms.Queries
{
    public interface ISqlQueryHandler
    {
        Task<List<ExpandoObject>> HandleAsync(SqlQuery query);
    }
}
