using UnityEngine;

namespace WRA.CharacterSystems.SkillsSystem
{
    [System.Serializable]
    public class ActionData
    {
        public ActionController ActionController { get; set; }
        public Transform Transform { get; private set; }

        public ActionData(ActionController actionController)
        {
            ActionController = actionController;
            Transform = actionController.transform;
        }
    
    }
}
