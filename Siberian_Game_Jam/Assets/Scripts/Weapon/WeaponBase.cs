using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{

    public Transform barrel;
    public GameObject bullet;
    public float reloadingTime = 2f;
    public int MaxBulletsInMagazine = 6;
    public int currentBulletsInMagazine = 6;
    public bool isReloading = false;
    protected bool isCanshot = true;
    public float shootingSpeed = 60.0f; // указывается количество выстрелов в секунду

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

}
