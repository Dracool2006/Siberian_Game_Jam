using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{

    public Transform barrel;
    public GameObject bullet;
    public float reloadingTime = 1f;
    public int MaxBulletsInMagazine = 6;
    public int currentBulletsInMagazine = 6;
    public bool isReloading = false;
    protected bool isCanshot = true;
    public float shootingSpeed = 120.0f; // указывается количество выстрелов в минуту
    public int mode = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Shoot()
    {

    }

    public IEnumerator shootingCooldown(float waitTime)
    {
        isCanshot = false;
        yield return new WaitForSeconds(waitTime);
        isCanshot = true;

    }

    public IEnumerator reloading(float waitTime)
    {
        isReloading = true;
        yield return new WaitForSeconds(waitTime);
        currentBulletsInMagazine = MaxBulletsInMagazine;
        isReloading = false;

    }

    public void ChangeMode(int mode)
    {
        if (mode == 0)
        {
            return;
        }
        else if (mode == 1)
        {
            reloadingTime = 1.5f;
            MaxBulletsInMagazine = 24;
            currentBulletsInMagazine = 24;
            shootingSpeed = 240;
    
        }
        else if(mode == 2)
        {
            reloadingTime = 1f;
            MaxBulletsInMagazine = 12;
            currentBulletsInMagazine = 12;
            shootingSpeed = 39;
        }
    }


}
