using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] List<Sprite> MouseIcon;
    [SerializeField] Camera MainCamera;
    private float distanceFromCamera = 1;
    private float StartMT = 0.15f;
    private float EndMT;
    private float trailTime=0.15f;

    Transform trailTransform;
    // Start is called before the first frame update
    void Start()
    {
        MouseTrail();   
    }

    // Update is called once per frame
    void Update()
    {


        if (PlayerContorl.instance.isWalk == false)
        { 
            //MouseTrailToCursor(Input.mousePosition);

        }
        ChangeMouseIcon();
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
    public void MouseTrailToCursor(Vector3 screenPosition)
    {
        trailTransform.position = MainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, distanceFromCamera)); //座標轉換
        //物件座標 = 相機.螢幕到世界座標;
    }
    public void ChangeMouseIcon() 
    {
        if (Input.GetMouseButton(0))
        {
            Cursor.SetCursor(MouseIcon[0].texture, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(MouseIcon[1].texture, Vector2.zero, CursorMode.Auto);
        }
    }
}
