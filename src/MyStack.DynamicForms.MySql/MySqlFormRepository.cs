using Blueprint.DynamicForms.Fields;
using Blueprint.DynamicForms.MySql.DynamicForms.ColumnTypes;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace Blueprint.DynamicForms.MySql.DynamicForms
{
    public class MySqlFormRepository : FormRepositoryBase,IFormRepository
    {
       
        protected IColumnTypeManager ColumnTypeDefinitionManager { get; }
        public MySqlFormRepository(IOptions<MySqlOptions> options, IColumnTypeManager columnTypeDefinitionManager)
            :base(options) 
        {
            ColumnTypeDefinitionManager = columnTypeDefinitionManager;
        }
        public virtual async Task InsertAsync(Form form)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                await InitTableAsync(connection, form);

                var command = connection.CreateCommand();
                var fieldTexts = new List<string>();
                if (form.Fields != null)
                {
                    foreach (var field in form.Fields)
                    {
                        IColumnType columnTypeDefinition = ColumnTypeDefinitionManager.GetColumnTypeDefinition(field);
                        fieldTexts.Add(columnTypeDefinition.GetAddText());
                    }
                }
                command.CommandText = $"ALTER TABLE `{GetFormName(form.Name)}` {string.Join(',', fieldTexts)} ;";
                await command.ExecuteNonQueryAsync();

                command.CommandText = $"INSERT INTO `Forms` (`Name`,`Value`) VALUES ('{GetFormName(form.Name)}','{JsonConvert.SerializeObject(form)}')";
                await command.ExecuteNonQueryAsync();
            };
        }
        public virtual async Task UpdateAsync(Form form)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                await InitTableAsync(connection, form);

                var command = connection.CreateCommand();
                var fieldTexts = new List<string>();
                var oldForm = await GetOrDefaultAsync(connection, form.Name);
                var newFields = form.Fields ?? new List<FieldBase>();
                var oldFields = oldForm?.Fields ?? new List<FieldBase>();
                /*
                 以存储的定义为准，确保一致
                 */
                foreach (var field in newFields)
                {
                    var oldField = oldFields.FirstOrDefault(x => x.Id == field.Id);
                    IColumnType columnTypeDefinition = ColumnTypeDefinitionManager.GetColumnTypeDefinition(field);

                    if (oldField == null)
                    {
                        fieldTexts.Add(columnTypeDefinition.GetAddText());
                    }
                    else
                    {
                        fieldTexts.Add(columnTypeDefinition.GetChangeText(oldField.Name));
                    }
                }
                foreach (var field in oldFields)
                {
                    var newField = newFields.FirstOrDefault(x => x.Id == field.Id);
                    IColumnType columnTypeDefinition = ColumnTypeDefinitionManager.GetColumnTypeDefinition(field);
                    if (newField == null)
                    {
                        fieldTexts.Add(columnTypeDefinition.GetDropText());
                    }
                }
                command.CommandText = $"ALTER TABLE `{GetFormName(form.Name)}` {string.Join(',', fieldTexts)} ;";
                await command.ExecuteNonQueryAsync();

                command.CommandText = $"UPDATE `Forms` SET VALUE='{JsonConvert.SerializeObject(form)}' WHERE Name='{GetFormName(form.Name)}'";
                await command.ExecuteNonQueryAsync();
            };
        }
        protected virtual async Task InitTableAsync(MySqlConnection connection, Form form)
        {
            var command = connection.CreateCommand();
            command.CommandText = $"CREATE TABLE IF NOT EXISTS `{GetFormName(form.Name)}` (`Id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT) COMMENT = '{form.DisplayName}';"
                + $"ALTER TABLE `{GetFormName(form.Name)}` COMMENT = '{form.DisplayName}'; ";
            await command.ExecuteNonQueryAsync();
        }
        public virtual async Task DeleteAsync(Form form)
        {
            await DeleteAsync(form.Name);
        }
        public virtual async Task DeleteAsync(string formName)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = $"DROP TABLE `{GetFormName(formName)}`;";
                await command.ExecuteNonQueryAsync();
                command.CommandText = $"DELETE FROM `Forms` WHERE `Name`='{GetFormName(formName)}'";
                await command.ExecuteNonQueryAsync();
            };
        }
        public virtual async Task<Form?> GetAsync(string formName)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                return await GetOrDefaultAsync(connection, formName);
            }
        }
    }
}
