using MyStack.DynamicForms.Fields;

namespace MyStack.DynamicForms.MySql.ColumnTypes
{
    public class TinyintColumnType : ColumnTypeBase
    {
        public TinyintColumnType(FieldBase field) : base(field)
        {
        }
        protected override string ColumnType => "TINYINT(1)";
        protected override string DefaultText
        {
            get
            {
                var booleanField = (BooleanField)Field;
                if (booleanField.DefaultValue.HasValue)
                    return $"DEFAULT {(booleanField.DefaultValue.Value ? 1 : 0)}";
                return "DEFAULT NULL";
            }
        }
    }
}
