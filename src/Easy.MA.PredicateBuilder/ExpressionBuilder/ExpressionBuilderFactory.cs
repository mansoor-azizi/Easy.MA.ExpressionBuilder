namespace Easy.MA.ExpressionBuilder.ExpressionBuilder
{
    internal static class ExpressionBuilderFactory
    {
        public static IExpressionBuilder GetExpressionBuilder(Type propertyType)
        {
            if (propertyType == typeof(string))
            {
                return new ExpressionBuilderString();
            }
            else if (propertyType == typeof(DateTime) || propertyType == typeof(DateTime?))
            {
                return new ExpressionBuilderDate();
            }
            else if (propertyType == typeof(bool) || propertyType == typeof(bool?))
            {
                return new ExpressionBuilderBool();
            }
            else if (propertyType.IsEnum)
            {
                return new ExpressionBuilderEnum();
            }

            else if (IsNumericType(propertyType))
            {
                return new ExpressionBuilderNumeric();
            }
            else
            {
                throw new NotSupportedException($"Unsupported property type: {propertyType.Name}");
            }
        }

        private static bool IsNumericType(Type type)
        {
            if (type == typeof(int?))
            {
                return true;
            }

            TypeCode typeCode = Type.GetTypeCode(type);
            TypeCode typeCode2 = typeCode;
            if ((uint)(typeCode2 - 5) <= 10u)
            {
                return true;
            }

            return false;
        }
        //private static bool IsNumericType(Type type)
        //{
        //    switch (Type.GetTypeCode(type))
        //    {
        //        case TypeCode.Byte:
        //        case TypeCode.SByte:
        //        case TypeCode.UInt16:
        //        case TypeCode.UInt32:
        //        case TypeCode.UInt64:
        //        case TypeCode.Int16:
        //        case TypeCode.Int32:
        //        case TypeCode.Int64:
        //        case TypeCode.Decimal:
        //        case TypeCode.Double:
        //        case TypeCode.Single:
        //            return true;
        //        default:
        //            return false;
        //    }
        //}
    }
}

