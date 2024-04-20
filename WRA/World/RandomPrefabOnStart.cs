using UnityEngine;

namespace WRA.World.Map
{
    public class RandomPrefabOnStart : MonoBehaviour
    {
        private void Awake()
        {
            foreach (Transform obj in transform)
            {
                obj.gameObject.SetActive(false);
            }   
            var childs = transform.childCount;
            var random = UnityEngine.Random.Range(0, childs);
            transform.GetChild(random).gameObject.SetActive(true);
        } 
    }
}
