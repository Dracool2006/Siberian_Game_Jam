using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppeteerSpawn : MonoBehaviour
{

    private List<Transform> AllSpawn = new List<Transform>();
    public GameObject AllEnemys;
    private float SpawnTimer = 10;
    private int ProgressLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in GetComponentInChildren<Transform>())
        {
            AllSpawn.Add(child);
        }
    }

    public void SetProgress(int progress)
    {
        ProgressLevel = progress;
    }

    // Update is called once per frame
    void Update()
    {
        float dTime = Time.deltaTime;

        if(SpawnTimer > 0)
        {
            SpawnTimer -= dTime;
        }
        else
        {
            SpawnTimer = 1;
            int spawnNumber = Mathf.FloorToInt(UnityEngine.Random.Range(0, AllSpawn.Count));
            AllEnemys.GetComponent<PuppeteerEnemys>().SpawnEnemy(ProgressLevel, AllSpawn[spawnNumber].position);
        }


    }
}
