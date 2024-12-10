using System.Dynamic;

namespace Blueprint.DynamicForms.Queries
{
    public interface IQueryBus
    {
        Task<List<ExpandoObject>> QueryAsync(string queryName, uint skip, uint take, Dictionary<string, object>? parameters = null);
        Task<ExpandoObject> QuerySingleAsync(string queryName, Dictionary<string, object>? parameters = null);
    }
}
