using System;
using System.Reflection;

namespace EnumsAndCustomAttributes_Sample
{
    public static class Extensons
    {
        public static string GetAlternateValue(this Enum Value)
        {
            Type Type = Value.GetType();

            FieldInfo FieldInfo = Type.GetField(Value.ToString());

            AlternateValueAttribute Attribute = FieldInfo.GetCustomAttribute(
                typeof(AlternateValueAttribute)
            ) as AlternateValueAttribute;

            return Attribute.AlternateValue;
        }
    }
}
