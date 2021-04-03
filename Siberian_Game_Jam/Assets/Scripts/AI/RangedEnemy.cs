using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    /*// Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }*/


    public override void AttackStart(){
        //anim.SetBool("Attack", true);
      //  Debug.Log("EnemyAttack");
        state = States.attackig;
        EquippedWeapon.GetComponent<Gun>().Shoot();
        //StartCoroutine(AttackCooldown(attackCooldownTime));
    }

    public override void AttackEnd(){
        //anim.SetBool("Attack", false);
        state = States.lookingfor;
        //EquippedWeapon.SetAttackColliderActive(true);
    }
}
