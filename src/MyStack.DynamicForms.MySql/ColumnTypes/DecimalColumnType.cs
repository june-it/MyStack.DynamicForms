using Blueprint.DynamicForms.Fields;

namespace Blueprint.DynamicForms.MySql.DynamicForms.ColumnTypes
{
    public class DecimalColumnType : ColumnTypeBase
    {
        public DecimalColumnType(FieldBase field) : base(field)
        {
        }
        protected override string ColumnType
        {
            get
            {
                if (Field is IDecimalField decimalField)
                {
                    return $"DECIMAL(20,{decimalField.DecimalPlaces})";
                }
                return "DECIMAL(20,8)";
            }
        }
    }
}
