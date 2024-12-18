namespace MyStack.DynamicForms.Fields
{
    public class DateField : FieldBase
    {
        public DateField(string name, string displayName, bool useNowAsDefaultValue, DateTime? defaultValue, string? id = null)
            : base(name, displayName, FieldType.Date, id)
        {
            UseNowAsDefaultValue = useNowAsDefaultValue;
            DefaultValue = defaultValue;
        }
        public bool UseNowAsDefaultValue { get; set; }
        public DateTime? DefaultValue { get; set; }
        public override object? GetDefaultValue() => DefaultValue;
    }
}
