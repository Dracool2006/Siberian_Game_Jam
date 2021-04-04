using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainLogic : MonoBehaviour
{
    public GameObject AllSpawn;
    public GameObject AllEnemy;
    public GameObject Player;
    public int ProgressLevel = 0;
    public int EnemyKill = 0;
    public GameObject Rain;
    public GameObject Water;

    public TMP_Text TextPrigress;

    // Start is called before the first frame update
    void Start()
    {
        RefrashProgressLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyDead()
    {
        EnemyKill++;
        AllEnemy.GetComponent<PuppeteerEnemys>().FirstAttack();
    }

    void RefrashProgressLevel()
    {
        Rain.GetComponent<Rain>().SetRain(ProgressLevel);
        Water.GetComponent<Water>().SetProgress(ProgressLevel);
        TextPrigress.text = ProgressLevel.ToString();
        AllSpawn.GetComponent<PuppeteerSpawn>().SetProgress(ProgressLevel);
    }

    public void AddSoul()
    {
        if(ProgressLevel < 500)
        {
            ProgressLevel++;
        }
        else
        {
            StartCoroutine(LoadYourAsyncScene());
        }
        RefrashProgressLevel();
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Final");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
