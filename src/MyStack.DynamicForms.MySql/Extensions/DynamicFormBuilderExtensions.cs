using Microsoft.Extensions.DependencyInjection;
using MyStack.DynamicForms;
using MyStack.DynamicForms.Fields;
using MyStack.DynamicForms.MySql;
using MyStack.DynamicForms.MySql.DynamicForms;
using MyStack.DynamicForms.MySql.ColumnTypes;
using MyStack.DynamicForms.MySql.Queries;
using MyStack.DynamicForms.Queries;

namespace MyStack
{
    public static class DynamicFormBuilderExtensions
    {
        public static IDynamicFormBuilder UseMySql(this IDynamicFormBuilder builder, Action<MySqlOptions> configure)
        {
            var options = new MySqlOptions();
            configure?.Invoke(options);
            if (configure != null)
                builder.Services.Configure(configure);
            builder.Services.AddTransient<IFormStore, MySqlFormStore>();
            builder.Services.AddTransient<IExpandoStore, MySqlExpandoStore>();
            builder.Services.AddTransient<DefaultColumnTypeManager>();
            builder.Services.AddTransient<IColumnTypeManager>(factory =>
            {
                var definitionManager = factory.GetRequiredService<DefaultColumnTypeManager>();
                definitionManager.AddColumnTypeDefinition<TinyintColumnType>(FieldType.Boolean);
                definitionManager.AddColumnTypeDefinition<DateColumnType>(FieldType.Date);
                definitionManager.AddColumnTypeDefinition<DateTimeColumnType>(FieldType.DateTime);
                definitionManager.AddColumnTypeDefinition<VarcharColumnType>(FieldType.File);
                definitionManager.AddColumnTypeDefinition<VarcharColumnType>(FieldType.Image);
                definitionManager.AddColumnTypeDefinition<VarcharColumnType>(FieldType.Link);
                definitionManager.AddColumnTypeDefinition<VarcharColumnType>(FieldType.Text);
                definitionManager.AddColumnTypeDefinition<TextColumnType>(FieldType.Html);
                definitionManager.AddColumnTypeDefinition<TextColumnType>(FieldType.Markdown);
                definitionManager.AddColumnTypeDefinition<DecimalColumnType>(FieldType.Numeric);
                return definitionManager;
            });

            builder.Services.AddTransient<ISqlQueryHandler, MySqlQueryHandler>();
            builder.Services.AddTransient<IQueryStore, MySqlQueryStore>();

            return builder;
        }
    }
}
