using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PawnBase
{


    public int damage = -1; // значние отрицательно т.к. метод, который считает HP добавляет отрицательное значение и уменьшает так хп
    public float attackCooldownTime = 2.0f;
    bool isAttackCooldown = false;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D> ();

    }

    // Update is called once per frame
    void Update()
    {


    }

    public override void Movement(Vector2 direction, float speed)
    {


      rb.AddForce(direction * speed * Time.fixedDeltaTime);

    }



    public override void ChangeHP(int deltaHP)
    {

      SetCurrentHP(GetCurrentHP() + deltaHP);
      Debug.Log(GetCurrentHP());

      if(GetCurrentHP() <= 0 ){
        Debug.Log("Death");
        Death();
      }
    }

    public override void Death()
    {
      Debug.Log("Enemy Death");
      gameObject.GetComponent<Collider2D> ().enabled = false;
      SetIsDead (true);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")

          if (other.gameObject.GetComponent<Player> () != null && !isAttackCooldown)
          {
            other.gameObject.GetComponent<Player> ().ChangeHP(damage);
            StartCoroutine(AttackCooldown(attackCooldownTime));
          }
    }

    public IEnumerator AttackCooldown(float waitTime)
    {
        isAttackCooldown = true;
        yield return new WaitForSeconds(waitTime);
        isAttackCooldown = false;
    }




}
