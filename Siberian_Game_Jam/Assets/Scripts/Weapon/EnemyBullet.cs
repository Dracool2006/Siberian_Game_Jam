using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : BulletBase
{
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);

    }



}
