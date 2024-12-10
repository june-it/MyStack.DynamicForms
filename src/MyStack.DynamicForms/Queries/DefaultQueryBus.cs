using System.Dynamic;

namespace Blueprint.DynamicForms.Queries
{
    public class DefaultQueryBus : IQueryBus
    {
        protected IQueryRepository QueryRepository { get; }
        protected ISqlQueryHandler QueryHandler { get; }
        public DefaultQueryBus(IQueryRepository queryRepository, ISqlQueryHandler queryHandler)
        {
            QueryRepository = queryRepository;
            QueryHandler = queryHandler;

        }
        public async Task<List<ExpandoObject>> QueryAsync(string queryName, uint skip, uint take, Dictionary<string, object>? parameters = null)
        {
            if (string.IsNullOrEmpty(queryName)) throw new ArgumentNullException(nameof(queryName), "查询名称不能为空");
            var query = await QueryRepository.GetAsync(queryName);
            if (query == null)
                throw new ArgumentException($"未定义的查询{queryName}");
            return await QueryHandler.HandleAsync(new SqlQuery(query.Value) { Skip = skip, Take = take, Parameters = parameters });
        }

        public async Task<ExpandoObject> QuerySingleAsync(string queryName, Dictionary<string, object>? parameters = null)
        {
            var items = await QueryAsync(queryName, 0, 1, parameters);
            if (items.Count == 0)
                return new ExpandoObject();
            return items[0];
        }
    }
}
