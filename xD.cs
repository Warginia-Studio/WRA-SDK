using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class xD : MonoBehaviour
{
    private MeshRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (renderer == null)
        {
            renderer = GetComponent<MeshRenderer>();
            
        }
    }
}
