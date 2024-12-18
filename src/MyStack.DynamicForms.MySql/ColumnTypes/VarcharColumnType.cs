using MyStack.DynamicForms.Fields;

namespace MyStack.DynamicForms.MySql.ColumnTypes
{
    public class VarcharColumnType : ColumnTypeBase
    {
        public VarcharColumnType(FieldBase field) : base(field)
        {
        }
        protected override string ColumnType
        {
            get
            {
                if (Field is IStringField stringField)
                {
                    return $"VARCHAR({stringField.MaxLength})";
                }
                return "VARCHAR(256)";
            }
        }
    }
}
