using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PawnBase
{

    //public int damage = -1; // значние отрицательно т.к. метод, который считает HP добавляет отрицательное значение и уменьшает так хп
    public float attackCooldownTime = 2.0f;
    public GameObject EquippedWeapon;
    public Transform WeaponSokect;
    public States state;
    public EnemyTypes enemyType;
    public PlayerDetector playerDetector;
    public Animator enemyAnimator;
    public OtherEnemyDetector otherEnemyDetector;
    private Transform target;
    [SerializeField] protected Transform bodySprite;
    [SerializeField] protected Rigidbody2D rb;
    protected bool isAttackCooldown = false;

    Coroutine disableDaamgeSprite;

    public GameObject PrefabSoul;

    public AudioClip AudioDead;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        state = (state != States.passive) ? States.lookingfor : States.passive;
        rb = GetComponent<Rigidbody2D> ();
        enemyAnimator = GetComponent <Animator> ();

        target = GameObject.FindWithTag("Player").transform;

        if (enemyType == EnemyTypes.ranged)
          EquippedWeapon.GetComponent<Gun>().SetWeaponMode(1);
    }


    // Update is called once per frame
    public virtual void Update()
    {


      // проверяем, что ИИ не мертв
      if(state != States.dead && state != States.passive)
      {
        
            
            transform.position = new Vector3 (transform.position.x,  transform.position.y, transform.position.y * 0.01f);
        SetAnimatorKeys();

        rangedWeaponRotation();

        //Debug.Log($" isAttackCooldown {isAttackCooldown}");
        //Debug.Log($" can we shoot {playerDetector.GetCanWeShoot()}");
        //Debug.Log($" isAttackCooldown {isAttackCooldown}");
        //Debug.Log($" summt {!isAttackCooldown && playerDetector.GetCanWeShoot()}");

        if(!isAttackCooldown && playerDetector.GetCanWeShoot() && !GetIsDead())
        {
          //Debug.Log("EnemyAttack");
          //Debug.Log($" player is found {playerDetector.GetCanWeShoot()}");
          AttackStart();
          //Debug.Log("EnemyAttack");
        }

        else if(!isAttackCooldown && !playerDetector.GetCanWeShoot())
        {
          AttackEnd();
        }
      }


    }

    public override void Movement(Vector2 direction, float speed)
    {
        if (rb)
        {
            rb.AddForce(direction * speed * Time.fixedDeltaTime);
        }
    }

    // метод изменения количества HP
    public override void ChangeHP(int deltaHP)
    {

        if (deltaHP <0)
        {
            if(disableDaamgeSprite !=null)
                StopCoroutine(disableDaamgeSprite);

            //enemyAnimator.SetTrigger("Damage");
            damageSprite.SetActive(true);
            disableDaamgeSprite = StartCoroutine(DisableDamageSprite());
        }
        SetCurrentHP(GetCurrentHP() + deltaHP);
        //Debug.Log(GetCurrentHP());

        if(GetCurrentHP() <= 0 && gameObject.GetComponent<Collider2D>().enabled == true)
        {
        //Debug.Log("Death");
            //SetIsDead(true);
            Death();
        }
    }

    IEnumerator DisableDamageSprite()
    {
        yield return new WaitForSeconds(1);
        damageSprite.SetActive(false);

    }

    // метод смерти
    public override void Death()
    {
        SetIsDead(true);
        if (disableDaamgeSprite != null)
            StopCoroutine(disableDaamgeSprite);
        damageSprite.SetActive(false);



        if (AudioService.Instance && AudioDead)
        {
            AudioService.Instance.PlaySound(AudioDead);
        }
        state = States.dead;

        transform.position = new Vector3 (transform.position.x,  transform.position.y, transform.position.y * 0.01f + 5.0f);

        enemyAnimator.SetBool("Death", true);
        gameObject.GetComponent<Collider2D> ().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        
        EquippedWeapon.GetComponent<Gun>().StopAllCoroutines();
        StartCoroutine(Disappear(3.0f));
        SoulGenerate();
        GameObject.FindWithTag("MainCamera").GetComponent<MainLogic>().EnemyDead();
    }

    protected void SoulGenerate()
    {
        GameObject soul = Instantiate(PrefabSoul);
        soul.transform.position = transform.position;
    }

    void SetAnimatorKeys()
    {

        if (state == States.passive)
        {
            enemyAnimator.SetBool("Idle", true);
        }
        else
        {
            Vector2 lookDirection = GetLookAtDirection();

            Vector2 normalizedLookDirection = lookDirection.normalized;

            if (normalizedLookDirection.x > 0.5)
            {
                normalizedLookDirection.x = 1;
            }
            else if (normalizedLookDirection.x < -0.5)
            {
                normalizedLookDirection.x = -1;
            }
            else if (normalizedLookDirection.x > -0.5 && normalizedLookDirection.x < 0.5)
            {
                normalizedLookDirection.x = 0;
            }

            if (normalizedLookDirection.y > 0.5)
            {
                normalizedLookDirection.y = 1;
            }
            else if (normalizedLookDirection.y < -0.5)
            {
                normalizedLookDirection.y = -1;
            }
            else if (normalizedLookDirection.y > -0.5 && normalizedLookDirection.y < 0.5)
            {
                normalizedLookDirection.y = 0;
            }


            /*

            if (lookDirection.normalized.y < 0.5f && lookDirection.normalized.y > -0.5f)
            {

                if (lookDirection.normalized.x < -0.5f)
                {
                    //Debug.Log("MoveLeft");
                    enemyAnimator.SetBool("MoveRight", false);
                    enemyAnimator.SetBool("MoveLeft", true);
                    enemyAnimator.SetBool("MoveTop", false);
                    enemyAnimator.SetBool("MoveBack", false);
                    //  enemyAnimator.SetBool("Idle", false);
                    transform.localScale = new Vector3(0.5f, transform.localScale.y, transform.localScale.y);
                }
                else if (lookDirection.normalized.x > 0.5f)
                {
                    enemyAnimator.SetBool("MoveRight", true);
                    enemyAnimator.SetBool("MoveLeft", false);
                    enemyAnimator.SetBool("MoveTop", false);
                    enemyAnimator.SetBool("MoveBack", false);
                    //  enemyAnimator.SetBool("Idle", false);
                    transform.localScale = new Vector3(0.5f, transform.localScale.y, transform.localScale.y);
                }
            }
            else
            {
                if (lookDirection.normalized.y > 0.5f)
                {
                    enemyAnimator.SetBool("MoveBack", true);
                    enemyAnimator.SetBool("MoveLeft", false);
                    enemyAnimator.SetBool("MoveRight", false);
                    enemyAnimator.SetBool("MoveTop", false);
                    //  enemyAnimator.SetBool("Idle", false);
                    transform.localScale = new Vector3(0.5f, transform.localScale.y, transform.localScale.y);
                }
                else if (lookDirection.normalized.y < -0.5f)
                {
                    enemyAnimator.SetBool("MoveRight", false);
                    enemyAnimator.SetBool("MoveLeft", false);
                    enemyAnimator.SetBool("MoveTop", true);
                    enemyAnimator.SetBool("MoveBack", false);
                    //  enemyAnimator.SetBool("Idle", false);
                    transform.localScale = new Vector3(0.5f, transform.localScale.y, transform.localScale.y);
                }
            }
            enemyAnimator.SetBool("Idle", false);
        }*/

            enemyAnimator.SetFloat("Horizontal", normalizedLookDirection.x);
            enemyAnimator.SetFloat("Vertical", -normalizedLookDirection.y);
            enemyAnimator.SetBool("Idle", false);

        }
    }


    public virtual void AttackStart(){

    }

    public virtual void AttackEnd(){

    }

    // метод разворачивающий оружие в сторону игрока
    void rangedWeaponRotation()
    {

      if(target != null && !GetIsDead()){
        //Debug.Log("rangedWeaponRotation");
        Vector2 lookDirection = GetLookAtDirection();
        float angle = Mathf.Atan2(lookDirection.y,lookDirection.x) * Mathf.Rad2Deg - 90f;
        //float angle = Mathf.Atan2(lookDirection.y,lookDirection.x) * Mathf.Rad2Deg;
        WeaponSokect.eulerAngles = new Vector3(0,0, angle);
        //Debug.Log($" lookat {WeaponSokect.rotation}");
      }
    }

    Vector2 GetLookAtDirection(){

      if(target != null)
        return new Vector2(target.position.x, target.position.y) - rb.position;
      else
        return Vector2.zero;
    }

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
