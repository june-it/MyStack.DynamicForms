using MyStack.DynamicForms.Fields;

namespace MyStack.DynamicForms.MySql.ColumnTypes
{
    public interface IColumnTypeManager
    {
        IColumnType GetColumnTypeDefinition(FieldBase field);
    }
}
