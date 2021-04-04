using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLogic : MonoBehaviour
{
    public GameObject AllSpawn;
    public GameObject AllEnemy;
    public GameObject Player;
    private int ProgressLevel = 0;
    public int EnemyKill = 0;
    public GameObject Rain;
    public GameObject Water;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReScaleProgress(int progress)
    {
        ProgressLevel = progress;
        Rain.GetComponent<Rain>().SetRain(ProgressLevel);
        Water.GetComponent<Water>().SetProgress(ProgressLevel);
    }

    public void EnemyDead()
    {
        EnemyKill++;
        AllEnemy.GetComponent<PuppeteerEnemys>().FirstAttack();
    }

    void RefrashProgressLevel()
    {
        AllSpawn.GetComponent<PuppeteerSpawn>().SetProgress(ProgressLevel);
    }
}
