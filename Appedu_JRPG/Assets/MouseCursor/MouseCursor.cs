using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    #region 滑鼠鼠標
    public static MouseCursor instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    [SerializeField] GameObject MouseTrailObj;
    private float StartMT = 0.15f;
    private float EndMT;
    private float trailTime;
    Transform trailTransform;
    // Start is called before the first frame update
    void Start()
    {
        MouseTrail();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MouseTrail() //創造滑鼠軌跡線
    {
        //    MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>(); //找尋物件("物件名稱").拿到元件("元件名稱");


        trailTransform = MouseTrailObj.transform;
        TrailRenderer trail = MouseTrailObj.AddComponent<TrailRenderer>();
        trail.time = -1;
        trail.time = trailTime;

        trail.startWidth = StartMT * 0.1f;   //Trail開始
        trail.endWidth = EndMT * 0.1f;     //Trail結束
        trail.numCapVertices = 1;
        trail.material = new Material(Shader.Find("Sprites/Default"));  //Trail建立新的材質
        float alpha = 1f;  //透明度
        Gradient trailGradient = new Gradient();  //設置新的漸層
        trailGradient.SetKeys(new GradientColorKey[] { new GradientColorKey(new Color(110 / 255f, 210 / 255f, 255 / 255f), 0f), new GradientColorKey(new Color(180 / 255f, 100 / 255f, 255 / 255f), 1f) }
        , new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.75f), new GradientAlphaKey(alpha, 0.5f) });  //設置 顏色A與顏色B
        trail.colorGradient = trailGradient; //將轉好的顏色 放到Trail上

    }
}
