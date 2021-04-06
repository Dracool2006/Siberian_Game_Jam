using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour
{
    float Delay;
    Color runeColor, unseenColor, ignitedColor;
    float rune_trancparency = 0.0f;

 
    void Start()
    {
        runeColor = GetComponent<SpriteRenderer>().color;
        unseenColor = new Color(runeColor.r, runeColor.g, runeColor.b, 0.000f);
        GetComponent<SpriteRenderer>().color = unseenColor ;


    }
    void Ignite_Altar_Rune()
    {
        while (rune_trancparency < 1.0f)
        {
            runeColor = GetComponent<SpriteRenderer>().color;
            ignitedColor = new Color(runeColor.r, runeColor.g, runeColor.b, rune_trancparency);
            rune_trancparency += 0.0000001f;
            GetComponent<SpriteRenderer>().color = ignitedColor;
            //yield return null;
        }
    }
       
    
}
