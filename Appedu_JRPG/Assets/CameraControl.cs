using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject character;
    public GameObject cameraCenter;
    public float yOffset=1f;
    public float sensitivity = 3f;
    public Camera cam;
    public float scrollSensitivity = 5f;
    public float scrollDampening = 6f;
    public float zoomMin = 3.5f;
    public float zoomMax = 15f;
    public float zoomDefault = 10f;
    public float zoomDistance;
    public float collisionSensitivity = 4.5f;

    public bool tryPoistion = false;
    
    private RaycastHit _camHit;
    private Vector3 _camDist;
    private Vector3 testV3;

    private void Start()
    {
        _camDist = cam.transform.localPosition;
        zoomDistance = zoomDefault;
        _camDist.z = zoomDistance;
        Cursor.visible = false;
    }
    IEnumerator WaitTheSecond() 
    {
        yield return new WaitForSeconds(1f);
        tryPoistion = true;
    }

    private void LateUpdate()
    {
        // The CameraCenter (empty gameobject) follows always the character's position:
        var position1 = character.transform.position;
        cameraCenter.transform.position = new Vector3(position1.x, position1.y + yOffset, position1.z);

        if (Input.GetMouseButton(1))
        {
            RotationCameraWithMouse();
            StartCoroutine(WaitTheSecond());
            
        }
        if (Input.GetAxis("Mouse ScrollWheel") !=0)
        {
                var scrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;
                scrollAmount *= (zoomDistance * 0.8f);
                zoomDistance += scrollAmount * -2f;
                zoomDistance = Mathf.Clamp(zoomDistance, zoomMin, zoomMax);
            

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (_camDist.z != zoomDistance * -2f)
            {
                _camDist.z = Mathf.Lerp(_camDist.z, -zoomDistance, Time.deltaTime * scrollDampening);
            }

            var transform2 = cam.transform;
            transform2.localPosition = _camDist;

            //      // Check and handle Collision
            GameObject obj = new GameObject();
            obj.transform.SetParent(transform2.parent);
            var position = cam.transform.localPosition;
            obj.transform.localPosition = new Vector3(position.x, position.y, position.z - collisionSensitivity);
            //      /*
            //Linecast is an alternative to Raycast, using it to cast a ray between the CameraCenter 
            //and a point directly behind the camera (to smooth things, that's why there's an "obj"
            //GameObject, that is directly behind cam)
            //*/
            if (Physics.Linecast(cameraCenter.transform.position, obj.transform.position, out _camHit))
            {
                //This gets executed if there's any collider in the way
                var transform1 = cam.transform;
                transform1.position = _camHit.point;
                var localPosition = transform1.localPosition;
                localPosition = new Vector3(localPosition.x, localPosition.y, localPosition.z + collisionSensitivity);
                transform1.localPosition = localPosition;
            }
            // Clean up
            Destroy(obj);

            //      // Make sure camera can't clip into player because of collision
            if (cam.transform.localPosition.z > 0f)
            {
                cam.transform.localPosition =
                    new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, -1f);
            }
            //// Apply calculated camera position
            //var transform2 = cam.transform;
            //transform2.localPosition = _camDist;

            //// Check and handle Collision
            //GameObject obj = new GameObject();
            //obj.transform.SetParent(transform2.parent);
            //var position = cam.transform.localPosition;
            //obj.transform.localPosition = new Vector3(position.x, position.y, position.z - collisionSensitivity);
            ///*
            //Linecast is an alternative to Raycast, using it to cast a ray between the CameraCenter 
            //and a point directly behind the camera (to smooth things, that's why there's an "obj"
            //GameObject, that is directly behind cam)
            //*/
            //if (Physics.Linecast(cameraCenter.transform.position, obj.transform.position, out _camHit))
            //{
            //    //This gets executed if there's any collider in the way
            //    var transform1 = cam.transform;
            //    transform1.position = _camHit.point;
            //    var localPosition = transform1.localPosition;
            //    localPosition = new Vector3(localPosition.x, localPosition.y, localPosition.z + collisionSensitivity);
            //    transform1.localPosition = localPosition;
            //}
            //// Clean up
            //Destroy(obj);

            //// Make sure camera can't clip into player because of collision
            //if (cam.transform.localPosition.z > -1f)
            //{
            //    cam.transform.localPosition =
            //        new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, cam.transform.localPosition.z);
            //}
        }
    }

    public void RotationCameraWithMouse() 
    {
        //// The CameraCenter (empty gameobject) follows always the character's position:
        //var position1 = character.transform.position;
        //cameraCenter.transform.position = new Vector3(position1.x, position1.y + yOffset, position1.z);

        //// Rotation of CameraCenter, and thus the camera, depending on Mouse Input:
        ///

        var rotation = cameraCenter.transform.rotation;
        rotation = Quaternion.Euler(rotation.eulerAngles.x - Input.GetAxis("Mouse Y") * sensitivity / 2,
            rotation.eulerAngles.y + Input.GetAxis("Mouse X") * sensitivity, rotation.eulerAngles.z);
        cameraCenter.transform.rotation = rotation;


        // Zooming Input from our Mouse Scroll Wheel
        //if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        //{
        //    var scrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;
        //    scrollAmount *= (zoomDistance * 0.3f);
        //    zoomDistance += scrollAmount * -2f;
        //    zoomDistance = Mathf.Clamp(zoomDistance, zoomMin, zoomMax);
        //}

        //// ReSharper disable once CompareOfFloatsByEqualityOperator
        if (_camDist.z != zoomDistance * -1f)
        {
            _camDist.z = Mathf.Lerp(_camDist.z, -zoomDistance, Time.deltaTime * scrollDampening);
        }
        //---------------------------------------------------------------------------------------

        //      // Apply calculated camera position
        var transform2 = cam.transform;

        //if (Input.GetKey(KeyCode.Y))
        //{

        //    transform2.position = cam.transform.position;
        //}
        
        if (tryPoistion == true)
        {
            transform2.localPosition = _camDist;
            tryPoistion = true;
        }
        transform2.position = cam.transform.position;
        //      // Check and handle Collision
        GameObject obj = new GameObject();
        obj.transform.SetParent(transform2.parent);
        var position = cam.transform.localPosition;
        obj.transform.localPosition = new Vector3(position.x, position.y, position.z - collisionSensitivity);
        //      /*
        //Linecast is an alternative to Raycast, using it to cast a ray between the CameraCenter 
        //and a point directly behind the camera (to smooth things, that's why there's an "obj"
        //GameObject, that is directly behind cam)
        //*/
        if (Physics.Linecast(cameraCenter.transform.position, obj.transform.position, out _camHit))
        {
            //This gets executed if there's any collider in the way
            var transform1 = cam.transform;
            transform1.position = _camHit.point;
            var localPosition = transform1.localPosition;
            localPosition = new Vector3(localPosition.x, localPosition.y, localPosition.z + collisionSensitivity);
            transform1.localPosition = localPosition;
        }
        // Clean up
        Destroy(obj);

        //      // Make sure camera can't clip into player because of collision
        if (cam.transform.localPosition.z > -1f)
        {
            cam.transform.localPosition =
                new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, -1f);
        }
        
    }
}
