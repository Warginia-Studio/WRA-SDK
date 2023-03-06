using System;

namespace Utility.CustomAttributes.CustomProperty
{
    public class CustomSerializedField : Attribute
    {
        public bool Reguired { get; private set; }
        public CustomSerializedField(bool reuired = false)
        {
            this.Reguired = reuired;
        }
    }
}
