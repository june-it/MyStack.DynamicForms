namespace Blueprint.DynamicForms.MySql.DynamicForms.ColumnTypes
{
    public interface IColumnType
    {
        string GetAddText();
        string GetChangeText(string? oldName);
        string GetDropText();
    }

}
