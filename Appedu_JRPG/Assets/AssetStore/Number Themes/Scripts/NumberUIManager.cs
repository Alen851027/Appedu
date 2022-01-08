using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberUIManager : MonoBehaviour
{
    public TextMeshProUGUI outputText;
    public TextMeshProUGUI themeNameText;

    public Color selectedColor;
    public Color unSelectedColor;

    public GameObject itemPrefab;

    public List<TMP_SpriteAsset> NumberSpriteAssets = new List<TMP_SpriteAsset>();
    List<Image> itemsImages = new List<Image>();

    public Transform scrollContentsParent;

    [HideInInspector]
    public TMP_SpriteAsset CurrentChosenTheme;

    void Start()
    {
        //Initilize the lists and creates a gameobject for each theme in the asset

        for (int i = 0; i < NumberSpriteAssets.Count; i++)
        {
            addItemToList(i);
        }
        ChangeNumberTheme(0);
    }

    public void OnInputChange(string Value)
    {
        outputText.text = NumberConverter.ConvertNumberToString(int.Parse(Value));
    }

    //Creates and new gameobject and sets its text to the number 0
    void addItemToList(int numberIndex)
    {
        GameObject newNumber = Instantiate(itemPrefab, scrollContentsParent);
        newNumber.GetComponent<ScrollItemManager>().myNumberIndex = numberIndex;
        TextMeshProUGUI newNumberText = newNumber.transform.Find("numberText").GetComponent<TextMeshProUGUI>();
        itemsImages.Add(newNumber.GetComponent<Image>());
        newNumberText.spriteAsset = NumberSpriteAssets[numberIndex];
        newNumberText.text = "<sprite=0>";

    }


    //Changes the preview number theme
    public void ChangeNumberTheme(int newTheme)
    {
        for (int i = 0; i < itemsImages.Count; i++)
        {
            itemsImages[newTheme].color = unSelectedColor;
        }
        itemsImages[newTheme].color = selectedColor;
        outputText.spriteAsset = NumberSpriteAssets[newTheme];
        CurrentChosenTheme = NumberSpriteAssets[newTheme];
        themeNameText.text = "Theme Name: "+NumberSpriteAssets[newTheme].name;
    }



}
