using MyStack.DynamicForms.Fields;

namespace MyStack.DynamicForms.MySql.ColumnTypes
{
    public class DateColumnType : ColumnTypeBase
    {
        public DateColumnType(FieldBase field) : base(field)
        {
        }
        protected override string ColumnType => "DATE";
        protected override string DefaultText
        {
            get
            {
                var dateField = (DateField)Field;
                if (dateField.UseNowAsDefaultValue)
                    return "DEFAULT (NOW())";
                else if (dateField.DefaultValue.HasValue)
                    return $"DEFAULT '{dateField.DefaultValue}'";
                return base.DefaultText;
            }
        }
    }
}
