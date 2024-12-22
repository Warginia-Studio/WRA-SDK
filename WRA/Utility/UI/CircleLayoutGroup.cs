using System;
using UnityEngine;

namespace WRA.Utility.UI
{
    [ExecuteInEditMode]
    public class CircleLayoutGroup : MonoBehaviour
    {
        [SerializeField] private float radius;
        [SerializeField] private float angle;
        [SerializeField] private float startAngle;
        [SerializeField] private bool clockwise;
        [SerializeField] private bool rotateChildren;
        
        private void Start()
        {
            ArrangeChildren();
        }

        private void Update()
        {
            ArrangeChildren();
        }

        private void ArrangeChildren()
        {
            var children = GetComponentsInChildren<Transform>();
            var step = angle / children.Length;
            var currentAngle = startAngle;
            for (var i = 0; i < children.Length; i++)
            {
                if (children[i] == transform)
                    continue;
                var child = children[i];
                var x = Mathf.Cos(currentAngle * Mathf.Deg2Rad) * radius;
                var y = Mathf.Sin(currentAngle * Mathf.Deg2Rad) * radius;
                child.localPosition = new Vector3(x, y, 0);
                if (rotateChildren)
                    child.localRotation = Quaternion.Euler(0, 0, currentAngle + (clockwise ? 90 : -90));
                currentAngle += (clockwise ? step : -step);
            }
        }
    }
}
