using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseCursor : MonoBehaviour
{
    #region �ƹ�����
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
    void MouseTrail() //�гy�ƹ��y��u
    {
        //    MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>(); //��M����("����W��").���줸��("����W��");


        trailTransform = MouseTrailObj.transform;
        TrailRenderer trail = MouseTrailObj.AddComponent<TrailRenderer>();
        trail.time = -1;
        trail.time = trailTime;

        trail.startWidth = StartMT * 0.1f;   //Trail�}�l
        trail.endWidth = EndMT * 0.1f;     //Trail����
        trail.numCapVertices = 1;
        trail.material = new Material(Shader.Find("Sprites/Default"));  //Trail�إ߷s������
        float alpha = 1f;  //�z����
        Gradient trailGradient = new Gradient();  //�]�m�s�����h
        trailGradient.SetKeys(new GradientColorKey[] { new GradientColorKey(new Color(110 / 255f, 210 / 255f, 255 / 255f), 0f), new GradientColorKey(new Color(180 / 255f, 100 / 255f, 255 / 255f), 1f) }
        , new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.75f), new GradientAlphaKey(alpha, 0.5f) });  //�]�m �C��A�P�C��B
        trail.colorGradient = trailGradient; //�N��n���C�� ���Trail�W

    }
    public void MouseTrailToCursor(Vector3 screenPosition)
    {
        trailTransform.position = MainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, distanceFromCamera)); //�y���ഫ
        //����y�� = �۾�.�ù���@�ɮy��;
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
