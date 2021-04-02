using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : WeaponBase
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      barrel = (transform.Find ("Barrel")).transform;
    }

    public override void Shoot()
    {
      // если сейчас не кулдаун
      if(isCanshot)
      {
        //если есть патроны
        if (currentBulletsInMagazine > 0 && bullet != null){
          // создаем проджектайл
          Instantiate (bullet, barrel.position, barrel.rotation);

          currentBulletsInMagazine = currentBulletsInMagazine -1;
          //запускаем кулдаун
          StartCoroutine(shootingCooldown(60/shootingSpeed));
        }
        //если патронов нет, то перезаряжаем
        if (currentBulletsInMagazine <= 0 && !isReloading){

          StartCoroutine(reloading(reloadingTime));
        }
      }

    }


}
