using MyStack.DynamicForms.Fields;

namespace MyStack.DynamicForms.MySql.ColumnTypes
{
    public interface IColumnTypeDefinitionRegistrar
    {
        void AddColumnTypeDefinition<TColumnTypeDefinition>(FieldType fieldType)
              where TColumnTypeDefinition : IColumnType;
    }
}
