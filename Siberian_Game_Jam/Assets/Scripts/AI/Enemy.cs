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
    public PlayerDetector playerDetector;
    public Animator anim;

    private Transform target;
    private Transform bodySprite;
    protected bool isAttackCooldown = false;
     Rigidbody2D rb;




    // Start is called before the first frame update
    void Start()
    {
      target = GameObject.FindWithTag("Player").transform;
      state = States.lookingfor;
      rb = GetComponent<Rigidbody2D> ();
      bodySprite = transform.Find("Body").transform;
      anim = GetComponent <Animator> ();
      //playerDetector = transform.Find("PlayerDetector").GetComponent<PlayerDetector>();
      target = GameObject.FindWithTag("Player").transform;

    }


    // Update is called once per frame
    public virtual void Update()
    {
      // проверяем, что ИИ не мертв
      if(state != States.dead)
      {

        Rotation ();
        rangedWeaponRotation();

      //  Debug.Log($" isAttackCooldown {isAttackCooldown}");
      //  Debug.Log($" player is found {playerDetector.GetPlayerisFound()}");

        // проверяем, что сейчас не кулдаун атаки и игрок в зоне досягаемсоти
        if(!isAttackCooldown && playerDetector.GetPlayerisFound())
        {
          //Debug.Log($" player is found {playerDetector.GetPlayerisFound()}");
          AttackStart();
        }
      }
    }

    public override void Movement(Vector2 direction, float speed)
    {
      rb.AddForce(direction * speed * Time.fixedDeltaTime);
    }

    // метод изменения количества HP
    public override void ChangeHP(int deltaHP)
    {
      SetCurrentHP(GetCurrentHP() + deltaHP);
      Debug.Log(GetCurrentHP());

      if(GetCurrentHP() <= 0 ){
        //Debug.Log("Death");
        Death();
      }
    }

    // метод смерти
    public override void Death()
    {
      //Debug.Log("Enemy Death");
      gameObject.GetComponent<Collider2D> ().enabled = false;
      SetIsDead (true);
      state = States.dead;
      StartCoroutine(Disappear(3.0f));
    }

    // метод, отвечающий за логику поворота врагов
    public void Rotation (){

      if (rb.velocity.x < 0.1f && rb.velocity.y < 0.1f && rb.velocity.x > -0.1f && rb.velocity.y > -0.1f)
      {
        anim.SetBool("MoveRight", false);
        anim.SetBool("MoveDown", false);
        anim.SetBool("MoveDown", false);
      }
        //двигаемся вправо
      if (rb.velocity.x > 0.1f && rb.velocity.y < 0.5f && rb.velocity.y > -0.5 )
      {
        anim.SetBool("MoveRight", true);
        anim.SetBool("MoveDown", false);
        anim.SetBool("MoveDown", false);
        bodySprite.localScale = new Vector3(3f,3f,3f);
        Debug.Log("Enemy Move right");
      }
      // движение влево
      else if(rb.velocity.x < -0.1f && rb.velocity.y < 0.5f && rb.velocity.y > -0.5 ){
        anim.SetBool("MoveRight", true);
        anim.SetBool("MoveUp", false);
        anim.SetBool("MoveDown", false);
        bodySprite.localScale = new Vector3(-3f,3f,3f);
        Debug.Log("Enemy Move left");
      }
      // движение вверх
      else if (rb.velocity.y > 0.1f && rb.velocity.x < 0.5f && rb.velocity.x > -0.5 )
      {
        anim.SetBool("MoveUp", true);
        anim.SetBool("MoveRight", false);
        anim.SetBool("MoveDown", false);
          Debug.Log("Enemy Move up");
      }
      // движение вниз
      else if (rb.velocity.y < -0.1f && rb.velocity.x < 0.5f && rb.velocity.x > -0.5 )
      {
        anim.SetBool("MoveDown", true);
        anim.SetBool("MoveUp", false);
        anim.SetBool("MoveRight", false);
          Debug.Log("Enemy Move down");
      }
      // движение влево вверх
      else if (rb.velocity.x < -0.5f && rb.velocity.y > 0.5f)
      {
        anim.SetBool("MoveRight", true);
        anim.SetBool("MoveUp", false);
        anim.SetBool("MoveDown", false);
        Debug.Log("Enemy Move left up");
      }
      // движение вправо вверх
      else if (rb.velocity.x > 0.5f && rb.velocity.y > 0.5f)
      {
        anim.SetBool("MoveRight", true);
        anim.SetBool("MoveDown", false);
        anim.SetBool("MoveDown", false);
        Debug.Log("Enemy Move right up");
      }
      // движение влево вниз
      else if (rb.velocity.x < -0.5f && rb.velocity.y < -0.5f)
      {
        anim.SetBool("MoveRight", true);
        anim.SetBool("MoveUp", false);
        anim.SetBool("MoveDown", false);
        Debug.Log("Enemy Move left down");
      }
      // движение вправо вниз
      else if (rb.velocity.x > 0.5f && rb.velocity.y < -0.5f)
      {
        anim.SetBool("MoveRight", true);
        anim.SetBool("MoveDown", false);
        anim.SetBool("MoveDown", false);
        Debug.Log("Enemy Move right down");
      }
    }


    public virtual void AttackStart(){

      /*  state = States.attackig;
        anim.SetTrigger("Attack");
        StartCoroutine(AttackCooldown(attackCooldownTime));*/
    }

    public virtual void AttackEnd(){

    }

    // петод разворачивающий оружие в сторону игрока
    void rangedWeaponRotation()
    {
      if(target != null){
        //Debug.Log("rangedWeaponRotation");
        Vector2 lookDirection = new Vector2(target.position.x, target.position.y) - rb.position;
        float angle = Mathf.Atan2(lookDirection.y,lookDirection.x) * Mathf.Rad2Deg - 90f;
        //float angle = Mathf.Atan2(lookDirection.y,lookDirection.x) * Mathf.Rad2Deg;
        WeaponSokect.eulerAngles = new Vector3(0,0, angle);
        //Debug.Log($" lookat {WeaponSokect.rotation}");
      }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
          /*if(other.gameObject.tag == "Player")

          if (other.gameObject.GetComponent<Player> () != null && !isAttackCooldown)
          {
            other.gameObject.GetComponent<Player> ().ChangeHP(damage);
            StartCoroutine(AttackCooldown(attackCooldownTime));
          }*/
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

/*
    void Animation(){
      anim.SetTrigger("Attack");
    }*/
    // кулдаун атаки
    public IEnumerator AttackCooldown(float waitTime)
    {
        isAttackCooldown = true;
        yield return new WaitForSeconds(waitTime);
        isAttackCooldown = false;
        state = States.attackig;

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
  lookingfor,
  attackig,
  dead
}

public enum EnemyTypes
{
  ranged,
  melee
}
