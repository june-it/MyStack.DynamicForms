using System.Data;
using Blueprint.DynamicForms.Queries;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace Blueprint.DynamicForms.MySql.Queries
{
    public class MySqlQueryRepository : IQueryRepository
    {
        public MySqlQueryRepository(IOptions<MySqlOptions> options)
        {
            ConnectionString = options.Value.ConnectionString;
        }
        protected string ConnectionString { get; }

        public async Task<List<Query>> GetListAsync(int skip, int take, string? keyword = null)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                var commandText = $"SELECT * FROM Queries ";
                if (!string.IsNullOrEmpty(keyword))
                    commandText += $" WHERE `Name` LIKE '%{keyword}%'";
                command.CommandText = $"{commandText} LIMIT {skip},{take}";
                var adapter = new MySqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                var items = new List<Query>();
                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in dataSet.Tables[0].Rows)
                    {
                        var name = Convert.ToString(dataSet.Tables[0].Rows[0]["Name"]) ?? "";
                        var value = Convert.ToString(dataSet.Tables[0].Rows[0]["Value"]) ?? "";
                        items.Add(new Query(name, value));
                    }
                }
                return items;
            }
        }
        public async Task<Query> GetAsync(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM Queries WHERE `Name` = @Name";
                command.Parameters.AddWithValue("@Name", name);
                var adapter = new MySqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    var value = Convert.ToString(dataSet.Tables[0].Rows[0]["Value"]) ?? "";
                    return new Query(name, value);
                }
                return default!;
            }
        }

        public async Task<Query> InsertAsync(Query query)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO Queries (`Name`,`Value`) VALUES (@Name,@Value);";
                command.Parameters.AddWithValue("@Name", query.Name);
                command.Parameters.AddWithValue("@Value", query.Value);
                object? result = await command.ExecuteScalarAsync();
                if (result == null)
                    throw new InvalidOperationException("插入新记录失败");
                return new Query(query.Name, query.Value);
            }
        }

        public async Task UpdateAsync(Query query)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = $"UPDATE Queries SET  `Value`=@Value WHERE `Name`=@Name;";
                command.Parameters.AddWithValue("@Name", query.Name);
                command.Parameters.AddWithValue("@Value", query.Value);
                await command.ExecuteNonQueryAsync();
            }
        }
        public async Task DeleteAsync(Query query)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM Queries WHERE `Name`=@Name;";
                command.Parameters.AddWithValue("@Name", query.Name);
                await command.ExecuteNonQueryAsync();
            }
        }

    }
}
