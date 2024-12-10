using Blueprint.DynamicForms.Fields;

namespace Blueprint.DynamicForms.MySql.DynamicForms.ColumnTypes
{
    public abstract class ColumnTypeBase : IColumnType
    {
        protected FieldBase Field { get; }
        public ColumnTypeBase(FieldBase field)
        {
            Field = field;
        }
        public virtual string GetAddText() => $"ADD COLUMN `{Field.Name}` {ColumnType} {NullText} {DefaultText} {CommentText}";
        public virtual string GetChangeText(string? oldName) => $"CHANGE COLUMN `{oldName}` `{Field.Name}` {ColumnType} {NullText} {DefaultText} {CommentText}";
        public virtual string GetDropText() => $"DROP COLUMN `{Field.Name}`";

        protected abstract string ColumnType { get; }
        protected virtual string NullText => Field.Required ? "NOT NULL" : "NULL";
        protected virtual string DefaultText
        {
            get
            {
                if (Field.GetDefaultValue() == null && Field.Required)
                    throw new ArgumentNullException(nameof(DefaultText), "必填字段的须设置默认值");
                return Field.GetDefaultValue() == null ? "DEFAULT NULL" : $"DEFAULT '{Field.GetDefaultValue()}'";
            }
        }
        protected virtual string CommentText => $"COMMENT '{Field.DisplayName}'";

    }
}
