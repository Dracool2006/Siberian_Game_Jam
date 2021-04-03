using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject player;
    public Vector2 offset = new Vector2(1f, 1f);
    public float damping = 1f;

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

    float Angle()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = mousePos - (Vector2)player.transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        return angle;
    }

    Vector2 SideOfMovement(float angle)
    {
        //Vector2(x, y)
        if (angle > -20 && angle < 20)
        {
            return new Vector2(0, 1);
        }
        else if (angle > -65 && angle < 25)
        {
            return new Vector2(1, 1);
        }
        else if (angle > -110 && angle < -70)
        {
            return new Vector2(1, 0);
        }
        else if (angle > -155 && angle < -115)
        {
            return new Vector2(1, -1);
        }
        else if (angle > -200 && angle < -160)
        {
            return new Vector2(0, -1);
        }
        else if (angle > -245 && angle < -205)
        {
            return new Vector2(-1, -1);
        }
        else if ((angle > -270 && angle < -250) || (angle > 70 && angle < 90))
        {
            return new Vector2(-1, 0);
        }
        else if (angle > 25 && angle < 65)
        {
            return new Vector2(-1, 1);
        }

        return new Vector2(0, 0);
    }

    void FollowCamera()
    {
        Vector3 cameraPosition = transform.position;
        Vector3 playerPosition = player.transform.position;

        if(player)
        {
            
            Vector2 sideOfMove = SideOfMovement(Angle());
            Vector3 target;
            if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
                target = new Vector3(player.transform.position.x + sideOfMove.x * offset.x, player.transform.position.y + sideOfMove.y * offset.y, transform.position.z);
                Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
                transform.position = currentPosition;
            }
        }
    }
}
    

