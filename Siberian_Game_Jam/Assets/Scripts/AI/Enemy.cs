using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PawnBase
{

    public int damage = -1; // значние отрицательно т.к. метод, который считает HP добавляет отрицательное значение и уменьшает так хп
    public float attackCooldownTime = 2.0f;
    public GameObject EquippedWeapon;
    public Transform WeaponSokect;
    public States state;
    public EnemyTypes enemyType;
    public Transform target;
    Transform bodySprite;

    bool isAttackCooldown = false;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
      target = GameObject.FindWithTag("Player").transform;
      state = States.active;
      rb = GetComponent<Rigidbody2D> ();
      bodySprite = transform.Find("Body").transform;
    }

    // Update is called once per frame
    void Update()
    {
    //  Debug.Log($"RB Velocity {rb.velocity}");
      Rotation ();
      if(state != States.dead && enemyType == EnemyTypes.ranged)
      {
        rangedWeaponRotation();
      }
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
        //Debug.Log("Death");
        Death();
      }
    }

    public override void Death()
    {
      //Debug.Log("Enemy Death");
      gameObject.GetComponent<Collider2D> ().enabled = false;
      SetIsDead (true);
      state = States.dead;
      StartCoroutine(Disappear(3.0f));
    }

    public void Rotation (){

        //двигаемся вправо
      if (rb.velocity.x > 0.1f && rb.velocity.y < 0.5f && rb.velocity.y > -0.5 )
      {
        bodySprite.localScale = new Vector3(1f,1f,1f);
        Debug.Log("Enemy Move right");
      }
      // движение влево
      else if(rb.velocity.x < -0.1f && rb.velocity.y < 0.5f && rb.velocity.y > -0.5 ){
        bodySprite.localScale = new Vector3(-1f,1f,1f);
        Debug.Log("Enemy Move left");
      }
      // движение вверх
      else if (rb.velocity.y > 0.1f && rb.velocity.x < 0.5f && rb.velocity.x > -0.5 )
      {
          Debug.Log("Enemy Move up");
      }
      // движение вниз
      else if (rb.velocity.y < -0.1f && rb.velocity.x < 0.5f && rb.velocity.x > -0.5 )
      {
          Debug.Log("Enemy Move down");
      }
      // движение влево вверх
      else if (rb.velocity.x < -0.5f && rb.velocity.y > 0.5f)
      {
          Debug.Log("Enemy Move left up");
      }
      // движение вправо вверх
      else if (rb.velocity.x > 0.5f && rb.velocity.y > 0.5f)
      {
          Debug.Log("Enemy Move right up");
      }
      // движение влево вниз
      else if (rb.velocity.x < -0.5f && rb.velocity.y < -0.5f)
      {
          Debug.Log("Enemy Move left down");
      }
      // движение вправо вниз
      else if (rb.velocity.x > 0.5f && rb.velocity.y < -0.5f)
      {
          Debug.Log("Enemy Move right down");
      }
    }

    void rangedWeaponRotation()
    {
      if(target != null){

        Vector2 lookDirection = new Vector2(target.position.x, target.position.y) - rb.position;
        float angle = Mathf.Atan2(lookDirection.y,lookDirection.x) * Mathf.Rad2Deg - 90f;
        //float angle = Mathf.Atan2(lookDirection.y,lookDirection.x) * Mathf.Rad2Deg;
        WeaponSokect.eulerAngles = new Vector3(0,0, angle);
        //Debug.Log($" lookat {WeaponSokect.rotation}");
      }
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

    void OnTriggerEnter2D(Collider2D other)
    {
    /*  if(other.gameObject.tag == "Player")

        if (other.gameObject.GetComponent<Player> () != null && !isAttackCooldown)
        {
          other.gameObject.GetComponent<Player> ().ChangeHP(damage);
          StartCoroutine(AttackCooldown(attackCooldownTime));
        }*/
      }


    public IEnumerator AttackCooldown(float waitTime)
    {
        isAttackCooldown = true;
        yield return new WaitForSeconds(waitTime);
        isAttackCooldown = false;
    }

    public IEnumerator Disappear(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}

public enum States
{
  passive,
  active,
  dead
}

public enum EnemyTypes
{
  ranged,
  melee
}
