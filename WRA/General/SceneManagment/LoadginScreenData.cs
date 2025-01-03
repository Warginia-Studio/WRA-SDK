using UnityEngine;

namespace WRA.General.SceneManagment
{
    [CreateAssetMenu(menuName = "thief01/WRA-SDK/Loading Screen Data")]
    public class LoadginScreenData : ScriptableObject
    {
        public Sprite Image;
        [TextArea(15,20)]
        public string Text;
    }
}
