using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationRestriction : MonoBehaviour
{

    public float restrictionAngle = -50;

    // Update is called once per frame
    void LateUpdate()
    {
        var rotation = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform);

        if (rotation.x < restrictionAngle)
        {
            UnityEditor.TransformUtils.SetInspectorRotation(gameObject.transform, new Vector3(restrictionAngle, rotation.y, rotation.z));
        }
    }


}
