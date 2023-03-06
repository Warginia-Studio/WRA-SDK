using UnityEngine;

namespace DependentObjects.ScriptableObjects.LoadingScreen
{
    [CreateAssetMenu(menuName = "thief01/Loading Screen Data")]
    public class LoadginScreenData : ScriptableObject
    {
        public Sprite Image;
        [TextArea(15,20)]
        public string Text;
    }
}
