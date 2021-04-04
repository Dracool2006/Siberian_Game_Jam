using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : WeaponBase
{

    //first use right mouse button for changing mode
    private bool button = false;

    // статы разных типов оружия
    public PistolStats pistolStats;
    public ShootgunStats shootgunStats;
    public MachinegunStats machinegunStats;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }


    public void SetWeaponMode(int modeNumber){

      mode = modeNumber;
      ChangeMode(mode);
      //print(mode);

    }


    public override void Shoot()
    {
      // если сейчас не кулдаун
      if(Canshot)
      {
        //если есть патроны
        if (currentBulletsInMagazine > 0 && bullet != null){

          if (barrel == null)
            barrel = (transform.Find ("Barrel")).transform;

          // создаем проджектайл
          foreach (GameObject bullet in bullets )
          {
            print ("Instantiate bullet");
            Instantiate (bullet, barrel.position, barrel.rotation);
          }


          currentBulletsInMagazine = currentBulletsInMagazine - 1;
          //запускаем кулдаун
          StartCoroutine(shootingCooldown(60/shootingSpeed));
        }
        //если патронов нет, то перезаряжаем
        if (currentBulletsInMagazine <= 0 && !isReloading){

          StartCoroutine(reloading(reloadingTime));
        }
      }

    }

    public void ChangeMode(int mode)
    {
        if (mode == 1) // pistol
        {
          reloadingTime = pistolStats.reloadingTime;
          MaxBulletsInMagazine = pistolStats.MaxBulletsInMagazine;
          currentBulletsInMagazine = MaxBulletsInMagazine;
          shootingSpeed = pistolStats.shootingSpeed;
          bullets = pistolStats.BulletsList;

        }
        else if (mode == 2) // machinegun
        {

          reloadingTime = machinegunStats.reloadingTime;
          MaxBulletsInMagazine = machinegunStats.MaxBulletsInMagazine;
          currentBulletsInMagazine = MaxBulletsInMagazine;
          shootingSpeed = machinegunStats.shootingSpeed;
          bullets = machinegunStats.BulletsList;

        }
        else if(mode == 3) // shootgun
        {

          reloadingTime = shootgunStats.reloadingTime;
          MaxBulletsInMagazine = shootgunStats.MaxBulletsInMagazine;
          currentBulletsInMagazine = MaxBulletsInMagazine;
          shootingSpeed = shootgunStats.shootingSpeed;
          bullets = shootgunStats.BulletsList;
        }
    }

}

enum RangeWeaponMode{
  gun,
  shootgun,
  machinegun
}
