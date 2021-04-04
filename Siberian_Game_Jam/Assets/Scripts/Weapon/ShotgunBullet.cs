using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour {

/*
*
*
*
*

* Вся логика дублирована в BulletBase
* При необходимости вернусь к этому классу

*
*
*
*/



    public float speed = 7f;
    private Rigidbody2D rb;
    public int damage = 3;
    public Transform barrel;
    public float spreading = 0.7f;
    public bool isThisEnemybullet = false; // если false, то пуля может дамажит врагов, если true, то только игрока


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 trajectory = mousePos - rb.position;
        trajectory.x += Random.Range(-spreading, spreading);
        trajectory.y += Random.Range(-spreading, spreading);
        rb.AddForce(trajectory.normalized * speed, ForceMode2D.Impulse);

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

        if (other.gameObject.tag == "Enemy" && !isThisEnemybullet)
        {
            Destroy(gameObject);
            if (other.gameObject.GetComponent<Enemy>() != null)
            {
                other.gameObject.GetComponent<Enemy>().ChangeHP(damage);
            }
        }

        if (other.gameObject.tag == "Player" && isThisEnemybullet)
        {
            Destroy(gameObject);
            if (other.gameObject.GetComponent<Player>() != null)
            {
                other.gameObject.GetComponent<Player>().ChangeHP(damage);
            }
        }

        if (other.gameObject.tag == "World")
        {
            Destroy(gameObject);
        }
    }


}
