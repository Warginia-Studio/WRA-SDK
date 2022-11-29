using System;
using UnityEngine;

namespace UIExtension.UI
{
    public class DraggingData
    {
        public DraggingData(Dragable draggingGameObjcet, Type draggingType)
        {
            DraggingType = draggingType;
            DraggingGameObjcet = draggingGameObjcet;
        }
        
        public Type DraggingType;
        public Dragable DraggingGameObjcet;
    }
}