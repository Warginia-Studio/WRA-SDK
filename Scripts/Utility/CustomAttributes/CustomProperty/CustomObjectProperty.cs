using System;
using Object = UnityEngine.Object;

namespace Utility.CustomAttributes.CustomProperty
{
    [Serializable]
    public class CustomObjectProperty<T> where T : Object
    {
        public T serializedProperty;
    }
}
