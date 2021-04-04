using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PawnBase
{

    public Camera cam;
    //private variables
    private Rigidbody2D rb;
    private Vector2 mousePos;
    public Transform WeaponSoket;

    public GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        RescaleHealPoint();
        RescaleSoul();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement();
        if(cam != null)
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    void FixedUpdate()
    {
        Movement(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")), maxSpeed);

        Rotation();
    }

    public override void Movement(Vector2 direction, float speed)
    {

        rb.AddForce(direction * speed * Time.fixedDeltaTime);

    }

    void RescaleHealPoint()
    {
        UI.GetComponent<UIGameMode>().ShowHealPointLevel(GetCurrentHP());
    }

    void RescaleSoul()
    {
        UI.GetComponent<UIGameMode>().ShowSoulLevel(GetSoul());
    }

    void Rotation()
    {

        if(mousePos != null)
        {
            Vector2 lookDirection = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDirection.y,lookDirection.x) * Mathf.Rad2Deg - 90f;
            //float angle = Mathf.Atan2(lookDirection.y,lookDirection.x) * Mathf.Rad2Deg;
            WeaponSoket.eulerAngles = new Vector3(0,0, angle);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pickup")
        {
            if (col.gameObject.GetComponent<Soul>().NamePickup == "Soul")
            {
                if (AddSoul())
                {
                    Destroy(col.gameObject);
                    RescaleSoul();
                }
            }
        }
    }
}
