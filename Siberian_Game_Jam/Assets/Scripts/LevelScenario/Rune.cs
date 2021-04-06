using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour
{
    float Delay;
    Color runeColor, unseenColor;
 

 
    void Start()
    {
        runeColor = GetComponent<SpriteRenderer>().color;
        unseenColor = new Color(runeColor.r, runeColor.g, runeColor.b, 0.000f);
        GetComponent<SpriteRenderer>().color = unseenColor ;
    }

    void Update()
    {
            
            Delay += Time.deltaTime;
            
       
    }
}
