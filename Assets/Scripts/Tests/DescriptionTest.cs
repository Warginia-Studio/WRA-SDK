using System.Collections;
using System.Collections.Generic;
using UIExtension.Managers;
using UnityEngine;

public class DescriptionTest : MonoBehaviour
{

    [SerializeField] private string description;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DescriptionManager.Instance.ShowDescription(description);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            DescriptionManager.Instance.HideDescription();
        }
    }
}
