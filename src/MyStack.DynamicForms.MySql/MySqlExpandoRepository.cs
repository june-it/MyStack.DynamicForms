using System.Data;
using System.Dynamic;
using System.Text;
using Blueprint.DynamicForms;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace Blueprint.DynamicForms.MySql.DynamicForms
{
    public class MySqlExpandoRepository : FormRepositoryBase, IExpandoRepository
    {
        public MySqlExpandoRepository(IOptions<MySqlOptions> options) : base(options)
        {
        }

        public async Task InsertAsync(string formName, ExpandoObject expando)
        {
            if (expando == null) throw new ArgumentNullException(nameof(expando), "表单对象为空");
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                var form = await GetOrDefaultAsync(connection, formName);
                if (form == null)
                    throw new ArgumentException($"表单`{formName}`未被定义");
                var columns = new Dictionary<string, object?>();
                foreach (var item in expando)
                {
                    var field = form.Fields?.FirstOrDefault(x => x.Name == item.Key);
                    if (field == null)
                        throw new ArgumentException($"表单未定义字段名`{item.Key}`");
                    field.TestValue(item.Value);
                    columns.Add(field.Name, item.Value);
                }
                var commandText = new StringBuilder($"INSERT INTO `{GetFormName(formName)}` ({string.Join(',', columns.Select(x => $"`{x.Key}`"))}) VALUES({string.Join(',', columns.Select(x => "@" + x.Key))})");
                var command = connection.CreateCommand();
                command.CommandText = commandText.ToString();
                foreach (var column in columns)
                    command.Parameters.AddWithValue("@" + column.Key, column.Value);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateAsync(string formName, ExpandoObject expando)
        {
            if (expando == null) throw new ArgumentNullException(nameof(expando), "表单对象为空");
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                var form = await GetOrDefaultAsync(connection, formName);
                if (form == null)
                    throw new ArgumentException($"表单`{formName}`未被定义");
                var columns = new Dictionary<string, object?>();
                foreach (var item in expando)
                {
                    var field = form.Fields?.FirstOrDefault(x => x.Name == item.Key);
                    if (item.Key == "Id")
                        continue;
                    if (field == null)
                        throw new ArgumentException($"表单未定义字段名`{item.Key}`");
                    field.TestValue(item.Value);
                    columns.Add(field.Name, item.Value);
                }
                var commandText = new StringBuilder($"UPDATE `{GetFormName(formName)}` SET  {string.Join(",", columns.Select(x => $"{x.Key}=@{x.Key}"))} WHERE `Id` =@Id");
                var command = connection.CreateCommand();
                command.CommandText = commandText.ToString();
                command.Parameters.AddWithValue("@Id", ((dynamic)expando).Id);
                foreach (var column in columns)
                    command.Parameters.AddWithValue("@" + column.Key, column.Value);
                await command.ExecuteNonQueryAsync();
            }
        }


        public async Task<ExpandoObject?> GetAsync(string formName, int id)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                var form = await GetOrDefaultAsync(connection, formName);
                if (form == null)
                    throw new ArgumentException($"表单`{formName}`未被定义");
                var columns = new Dictionary<string, object?>();
                if (form.Fields != null)
                {
                    var columnNames = form.Fields.Select(x => x.Name);
                    var command = connection.CreateCommand();
                    command.CommandText = $"SELECT {string.Join(",", columnNames)} FROM `{GetFormName(formName)}`";

                    var dataSet = new DataSet();
                    var adapter = new MySqlDataAdapter(command);
                    await adapter.FillAsync(dataSet);

                    var expando = new ExpandoObject();
                    if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        var row = dataSet.Tables[0].Rows[0];
                        foreach (DataColumn column in dataSet.Tables[0].Columns)
                        {
                            expando.TryAdd(column.ColumnName, row[column.ColumnName]);
                        }
                    }
                    return expando;
                }
                return default;
            }
        }

        public async Task DeleteAsync(string formName, int id)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                var form = await GetOrDefaultAsync(connection, formName);
                if (form == null)
                    throw new ArgumentException($"表单`{formName}`未被定义");
                var command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM `{GetFormName(formName)}` WHERE `Id`=@Id";
                command.Parameters.AddWithValue("@Id", id);
                await command.ExecuteNonQueryAsync();

            }
        }

    }
}
