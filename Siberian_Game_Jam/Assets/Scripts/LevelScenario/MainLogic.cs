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

    // Start is called before the first frame update
    void Start()
    {
        
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
        AllSpawn.GetComponent<PuppeteerSpawn>().SetProgress(ProgressLevel);
    }
}
