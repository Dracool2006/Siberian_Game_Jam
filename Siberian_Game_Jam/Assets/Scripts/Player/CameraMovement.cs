using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
      FollowCamera();
    }

    void FollowCamera()
    {
      if(Player != null){
      transform.position = new Vector3(Player.transform.position.x,
      Player.transform.position.y, transform.position.z);
      }
    }
}
