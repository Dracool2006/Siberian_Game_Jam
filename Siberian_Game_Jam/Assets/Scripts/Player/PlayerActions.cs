using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public GameObject equippedweapon;
    private Player player;


    public AudioSource MActive1;
    public AudioSource MActive2;
    public AudioSource MActive3;

    // Start is called before the first frame update
    void Start()
    {
      player = GetComponent<Player>();
      ChangeWeaponMode(1);
      RescaleBullet(equippedweapon.GetComponent<Gun>().currentBulletsInMagazine, equippedweapon.GetComponent<Gun>().MaxBulletsInMagazine);
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
        if(player.GetSoul() > player.machineGunSoulsDemand)
        {
            ChangeWeaponMode(2);
            player.SetSouls(player.GetSoul() - player.machineGunSoulsDemand);

            player.RescaleSoul();
                MActive1.Play();
        }

      }

      if(Input.GetButtonDown("Ability2"))
      {
        if(player.GetSoul() > player.healSoulsDemand)
        {
          HealPlayer(player.healTime);

          player.SetSouls(player.GetSoul() - player.healSoulsDemand);
          player.RescaleSoul();
                MActive2.Play();
        }

      }

      if(Input.GetButtonDown("Ability3"))
      {
            if (player.GetSoul() > player.shootGunSoulsDemand)
            {
                ChangeWeaponMode(3);
                player.SetSouls(player.GetSoul() - player.shootGunSoulsDemand);

                player.RescaleSoul();
                MActive3.Play();
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
            RescaleBullet(equippedweapon.GetComponent<Gun>().currentBulletsInMagazine, equippedweapon.GetComponent<Gun>().MaxBulletsInMagazine);
        }
    }

    void RescaleBullet(int buller, int maxBullet)
    {
        GetComponent<Player>().UI.GetComponent<UIGameMode>().ShowBullet(buller, maxBullet); //��������� �������
    }

}
