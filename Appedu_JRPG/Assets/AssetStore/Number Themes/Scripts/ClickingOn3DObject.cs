using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickingOn3DObject : MonoBehaviour
{

    //Creates floating number for the 3D game test

    FloatingTextManager AccFTM;

    void Start()
    {
        AccFTM = GameObject.Find("FloatingTextManager").GetComponent<FloatingTextManager>();
    }

    private void OnMouseDown()
    {
        AccFTM.CreateFloater(3); 

    }
}
