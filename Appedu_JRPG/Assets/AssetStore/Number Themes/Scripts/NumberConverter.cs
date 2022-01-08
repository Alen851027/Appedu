using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

class NumberConverter : MonoBehaviour
{
    //This function converts an int to the string that you can put in TextMeshPro to show the number as the current theme
    public static string ConvertNumberToString(int num)
    {
        string toReturn = "";
        //Splits each number into separate digits
        string[] splitDigits = num.ToString().Select(q => new string(q, 1)).ToArray();
        for (int i = 0; i < splitDigits.Length; i++)
        {
            if (splitDigits[i] == "-" || splitDigits[i] == "+")
                continue;

            //for each digit, add the tag "<sprite=DIGIT>" (DIGIT here is the seprated numbers from the input num) them this is used in TextMeshPro to show the themed number
            toReturn += "<sprite="+splitDigits[i]+">";
        }

        return toReturn;

    }

}
