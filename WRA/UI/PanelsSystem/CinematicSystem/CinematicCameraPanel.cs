using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using WRA.General.Patterns;
using WRA.UI.PanelsSystem;

namespace WRA.UI
{
    public class CinematicCameraPanel : PanelBase
    {
        [SerializeField] private Curtain[] curtains;
        
        private float currentDelta = 0;
        private TweenerCore<float, float, FloatOptions> currentTween;

        public override void Open(object data)
        {
            var cinematicCameraData = TryParseData<CinematicCameraData>(data);

            if (cinematicCameraData == null)
                return;

            currentDelta = cinematicCameraData.StartAsShow ? 1 : 0;
            
            UpdateCurtains();
        }

        public override void Close(object data)
        {

        }

        public override void OnShow(object data)
        {
            ShowCurtains();
        }

        public override void OnHide(object data)
        {
            HideCurtains();
        }
    
        public void ShowCurtains()
        {
            currentTween?.Kill();
            currentTween = DOTween.To(() => currentDelta, delta => currentDelta = delta, 1, 1);
            currentTween.onUpdate += UpdateCurtains;
        }

        public void HideCurtains()
        {
            currentTween?.Kill();
            currentTween = DOTween.To(() => currentDelta, delta => currentDelta = delta, 0, 1);
            currentTween.onUpdate += UpdateCurtains;
        }

        private void UpdateCurtains()
        {
            for (int i = 0; i < curtains.Length; i++)
            {
                curtains[i].UpdatePositionByDelta(currentDelta);
            }
        }
    }
}
