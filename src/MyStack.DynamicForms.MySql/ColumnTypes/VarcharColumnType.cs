using Blueprint.DynamicForms.Fields;

namespace Blueprint.DynamicForms.MySql.DynamicForms.ColumnTypes
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
