using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
  public float rayLenght = 1.0f;
  public Transform playerDetect;
  public Transform target;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
    }

    void DetectPlayer() {
<<<<<<< HEAD
      Vector2 lookDirection = new Vector2(target.position.x, target.position.y) - new Vector2(transform.position.x, transform.position.y);

<<<<<<< HEAD
      RaycastHit2D PlayerInfo = Physics2D.Raycast(playerDetect.position, lookDirection, rayLenght);

      if(PlayerInfo.collider != null){
<<<<<<< HEAD
        //Debug.Log(PlayerInfo.collider.gameObject.tag);
=======
      RaycastHit2D PlayerInfo = Physics2D.Raycast(playerDetect.position, lookDirection, rayLenght, layerMask);

    /*Debug.DrawRay(playerDetect.position, lookDirection * rayLenght, Color.red);
=======
        Vector2 lookDirection = new Vector2(target.position.x, target.position.y) - new Vector2(transform.position.x, transform.position.y);
>>>>>>> parent of f77f99e (Some AI fixes)

        RaycastHit2D PlayerInfo = Physics2D.Raycast(playerDetect.position, lookDirection, rayLenght);

<<<<<<< HEAD
      /*if(PlayerInfo.collider != null){

        Debug.DrawRay(playerDetect.position, lookDirection * rayLenght, Color.red);
>>>>>>> RedneckChan
=======
        Debug.Log(PlayerInfo.collider.gameObject.tag);
>>>>>>> parent of 91797b0 (Добавлены спавны)
=======
        Debug.Log(PlayerInfo.collider.gameObject.tag);
>>>>>>> parent of f77f99e (Some AI fixes)

        if(PlayerInfo.collider.gameObject.tag == "Player" )
        {
            Debug.Log("PlayerFound");
        }
    }
<<<<<<< HEAD

    void OnTriggerStay2D(Collider2D other)
    {
      if(other.gameObject.tag == "Player"){
        playerisFound = true;
      }

      if(other.gameObject.tag == "Enemy"){
        thereIsEnemyOnTheWay = true;
      }

    }

    void OnTriggerExit2D(Collider2D other)
    {
      if(other.gameObject.tag == "Player"){
        playerisFound = false;
      }
      if(other.gameObject.tag == "Enemy"){
        thereIsEnemyOnTheWay = false;
      }
    }

    public bool GetCanWeShoot()
    {
<<<<<<< HEAD
      return playerisFound;
=======
        return canWeShoot;
>>>>>>> RedneckChan
    }


=======
>>>>>>> parent of f77f99e (Some AI fixes)
}
