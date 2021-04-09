using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{

    public Transform barrel;
    public GameObject bullet;
    public GameObject[] bullets;
    public float reloadingTime = 2f;
    public int MaxBulletsInMagazine = 6;
    public int currentBulletsInMagazine = 6;
    public bool isReloading = false;
    protected bool Canshot = true;
    public float shootingSpeed = 60.0f; // указывается количество выстрелов в минуту
    public int mode = 1;

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
        Canshot = false;
        yield return new WaitForSeconds(waitTime);
        Canshot = true;

    }

    public virtual IEnumerator reloading(float waitTime)
    {

        isReloading = true;
        yield return new WaitForSeconds(waitTime);
        currentBulletsInMagazine = MaxBulletsInMagazine;
        isReloading = false;

    }



}
