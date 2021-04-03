using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameMode : MonoBehaviour
{

    private GameObject textInfo;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject textInfo = GameObject.FindWithTag("TextInformation");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTextInfo(string msg)
    {
        //textInfo.GetComponent<Text>().text = msg;
    }
}
