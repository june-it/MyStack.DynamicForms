namespace MyStack.DynamicForms.MySql.ColumnTypes
{
    public interface IColumnType
    {
        string GetAddText();
        string GetChangeText(string? oldName);
        string GetDropText();
    }

}
