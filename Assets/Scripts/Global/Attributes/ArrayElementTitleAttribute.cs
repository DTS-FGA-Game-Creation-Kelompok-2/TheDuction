using UnityEngine;

namespace TheDuction.Global.Attributes{
    public class ArrayElementTitleAttribute: PropertyAttribute
    {
        public readonly string VarName;
        public ArrayElementTitleAttribute(string elementTitleVar)
        {
            VarName = elementTitleVar;
        }
    }
}