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

    // Start is called before the first frame update
    void Start()
    {
        //GameObject textInfo = GameObject.FindWithTag("TextInformation");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowBullet(int bullet, int maxBullet)
    {
        BulletText.text = bullet.ToString() + "/" + maxBullet.ToString();
    }

    public void ShowSoulLevel(int val)
    {
        SoulText.text = val.ToString();
        SoulScale.transform.position = new Vector3(0, -val, 0);
    }

    public void ShowHealPointLevel(int val)
    {
        HealPointScale.transform.position = new Vector3(0, -val * 3.5f, 0);
    }
}
