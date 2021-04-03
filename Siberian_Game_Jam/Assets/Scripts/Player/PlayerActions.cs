using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{


    public GameObject equippedweapon;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            Attack();
        }

        if(Input.GetButtonDown("Submit"))
        {

        }

    }
    void FixedUpdate()
    {

    }

    void Attack()
    {
        if(equippedweapon){
            Debug.Log("Attack");
            equippedweapon.GetComponent<Gun>().Shoot();
        }
    }



}
