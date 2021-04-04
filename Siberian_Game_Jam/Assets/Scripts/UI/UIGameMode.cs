using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameMode : MonoBehaviour
{

    public GameObject SoulScale;
    public Text SoulText;
    public GameObject HealPointScale;
    public Text BulletText;

    public Image M1Img;
    public Image M2Img;
    public Image M3Img;

    public int machineGunSoulsDemand =  25;
    public int shootGunSoulsDemand = 35;
    public int healSoulsDemand = 40;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject textInfo = GameObject.FindWithTag("TextInformation");
    }

    // Update is called once per frame
    void Update()
    {
        ShowMagik(0);
    }

    public void ShowBullet(int bullet, int maxBullet)
    {
        BulletText.text = bullet.ToString() + "/" + maxBullet.ToString();
    }

    public void ShowSoulLevel(int val)
    {
        int vals = val;
        ShowMagik(vals);
        SoulScale.transform.position = new Vector3(0, -1 * vals, 0);
        SoulText.text = vals.ToString();
    }

    public void ShowHealPointLevel(int val)
    {
        HealPointScale.transform.position = new Vector3(0, -1 * val * 3.5f, 0);
    }

    public void ShowMagik(int soulVal)
    {
        //Debug.Log(machineGunSoulsDemand + " " + soulVal + " " + M1Img.color);
        if(machineGunSoulsDemand < soulVal)
        {
            M1Img.color = new Color(1, 1, 1);
        }
        else
        {
            M1Img.color = new Color(0, 0, 0);
        }

        if(healSoulsDemand < soulVal)
        {
            M2Img.color = new Color(1, 1, 1);
        }
        else
        {
            M2Img.color = new Color(0, 0, 0);
        }

        if(shootGunSoulsDemand < soulVal)
        {
            M3Img.color = new Color(1, 1, 1);
        }
        else
        {
            M3Img.color = new Color(0, 0, 0);
        }
    }
}
