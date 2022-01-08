using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingTextSelfer : MonoBehaviour
{

    //Parameters to customize the floating behaviour
    TextMeshProUGUI myTextUI;
    public Vector2 YPosRandomLimit;
    public Vector2 XPosRandomLimit;
    public float MotionDuration;
    public Vector2 ScalingRandomLimit;
    public float ScalingDuration;
    public float FadingDuration;
    public float StoppingDuration;
    public float YIncrement;

    static NumberUIManager AccNUIM;

    static float currentY;


    public void TakeInfo(string textToShow)
    {
        if (AccNUIM == null)
        {
            AccNUIM = GameObject.Find("NumberUIManager").GetComponent<NumberUIManager>();
            currentY = YPosRandomLimit.x;
        }

        myTextUI = GetComponent<TextMeshProUGUI>();
        myTextUI.spriteAsset = AccNUIM.CurrentChosenTheme;
        myTextUI.text = textToShow;

        StartCoroutine(FloatTheText());
    }


    IEnumerator FloatTheText()
    {
        //Initilize
        transform.localScale = new Vector3(1, 1, 1);
        float YSpeed = currentY / MotionDuration;
        float motionTimer = 0;
        Vector3 CurrentPos = transform.position;
        CurrentPos.x += Random.Range(XPosRandomLimit.x, XPosRandomLimit.y);
        transform.position = CurrentPos;

        //Do Y Motion
        while (motionTimer < MotionDuration)
        {
            CurrentPos = transform.position;
            CurrentPos.y += YSpeed * Time.deltaTime;
            transform.position = CurrentPos;

            motionTimer += Time.deltaTime;
            yield return null;
        }
        currentY += YIncrement;
        if (currentY >= YPosRandomLimit.y)
        {
            currentY = YPosRandomLimit.x;
        }

        float stoppingTimer = 0;
        while (stoppingTimer < StoppingDuration)
        {
            stoppingTimer += Time.deltaTime;
            yield return null;
        }

        //Initilize scaling and fading
        float randomFinalScale = Random.Range(ScalingRandomLimit.x, ScalingRandomLimit.y);
        float scalingTimer = 0;
        float scalingSpeed = randomFinalScale / ScalingDuration;
        Vector2 CurrentScale = transform.localScale;

        float fadingSpeed = 1 / FadingDuration;
        float fadingTimer = 0;
        Color CurrentColor = myTextUI.color;

        //Do Scaling and Fading
        while (fadingTimer < FadingDuration || scalingTimer < ScalingDuration)
        {
            if (scalingTimer < ScalingDuration)
            {
                CurrentScale = transform.localScale;
                CurrentScale.x += (scalingSpeed * Time.deltaTime);
                CurrentScale.y += (scalingSpeed * Time.deltaTime);
                scalingTimer += Time.deltaTime;
            }

            if (fadingTimer < FadingDuration)
            {
                CurrentColor = myTextUI.color;
                CurrentColor.a -= fadingSpeed * Time.deltaTime;
                myTextUI.color = CurrentColor;
                fadingTimer += Time.deltaTime;
            }


            yield return null;
        }

        Destroy(gameObject);
    }

}
