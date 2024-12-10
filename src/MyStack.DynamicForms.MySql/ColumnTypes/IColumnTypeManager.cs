using Blueprint.DynamicForms.Fields;

namespace Blueprint.DynamicForms.MySql.DynamicForms.ColumnTypes
{
    public interface IColumnTypeManager : IColumnTypeDefinitionRegistrar
    {
        IColumnType GetColumnTypeDefinition(FieldBase field);
    }
}
