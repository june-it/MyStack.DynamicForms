using Blueprint.DynamicForms.Fields;

namespace Blueprint.DynamicForms.MySql.DynamicForms.ColumnTypes
{
    public interface IColumnTypeDefinitionRegistrar
    {
        void AddColumnTypeDefinition<TColumnTypeDefinition>(FieldType fieldType)
              where TColumnTypeDefinition : IColumnType;
    }
}
