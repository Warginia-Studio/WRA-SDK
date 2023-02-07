using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace WRACore.UIExtension.Controls.Buttons
{
    public class ButtonsTriggerController : MonoBehaviour
    {
        public UnityEvent<int> OnIdChanged = new UnityEvent<int>();
        public int SelectedButton { get; private set; } = -1;

        private List<ButtonTrigger> buttonTriggers;

        private void Start()
        {
            InitButtons();
            if(buttonTriggers!=null && buttonTriggers.Count>0)
                buttonTriggers[0].OnPointerClick(null);
        }

        public void OnButtonClick(int id)
        {
            if (SelectedButton == id)
                return;
        
            ResetButtons(id);
            SelectedButton = id;
            OnIdChanged.Invoke(SelectedButton);

        }

        private void ResetButtons(int id)
        {
            for (int i = 0; i < buttonTriggers.Count; i++)
            {
                if (i == id)
                {
                    buttonTriggers[i].SetStatus(true);
                    continue;
                }
                buttonTriggers[i].SetStatus(false);
            }
        }

        private void InitButtons()
        {
            buttonTriggers = transform.GetComponentsInChildren<ButtonTrigger>().ToList();
            for (int i = 0; i < buttonTriggers.Count; i++)
            {
                buttonTriggers[i].OnClick.AddListener(OnButtonClick);
            }
        }
    }
}
