using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TMPTextTest : MonoBehaviour
{
    public Button ChangeTextType;
    public int A;
    public TextMeshProUGUI text;
    public TMP_SpriteAsset x;
    // Start is called before the first frame update
    void Start()
    {
        //text = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        text.text = NumberConverter.ConvertNumberToString(A);
        ChangeTextType.onClick.AddListener(() =>ChangeTypeText());
    }

    void ChangeTypeText()
    {
        text.spriteAsset = x;
        Debug.Log("AAABBBCCC");

    }
}
