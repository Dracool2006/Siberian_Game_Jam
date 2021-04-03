using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    public int damage = 2;
    public Transform barrel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 trajectory = mousePos - rb.position;
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

      if(other.gameObject.tag == "Enemy"){
            Destroy(gameObject);
            if (other.gameObject.GetComponent<Enemy> () != null)
            {
              other.gameObject.GetComponent<Enemy> ().ChangeHP(damage);
            }
      }
      if(other.gameObject.tag == "World"){
            Destroy(gameObject);
      }
    }


}
