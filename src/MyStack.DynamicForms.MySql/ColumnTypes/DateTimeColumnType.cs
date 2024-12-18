using MyStack.DynamicForms.Fields;

namespace MyStack.DynamicForms.MySql.ColumnTypes
{
    public class DateTimeColumnType : ColumnTypeBase
    {
        public DateTimeColumnType(FieldBase field) : base(field)
        {
        }
        protected override string ColumnType => "DATETIME";
        protected override string DefaultText
        {
            get
            {
                var dateTimeField = (DateTimeField)Field;
                if (dateTimeField.UseNowAsDefaultValue)
                    return "DEFAULT (NOW())";
                else if (dateTimeField.DefaultValue.HasValue)
                    return $"DEFAULT '{dateTimeField.DefaultValue}'";
                return base.DefaultText;
            }
        }
    }
}
