using System.Collections;

namespace GenericT_Sample
{
    public static class Extensions
    {
        public static T TryGet<T>(this Hashtable Table, string KeyName, T DefaultValue)
        {
            return (Table[KeyName].GetType() == typeof(T)) ?
                (T)Table[KeyName] :
                DefaultValue;
        }
    }
}
