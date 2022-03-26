using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxRotate : MonoBehaviour
{
    public float SkyBoxSpeed;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation",Time.time*SkyBoxSpeed);
    }
}
