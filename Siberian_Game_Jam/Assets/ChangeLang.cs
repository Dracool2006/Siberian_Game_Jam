using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLang : MonoBehaviour
{
    public void ChangeLanguage(string key)
    {
        YG.YandexGame.SwitchLanguage(key);
    }
}
