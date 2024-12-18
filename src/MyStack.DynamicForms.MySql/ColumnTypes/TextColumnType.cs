using MyStack.DynamicForms.Fields;

namespace MyStack.DynamicForms.MySql.ColumnTypes
{
    public class TextColumnType : ColumnTypeBase
    {
        public TextColumnType(FieldBase field) : base(field)
        {
        }
        protected override string ColumnType => "TEXT";
    }
}
