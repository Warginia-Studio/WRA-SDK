using System;

namespace WRA.Utility.CustomAttributes.CustomProperty
{
    public class CSerializedField : Attribute
    {
        public bool Reguired { get; private set; }
        public CSerializedField(bool reuired = false)
        {
            this.Reguired = reuired;
        }
    }
}
