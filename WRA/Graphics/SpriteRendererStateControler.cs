using UnityEngine;
using WRA.Utility.CustomTypes;

namespace WRA.Graphics
{
    public class SpriteRendererStateControler : MonoBehaviour
    {
        [SerializeField] private int startId = 0;
        [SerializeField] private Sprite[] sprites;

        private RangedValueInt Id
        {
            get
            {
                if (id == null)
                {
                    Awake();
                }

                return id;
            }
        }
    
        private SpriteRenderer spriteRenderer;
        private RangedValueInt id;

        private void Awake()
        {
            id = new RangedValueInt(0, sprites.Length - 1);
        }
    
        void Update()
        {
            UpdateTexture();
        }

        public void Next()
        {
            Id.Next();
        }

        public void Previous()
        {
            Id.Previous();
        
        }

        public void SetSpriteId(int id)
        {
            Id.Value = id;
        }
    
        private void UpdateTexture()
        {
            spriteRenderer.sprite = sprites[Id.Value];
        }
    }
}
