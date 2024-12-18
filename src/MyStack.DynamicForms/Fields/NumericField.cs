namespace MyStack.DynamicForms.Fields
{
    public class NumericField : FieldBase, IDecimalField
    {
        public NumericField(string name, string displayName, int decimalPlaces, decimal? defaultValue, string? id = null) : base(name, displayName, FieldType.Numeric, id)
        {
            DecimalPlaces = decimalPlaces;
            DefaultValue = defaultValue;
        }

        public int DecimalPlaces { get; set; }
        public decimal? DefaultValue { get; set; }
        public override object? GetDefaultValue() => DefaultValue;
    }
}
