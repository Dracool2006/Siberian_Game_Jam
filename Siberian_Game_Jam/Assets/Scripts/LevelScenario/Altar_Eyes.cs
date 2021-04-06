using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar_Eyes : MonoBehaviour
{
    // Start is called before the first frame update
    public bool player_in_col=false;
    Color runeColor, ignitedColor;
    //public Altar_Eyes ignite_eyes;


    public void ignite_eyes ()
    {
        //Debug.Log(player_in_col);
        //if (player_in_col)
        //{
            runeColor = GetComponent<SpriteRenderer>().color;
            ignitedColor = new Color(runeColor.r, runeColor.g, runeColor.b, 255.000f);
            GetComponent<SpriteRenderer>().color = ignitedColor;
        //}
    }

    public void fade_eyes()
    {
        //Debug.Log(player_in_col);
        //if (player_in_col)
        //{
        runeColor = GetComponent<SpriteRenderer>().color;
        ignitedColor = new Color(runeColor.r, runeColor.g, runeColor.b, 0.000f);
        GetComponent<SpriteRenderer>().color = ignitedColor;
        //}
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
