using System;

namespace EnumsAndCustomAttributes_Sample
{
    public class AlternateValueAttribute : Attribute
    {
        public string AlternateValue { get; protected set; }

        public AlternateValueAttribute(string value)
        {
            this.AlternateValue = value;
        }
    }
}
