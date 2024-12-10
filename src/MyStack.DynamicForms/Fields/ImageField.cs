namespace Blueprint.DynamicForms.Fields
{
    public class ImageField : FieldBase
    {
        public ImageField(string name, string displayName, bool multiple, string[]? mimeTypes, int maxFileSize, string? defaultValue, string? id = null)
            : base(name, displayName, FieldType.Image, id)
        {
            Multiple = multiple;
            MimeTypes = mimeTypes;
            MaxFileSize = maxFileSize;
            DefaultValue = defaultValue;
        }
        public bool Multiple { get; set; }
        public string[]? MimeTypes { get; set; }
        public int MaxFileSize { get; set; }
        public string? DefaultValue { get; set; }
        public override object? GetDefaultValue() => DefaultValue;
    }
}
