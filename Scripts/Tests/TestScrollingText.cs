using UIExtension.TextControl;
using UnityEngine;

namespace Tests
{
    public class TestScrollingText : MonoBehaviour
    {
        [SerializeField] private TextScrolling textScrolling;

        [SerializeField] private string text;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                textScrolling.ShowText(text);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                textScrolling.ShowText("XDDXDD");
            }
        }
    }
}
