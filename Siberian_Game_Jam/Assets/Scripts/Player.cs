using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PawnBase
{
    #region Fields
    public int Souls = 0;
    public Camera cam;
    //private variables
    private Rigidbody2D rb;
    private Vector2 mousePos;
    public Transform WeaponSoket;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    #region Body
    // Update is called once per frame
    void Update()
    {
        if(cam != null)
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
    }
    #endregion

    void FixedUpdate()
    {
        Movement(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")), maxSpeed);

        Rotation(Angle());

    }

    #region Methods
    public override void Movement(Vector2 direction, float speed)
    {

        Vector3 currentPos = transform.position;
        currentPos.x += direction.x * speed * Time.fixedDeltaTime;
        currentPos.y += direction.y * speed * Time.fixedDeltaTime;
        transform.position = currentPos;
    }
    

    float Angle()
    {
         Vector2 lookDirection = mousePos - rb.position;
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

    void Rotation(float angle){

        WeaponSoket.eulerAngles = new Vector3(0,0, angle + 90);
    }
    #endregion

}
