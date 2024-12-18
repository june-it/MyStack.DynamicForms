﻿using MyStack.DynamicForms.Fields;

namespace MyStack.DynamicForms.MySql.ColumnTypes
{
    public class DefaultColumnTypeManager : IColumnTypeManager, IColumnTypeDefinitionRegistrar
    {
        private Dictionary<FieldType, Type>? ColumnTypeDefinitionTypes { get; set; }
        public void AddColumnTypeDefinition<TColumnTypeDefinition>(FieldType fieldType) where TColumnTypeDefinition : IColumnType
        {
            ColumnTypeDefinitionTypes ??= [];
            ColumnTypeDefinitionTypes.TryAdd(fieldType, typeof(TColumnTypeDefinition));
        }

        public IColumnType GetColumnTypeDefinition(FieldBase field)
        {
            IColumnType columnTypeDefinition;
            if (ColumnTypeDefinitionTypes != null && ColumnTypeDefinitionTypes.TryGetValue(field.FieldType, out var columnTypeDefinitionType))
            {
                var obj = Activator.CreateInstance(columnTypeDefinitionType, [field]) ?? throw new InvalidOperationException($"无法创建{columnTypeDefinitionType.FullName}的实例对象");
                columnTypeDefinition = (IColumnType)obj;
            }
            else
                columnTypeDefinition = new TextColumnType(field);
            return columnTypeDefinition;
        }
    }
}
