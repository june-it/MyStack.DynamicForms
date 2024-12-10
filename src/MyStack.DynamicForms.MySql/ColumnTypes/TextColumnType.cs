using Blueprint.DynamicForms.Fields;

namespace Blueprint.DynamicForms.MySql.DynamicForms.ColumnTypes
{
    public class TextColumnType : ColumnTypeBase
    {
        public TextColumnType(FieldBase field) : base(field)
        {
        }
        protected override string ColumnType => "TEXT";
    }
}
