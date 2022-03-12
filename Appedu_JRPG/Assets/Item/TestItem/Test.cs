using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public List<ScritableObjectItemBox> itemBox;
    public ScritableObjectItemBox item;
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < itemBox.Count; i++)
        {
            for (int j = 0; j < itemBox[i].items.Count; j++)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    Debug.Log(itemBox[i].items[j].ItemID);

                }
            }
        }

        //-----------------------------------------------------

        for (int x = 0; x < item.items.Count; x++)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log(item.items[x].ItemName);
            }
        }
    }
}
