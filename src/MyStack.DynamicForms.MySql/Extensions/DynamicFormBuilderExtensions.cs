using Blueprint.DynamicForms;
using Blueprint.DynamicForms.Fields;
using Blueprint.DynamicForms.MySql;
using Blueprint.DynamicForms.MySql.DynamicForms;
using Blueprint.DynamicForms.MySql.DynamicForms.ColumnTypes;
using Blueprint.DynamicForms.MySql.Queries;
using Blueprint.DynamicForms.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Blueprint
{
    public static class DynamicFormBuilderExtensions
    {
        public static IDynamicFormBuilder UseMySql(this IDynamicFormBuilder builder, Action<MySqlOptions> configure)
        {
            var options = new MySqlOptions();
            configure?.Invoke(options);
            if (configure != null)
                builder.Services.Configure(configure);
            builder.Services.AddTransient<IFormRepository, MySqlFormRepository>();
            builder.Services.AddTransient<IExpandoRepository, MySqlExpandoRepository>();
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
            builder.Services.AddTransient<IQueryRepository, MySqlQueryRepository>();

            return builder;
        }
    }
}
