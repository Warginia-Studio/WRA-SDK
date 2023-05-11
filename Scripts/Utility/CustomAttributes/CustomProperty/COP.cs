using System;
using Object = UnityEngine.Object;

namespace Utility.CustomAttributes.CustomProperty
{
    [Serializable]
    public class COP<T> where T : Object
    {
        public T serializedProperty;
    }
}
