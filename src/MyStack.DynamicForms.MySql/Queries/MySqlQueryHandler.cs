using System.Data;
using System.Dynamic;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using MyStack.DynamicForms.Queries;

namespace MyStack.DynamicForms.MySql.Queries
{
    public class MySqlQueryHandler : ISqlQueryHandler
    {
        public MySqlQueryHandler(IOptions<MySqlOptions> options)
        {
            ConnectionString = options.Value.ConnectionString;
        }
        protected string ConnectionString { get; }
        public async Task<List<ExpandoObject>> HandleAsync(SqlQuery query)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM {query.CommandText} LIMIT {query.Skip},{query.Take}";
                if (query.Parameters != null)
                {
                    foreach (var parameter in query.Parameters)
                    {
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }
                }
                var adapter = new MySqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                await adapter.FillAsync(dataSet);

                var items = new List<ExpandoObject>();
                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        var item = new ExpandoObject();
                        foreach (DataColumn column in dataSet.Tables[0].Columns)
                        {
                            item.TryAdd(column.ColumnName, row[column.ColumnName]);
                        }
                        items.Add(item);
                    }
                }
                return items;
            }
        }
    }
}
