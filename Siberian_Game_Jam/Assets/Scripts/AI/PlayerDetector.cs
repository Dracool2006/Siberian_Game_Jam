using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
  public float rayLenght = 1.0f;
  public Transform playerDetect;
  public Transform target;
  public Enemy enemy;
  bool playerisFound;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();

    }

    void DetectPlayer() {
      Vector2 lookDirection = new Vector2(target.position.x, target.position.y) - new Vector2(transform.position.x, transform.position.y);

      RaycastHit2D PlayerInfo = Physics2D.Raycast(playerDetect.position, lookDirection, rayLenght);

      if(PlayerInfo.collider != null){
        //Debug.Log(PlayerInfo.collider.gameObject.tag);

        if(PlayerInfo.collider.gameObject.tag == "Player" )
        {
            playerisFound = true;
        }
        else
            playerisFound = false;
        }
      else
        playerisFound = false;
    }


    public bool GetPlayerisFound()
    {
      return playerisFound;
    }


}
