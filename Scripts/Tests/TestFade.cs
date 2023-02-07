using UIExtension;
using UnityEngine;

namespace Tests
{
    public class TestFade : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                FadeScreen.Instance.FadeIn();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                FadeScreen.Instance.FadeOut();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                FadeScreen.Instance.FadeInOut(1, 2);
            }
        }
    }
}
