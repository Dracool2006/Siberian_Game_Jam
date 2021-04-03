using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject player;
    public Vector2 offset = new Vector2(1f, 1f);
    public float damping = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
          FollowCamera();
    }

    

    void FollowCamera()
    {
        Vector3 cameraPosition = transform.position;
        Vector3 playerPosition = player.transform.position;
        Vector2 topRightCorner = new Vector2(9f / 2 + cameraPosition.x, 5f / 2 + cameraPosition.y);
        Vector2 downLeftCorner = new Vector2(cameraPosition.x - 9f / 2, cameraPosition.y - 5f / 2);
        print(topRightCorner);
        print(downLeftCorner);
        if (player)
        {
            if(playerPosition.x > topRightCorner.x)
            {
                cameraPosition.x += offset.x;
            }
            if (playerPosition.y > topRightCorner.y)
            {
                cameraPosition.y += offset.y;
            }
            if (playerPosition.x < downLeftCorner.x)
            {
                cameraPosition.x -= offset.x;
            }
            if (playerPosition.y < downLeftCorner.y)
            {
                cameraPosition.y -= offset.y;
            }

            cameraPosition = Vector3.Lerp(transform.position, cameraPosition, damping * Time.deltaTime);
            transform.position = cameraPosition;
            /*Vector2 sideOfMove = SideOfMovement(Angle());
            Vector3 target;
            if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
                target = new Vector3(player.transform.position.x + sideOfMove.x * offset.x, player.transform.position.y + sideOfMove.y * offset.y, transform.position.z);
                Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
                transform.position = currentPosition;
            }*/
        }
    }
}
    

