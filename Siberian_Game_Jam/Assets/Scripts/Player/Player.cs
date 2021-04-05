using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PawnBase
{
    #region Fields
    public Camera cam;
    public GameObject UI;
    public Transform WeaponSoket;
    public Animator playerAnimator;
    public int machineGunSoulsDemand = 25;
    public int shootGunSoulsDemand = 35;
    public int healSoulsDemand = 40;
    public int healCount = 5;
    public float healTime = 50;
    public GameMenu gameMenu;
    //private variables
    private Rigidbody2D rb;
    private Vector2 mousePos;
    #endregion

    private float SoulGivingTime = 0;
    public GameObject MainLogic;

    public AudioSource AudioSoul;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        RescaleHealPoint();
        RescaleSoul();

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
      if(!GetIsDead())
      {
        Movement(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")), maxSpeed);
        SetAnimatorKeys();
        Rotation(Angle());
      }

    }

    #region Methods
    public override void Movement(Vector2 direction, float speed)
    {

        rb.AddForce(direction * speed * Time.fixedDeltaTime);

    }

    public void RescaleHealPoint()
   {
      UI.GetComponent<UIGameMode>().ShowSoulLevel(GetSoul());
       UI.GetComponent<UIGameMode>().SetHealSlider(GetCurrentHP());
   }

   public void RescaleSoul()
   {
      UI.GetComponent<UIGameMode>().ShowHealPointLevel(GetCurrentHP());
       UI.GetComponent<UIGameMode>().SetSoulSlider(GetSoul());
   }



    void Rotation(float angle)
    {

            WeaponSoket.eulerAngles = new Vector3(0,0, angle);
    }

    float Angle()
    {
         Vector2 lookDirection = GetLookAtDirection();
         float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + 90f;
         return angle;
    }

    Vector2 GetLookAtDirection(){

      if(mousePos != null)
        return mousePos - rb.position;
      else
        return Vector2.zero;
    }

    void SetAnimatorKeys(){

      Vector2 lookDirection = GetLookAtDirection();

      if(lookDirection.normalized.y < 0.5f && lookDirection.normalized.y > -0.5f)
      {

        if (lookDirection.normalized.x < - 0.5f)
        {
          //Debug.Log("MoveLeft");
          playerAnimator.SetBool("MoveRight", false);
          playerAnimator.SetBool("MoveLeft", true);
          playerAnimator.SetBool("MoveTop", false);
          playerAnimator.SetBool("MoveBack", false);
          transform.localScale = new Vector3(-1.0f, transform.localScale.y, transform.localScale.y);
        }
        else if (lookDirection.normalized.x > 0.5f)
        {
          playerAnimator.SetBool("MoveRight", true);
          playerAnimator.SetBool("MoveLeft", false);
          playerAnimator.SetBool("MoveTop", false);
          playerAnimator.SetBool("MoveBack", false);
          transform.localScale = new Vector3(1.0f, transform.localScale.y, transform.localScale.y);
        }
      }
      else
      {
        if(lookDirection.normalized.y > 0.5f)
        {
          playerAnimator.SetBool("MoveBack", true);
            playerAnimator.SetBool("MoveLeft", false);
          playerAnimator.SetBool("MoveRight", false);
          playerAnimator.SetBool("MoveTop", false);
          transform.localScale = new Vector3(-1.0f, transform.localScale.y, transform.localScale.y);
        }
        else if(lookDirection.normalized.y < -0.5f)
        {
          playerAnimator.SetBool("MoveRight", false);
            playerAnimator.SetBool("MoveLeft", false);
          playerAnimator.SetBool("MoveTop", true);
          playerAnimator.SetBool("MoveBack", false);
          transform.localScale = new Vector3(-1.0f, transform.localScale.y, transform.localScale.y);
        }
      }

    }

    public override void ChangeHP(int deltaHP)
    {


        if (deltaHP < 0)
        {
            playerAnimator.SetTrigger("Damage");
        }
        SetCurrentHP(GetCurrentHP() + deltaHP);
        RescaleHealPoint();
        if(GetCurrentHP() <= 0 && gameObject.GetComponent<Collider2D>().enabled == true)
        {
            Death();
        }
    }

    public override void Death()
    {
        gameObject.GetComponent<Collider2D> ().enabled = false;
        SetIsDead (true);
        gameMenu.ActivatePostPortus();

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
                    AudioSoul.Play();
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Altar")
        {
            if(GetSoul() > 0)
            {
                SoulGivingTime -= Time.deltaTime;
                if (SoulGivingTime < 0)
                {
                    SoulGivingTime = 0.1f;
                    TakeAwaySoul();
                    RescaleSoul();
                    MainLogic.GetComponent<MainLogic>().AddSoul();
                }
            }
        }
    }
    #endregion
}
