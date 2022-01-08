using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textFloaterPrefab;
    public Transform TwoDObject; //2D P
    public Transform ThreeDObject;//3D
    public Transform ThreeDParent;//3D Parent

    public void CreateFloater(int WhichObject)
    {
        int RandomNumber = Random.Range(11, 999); //Generate a random number

        //Create the floating prefab based on 2D or 3D test
        if (WhichObject == 2)
        {
            GameObject newFloat = Instantiate(textFloaterPrefab, transform);
            newFloat.transform.position = TwoDObject.position;
            newFloat.GetComponent<FloatingTextSelfer>().TakeInfo(NumberConverter.ConvertNumberToString(RandomNumber));
        }
        else
        {
            GameObject newFloat = Instantiate(textFloaterPrefab, ThreeDParent);
            newFloat.transform.position = ThreeDObject.position;
            newFloat.GetComponent<FloatingTextSelfer>().TakeInfo(NumberConverter.ConvertNumberToString(RandomNumber));
        }

    }

}
