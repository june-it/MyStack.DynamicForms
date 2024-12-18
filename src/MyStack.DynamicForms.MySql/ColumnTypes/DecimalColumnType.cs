using MyStack.DynamicForms.Fields;

namespace MyStack.DynamicForms.MySql.ColumnTypes
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
