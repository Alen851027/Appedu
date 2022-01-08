using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollItemManager : MonoBehaviour
{
    //Manages clicking on a button in the themes list

    [HideInInspector]
    public int myNumberIndex;

    static NumberUIManager AccNUIM;

    private void Start()
    {
        if (AccNUIM == null)
        {
            AccNUIM = GameObject.Find("NumberUIManager").GetComponent<NumberUIManager>();
        }
    }


    public void OnClickOnNumberButton()
    {
        AccNUIM.ChangeNumberTheme(myNumberIndex);
    }
}
