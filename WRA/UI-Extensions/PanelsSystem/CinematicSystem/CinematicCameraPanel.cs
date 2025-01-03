using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace WRA.UI_Extensions.PanelsSystem.CinematicSystem
{
    public class CinematicCameraPanel : PanelBase
    {
        [SerializeField] private Curtain[] curtains;
        
        private float currentDelta = 0;
        private TweenerCore<float, float, FloatOptions> currentTween;

        public override void OnCreate()
        {
            var cinematicCameraData = GetDataAsType<CinematicCameraData>();

            if (cinematicCameraData == null)
                return;

            currentDelta = cinematicCameraData.StartAsShow ? 1 : 0;
            
            UpdateCurtains();
        }
        
        public override void OnShow()
        {
            ShowCurtains();
        }

        public override void OnHide()
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
