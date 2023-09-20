using System;
using UnityEngine;
using WRA.Utility.Diagnostics;

namespace WRA.UI.PanelsSystem
{
    public abstract class PanelBase : MonoBehaviour
    {
        public abstract void Open(object data);

        public abstract void Close(object data);

        public abstract void OnShow(object data);
    
        public abstract void OnHide(object data);
    
        protected virtual T TryParseData<T>(object data) where T : PanelDataBase
        {
            if (data != null && data is not T)
            {
                WraDiagnostics.LogError($"Data data is type: {data.GetType().FullName} expected {typeof(T).FullName} \n" + System.Environment.StackTrace, Color.red);
                throw(new Exception($"Data data is type: {data.GetType().FullName} expected {typeof(T).FullName}"));
            }
        
            return (T)data;
        }
    
    }
}
