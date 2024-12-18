namespace MyStack.DynamicForms.Queries
{
    public class SqlQuery
    {
        public SqlQuery(string commandText)
        {
            CommandText = commandText;
        }
        public string CommandText { get; private set; }
        public Dictionary<string, object>? Parameters { get; set; }
        public uint Skip { get; set; }
        public uint Take { get; set; }
    }
}
