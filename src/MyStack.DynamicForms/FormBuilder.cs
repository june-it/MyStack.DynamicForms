using Blueprint.DynamicForms.Fields;

namespace Blueprint.DynamicForms
{
    public class FormBuilder
    {
        protected Form? Form { get; private set; }
        public FormBuilder()
        {
        }
        public FormBuilder New(string name, string displayName)
        {
            Form = new Form(name, displayName);
            return this;
        }
        public FormBuilder SetField<TField>(TField field)
            where TField : FieldBase
        {
            if (Form == null) throw new InvalidOperationException("必须使用New访问创建Form对象。");
            Form.Fields ??= new List<FieldBase>();
            if (Form.Fields.Exists(x => x.Name == field.Name))
                throw new ArgumentException(nameof(field.Name), $"字段名{field.Name}重复");
            Form.Fields.Add(field);
            return this;
        }
        public FormBuilder SetBooleanField(string name, string displayName, bool? defaultValue, string? id = null, bool required = false, bool unique = false)
        {
            return SetField(new BooleanField(name, displayName, defaultValue, id) { Required = required, Unique = unique });
        }
        public FormBuilder SetDateField(string name, string displayName, bool useNowAsDefaultValue, DateTime? defaultValue, string? id = null, bool required = false, bool unique = false)
        {
            return SetField(new DateField(name, displayName, useNowAsDefaultValue, defaultValue, id) { Required = required, Unique = unique });
        }
        public FormBuilder SetDateTimeField(string name, string displayName, bool useNowAsDefaultValue, DateTime? defaultValue, string? id = null, bool required = false, bool unique = false)
        {
            return SetField(new DateTimeField(name, displayName, useNowAsDefaultValue, defaultValue, id) { Required = required, Unique = unique });
        }
        public FormBuilder SetFileField(string name, string displayName, string[]? mimeTypes, int maxFileSize, string? defaultValue, string? id = null, bool required = false, bool unique = false)
        {
            return SetField(new FileField(name, displayName, mimeTypes, maxFileSize, defaultValue, id));
        }
        public FormBuilder SetHtmlField(string name, string displayName, string? defaultValue, string? id = null, bool required = false, bool unique = false)
        {
            return SetField(new HtmlField(name, displayName, defaultValue, id) { Required = required, Unique = unique });
        }
        public FormBuilder SetImageField(string name, string displayName, bool multiple, string[]? mimeTypes, int maxFileSize, string? defaultValue, string? id = null, bool required = false, bool unique = false)
        {
            return SetField(new ImageField(name, displayName, multiple, mimeTypes, maxFileSize, defaultValue, id) { Required = required, Unique = unique });
        }
        public FormBuilder SetLinkField(string name, string displayName, string target, string? defaultValue, string? id = null, bool required = false, bool unique = false)
        {
            return SetField(new LinkField(name, displayName, target, defaultValue, id) { Required = required, Unique = unique });
        }
        public FormBuilder SetMarkdownField(string name, string displayName, string? defaultValue, string? id = null, bool required = false, bool unique = false)
        {
            return SetField(new MarkdownField(name, displayName, defaultValue, id) { Required = required, Unique = unique });
        }
        public FormBuilder SetMultiTextField(string name, string displayName, string? defaultValue, string? id = null, bool required = false, bool unique = false)
        {
            return SetField(new MultiTextField(name, displayName, defaultValue, id) { Required = required, Unique = unique });
        }
        public FormBuilder SetNumericField(string name, string displayName, int decimalPlaces, decimal? defaultValue, string? id = null, bool required = false, bool unique = false)
        {
            return SetField(new NumericField(name, displayName, decimalPlaces, defaultValue, id) { Required = required, Unique = unique });
        }
        public FormBuilder SetTextField(string name, string displayName, int maxLength, string? defaultValue, string? id = null, bool required = false, bool unique = false)
        {
            return SetField(new TextField(name, displayName, maxLength, defaultValue, id) { Required = required, Unique = unique });
        }
        public FormBuilder SetTimeField(string name, string displayName, TimeSpan? defaultValue, string? id = null, bool required = false, bool unique = false)
        {
            return SetField(new TimeField(name, displayName, defaultValue, id) { Required = required, Unique = unique });
        }
        public Form Build()
        {
            if (Form != null && Form.Fields != null)
            {
                foreach (var field in Form.Fields)
                    field.Valid();
            }
            return Form!;
        }
    }
}
