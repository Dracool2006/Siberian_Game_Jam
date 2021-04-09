using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : WeaponBase
{

    //first use right mouse button for changing mode
    private bool button = false;
    public RangeWeaponMode weaponMode;
    // статы разных типов оружия
    public PistolStats pistolStats;
    public ShootgunStats shootgunStats;
    public MachinegunStats machinegunStats;
    public Animator muzzleFlashAnimator;
    public AudioSource AudioShoot;
    public AudioSource AudioReload;
    public Crosshair crosshair;

    // Start is called before the first frame update
    void Start()
    {
      SetWeaponMode(1);
      weaponMode = RangeWeaponMode.pistol;
      muzzleFlashAnimator = GetComponent <Animator> ();
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

            if(crosshair != null)
              crosshair.PlayShootingAnimate();

            AudioShoot.Play();

            if (barrel == null)
                barrel = (transform.Find ("Barrel")).transform;

          // создаем проджектайл
            foreach (GameObject bullet in bullets )
            {
                Instantiate (bullet, barrel.position, barrel.rotation);
            }



            muzzleFlashAnimator.SetTrigger("Shoot");

            currentBulletsInMagazine = currentBulletsInMagazine - 1;
            //запускаем кулдаун
            StartCoroutine(shootingCooldown(60/shootingSpeed));

            //если патронов нет, то перезаряжаем
            if (currentBulletsInMagazine <= 0 && !isReloading){

                StartCoroutine(reloading(reloadingTime));
            }

        }

      }
    }


    public override IEnumerator reloading(float waitTime)
    {
      if(crosshair != null)
      {
        crosshair.PlayReloadingAnimate();
        crosshair.ResetShootingAnimate();
      }

      if(AudioReload != null)
        AudioReload.Play();

      isReloading = true;
      yield return new WaitForSeconds(waitTime);
      currentBulletsInMagazine = MaxBulletsInMagazine;
      isReloading = false;

      if(crosshair != null)
        crosshair.StopReloadingAnimate();

    }

    public IEnumerator AbilityTimer(float waitTime)
    {
      yield return new WaitForSeconds(waitTime);
      ChangeMode(1);
    }

    public void ChangeMode(int mode)
    {
        if (mode == 1) // pistol
        {
          weaponMode = RangeWeaponMode.pistol;
          reloadingTime = pistolStats.reloadingTime;
          MaxBulletsInMagazine = pistolStats.MaxBulletsInMagazine;
          currentBulletsInMagazine = MaxBulletsInMagazine;
          shootingSpeed = pistolStats.shootingSpeed;
          bullets = pistolStats.BulletsList;

        }
        else if (mode == 2) // machinegun
        {
          weaponMode = RangeWeaponMode.machinegun;
          reloadingTime = machinegunStats.reloadingTime;
          MaxBulletsInMagazine = machinegunStats.MaxBulletsInMagazine;
          currentBulletsInMagazine = MaxBulletsInMagazine;
          shootingSpeed = machinegunStats.shootingSpeed;
          bullets = machinegunStats.BulletsList;

          StartCoroutine(AbilityTimer(machinegunStats.machinegunTime));
        }

        else if(mode == 3) // shootgun
        {
          weaponMode = RangeWeaponMode.shootgun;
          reloadingTime = shootgunStats.reloadingTime;
          MaxBulletsInMagazine = shootgunStats.MaxBulletsInMagazine;
          currentBulletsInMagazine = MaxBulletsInMagazine;
          shootingSpeed = shootgunStats.shootingSpeed;
          bullets = shootgunStats.BulletsList;

          StartCoroutine(AbilityTimer(shootgunStats.shootgunTime));
        }
    }
}




public enum RangeWeaponMode{
  pistol = 1,
  machinegun = 2,
  shootgun = 3
}
