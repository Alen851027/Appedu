using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueTest : MonoBehaviour
{
    public int A;

    [SerializeField]
    private GameObject Value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            A += 1;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            A -= 1;
        }
        if (A >0)
        {
            Value.SetActive(true);
        }
        else
        {
            Value.SetActive(false);
        }
    }
}
