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
        if(!(player.NotLimitSoul()))
        {
          ChangeWeaponMode(2);
          player.SetSouls(player.GetSoul() - player.machineGunSoulsDemand);

          player.RescaleSoul();
        }

      }

      if(Input.GetButtonDown("Ability2"))
      {
        if(!(player.NotLimitSoul()))
        {
          HealPlayer(player.healTime);

          player.SetSouls(player.GetSoul() - player.healSoulsDemand);
          player.RescaleSoul();
        }

      }

      if(Input.GetButtonDown("Ability3"))
      {
        if(!(player.NotLimitSoul()))
        {
          ChangeWeaponMode(3);
          player.SetSouls(player.GetSoul() - player.shootGunSoulsDemand);

          player.RescaleSoul();
        }

      }

    }

    IEnumerator HealPlayer(float waitTime)
    {

      yield return new WaitForSeconds(waitTime);
      player.ChangeHP(player.healCount);

  }

    void ChangeWeaponMode(int modeNumber)
    {
      equippedweapon.GetComponent<Gun>().SetWeaponMode(modeNumber);
    }

    void Attack()
    {
        if(equippedweapon)
        {
            equippedweapon.GetComponent<Gun>().Shoot();
        }
    }

    void RescaleBullet(int buller, int maxBullet)
    {
        GetComponent<Player>().UI.GetComponent<UIGameMode>().ShowBullet(buller, maxBullet); //��������� �������
    }

}
