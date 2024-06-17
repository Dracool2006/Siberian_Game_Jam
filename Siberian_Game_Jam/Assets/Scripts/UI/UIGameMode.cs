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

    public Slider SoulSlider;
    public Slider HealSlider;



    public void SetHealSlider(int value){
        if(HealSlider)
        HealSlider.value = (float) value /100;
    }

    public void SetSoulSlider(int val){

        if(SoulSlider)
            SoulSlider.value = (float) val /100;
        if(SoulText)
            SoulText.text = val.ToString();

      if (machineGunSoulsDemand < val)
      {
            if (M1Img)
                M1Img.color = new Color(1, 1, 1);
      }
      else
      {
            if (M1Img)
                M1Img.color = new Color(0, 0, 0);
      }

      if (healSoulsDemand < val)
      {
            if (M2Img)
                M2Img.color = new Color(1, 1, 1);
      }
      else
      {
            if (M2Img)
                M2Img.color = new Color(0, 0, 0);
      }

      if (shootGunSoulsDemand < val)
      {
            if (M3Img)
                M3Img.color = new Color(1, 1, 1);
      }
      else
      {
            if (M3Img)
                M3Img.color = new Color(0, 0, 0);
      }


    }

    public void ShowBullet(int bullet, int maxBullet)
    {
        if (BulletText)
        {
            BulletText.text = bullet.ToString() + "/" + maxBullet.ToString();
        }
       
    }

    public void ShowSoulLevel(int val)
    {
        if (machineGunSoulsDemand < val)
        {
            if(M1Img)
                M1Img.color = new Color(1, 1, 1);
        }
        else
        {
            if (M1Img)
                M1Img.color = new Color(0, 0, 0);
        }

        if (healSoulsDemand < val)
        {
            if (M2Img)
                M2Img.color = new Color(1, 1, 1);
        }
        else
        {
            if (M2Img)
                M2Img.color = new Color(0, 0, 0);
        }

        if (shootGunSoulsDemand < val)
        {
            if (M3Img)
                M3Img.color = new Color(1, 1, 1);
        }
        else
        {
            if (M3Img)
                M3Img.color = new Color(0, 0, 0);
        }

        if (SoulScale)
            SoulScale.transform.position = new Vector3(0, val - 100, 0);
        if (SoulText)
            SoulText.text = val.ToString();
    }

    public void ShowHealPointLevel(int val)
    {
        if(HealPointScale)
            HealPointScale.transform.position = new Vector3(0, val * 3.5f - 350, 0);
    }


}
