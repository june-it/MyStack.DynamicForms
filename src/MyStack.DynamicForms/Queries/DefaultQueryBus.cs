using System.Dynamic;

namespace MyStack.DynamicForms.Queries
{
    public class DefaultQueryBus : IQueryBus
    {
        protected IQueryStore Store { get; }
        protected ISqlQueryHandler QueryHandler { get; }
        public DefaultQueryBus(IQueryStore store, ISqlQueryHandler queryHandler)
        {
            Store = store;
            QueryHandler = queryHandler;
        }
        public async Task<List<ExpandoObject>?> QueryAsync(string queryName, uint skip, uint take, Dictionary<string, object>? parameters = null)
        {
            if (string.IsNullOrEmpty(queryName)) throw new ArgumentNullException(nameof(queryName), "查询名称不能为空");
            var query = await Store.GetAsync(queryName);
            if (query == null) throw new ArgumentException($"未定义的查询{queryName}");
            return await QueryHandler.HandleAsync(new SqlQuery(query.Value) { Skip = skip, Take = take, Parameters = parameters });
        }

        public async Task<ExpandoObject?> QuerySingleAsync(string queryName, Dictionary<string, object>? parameters = null)
        {
            var items = await QueryAsync(queryName, 0, 1, parameters);
            if (items == null || items.Count == 0)
                return null;
            return items[0];
        }
    }
}
