using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public GameObject equippedweapon;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
      player = GetComponent<Player>();
      ChangeWeaponMode(1);
    }

    // Update is called once per frame
    void Update()
    {
      if(!(player.GetIsDead()))
      {
        InputActions();
      }



    }
    void FixedUpdate()
    {

    }

    void InputActions()
    {
      if(Input.GetButton("Fire1"))
      {
          Attack();
      }


      if(Input.GetButtonDown("Submit"))
      {

      }

      if(Input.GetButtonDown("Ability1"))
      {
        ChangeWeaponMode(1);
      }

      if(Input.GetButtonDown("Ability2"))
      {
        ChangeWeaponMode(2);
      }

      if(Input.GetButtonDown("Ability3"))
      {
        ChangeWeaponMode(3);
      }

    }


    void ChangeWeaponMode(int modeNumber)
    {
      equippedweapon.GetComponent<Gun>().SetWeaponMode(modeNumber);
    }

    void Attack()
    {
        if(equippedweapon){
            Debug.Log("Attack");
            equippedweapon.GetComponent<Gun>().Shoot();
        }
    }

    void RescaleBullet(int buller, int maxBullet)
    {
        GetComponent<Player>().UI.GetComponent<UIGameMode>().ShowBullet(buller, maxBullet); //��������� �������
    }

}
