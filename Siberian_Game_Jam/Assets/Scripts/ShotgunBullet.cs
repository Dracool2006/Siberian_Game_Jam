using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour {

    public float speed = 7f;
    private Rigidbody2D rb;
    public int damage = 3;
    public Transform barrel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 trajectory = mousePos - rb.position;
        trajectory.x += Random.Range(-0.7f, 0.7f);
        trajectory.y += Random.Range(-0.7f, 0.7f);
        rb.AddForce(trajectory * speed, ForceMode2D.Impulse);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            if (other.gameObject.GetComponent<Enemy>() != null)
            {
                other.gameObject.GetComponent<Enemy>().ChangeHP(damage);
            }
        }
        if (other.gameObject.tag == "World")
        {
            Destroy(gameObject);
        }
    }


}
