using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    // Start is called before the first frame update
    public float scrollSpeed;
    Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0,scrollSpeed*Time.deltaTime,0,Space.World);
        float offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(offset, offset*0.1f);
    }
}
