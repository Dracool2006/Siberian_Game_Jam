using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : WeaponBase
{
    //first use right mouse button for changing mode
    bool button = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        barrel = GameObject.FindWithTag("Barrel").transform;
        Vector3 player = GameObject.FindWithTag("Player").transform.position;
        transform.position = player;

        if (Input.GetAxis("Fire1") != 0)
        {
            Shoot();
        }

        
        if (Input.GetMouseButton(1))
        {
            if (!button)
            {
                button = true;
                mode = (mode + 1) % 3;
                ChangeMode(mode);
                print(mode);
            }
        }
        else
        {
            button = false;
        }
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
          if(mode == 2)
          {
            Instantiate(bullet, barrel.position, barrel.rotation);
            Instantiate(bullet, barrel.position, barrel.rotation);
            Instantiate(bullet, barrel.position, barrel.rotation);
          }

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
