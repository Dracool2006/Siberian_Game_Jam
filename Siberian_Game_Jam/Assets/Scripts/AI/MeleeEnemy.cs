using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{



    // Start is called before the first frame update
  /*  void Start()
    {
    }*/

    // Update is called once per frame
    /*void Update()
    {

    }*/


    public override void AttackStart(){
        anim.SetBool("Attack", true);
        Debug.Log("EnemyAttack");
        state = States.attackig;
        //EquippedWeapon.SetAttackColliderActive(true);
        StartCoroutine(AttackCooldown(attackCooldownTime));
    }

    public override void AttackEnd(){
        anim.SetBool("Attack", false);
        state = States.lookingfor;
        //EquippedWeapon.SetAttackColliderActive(true);
    }

    //  Медод, вызывающий включение/выключение коллизии оружия, мызывается из Animation Event
    public void MeleeWeaponActivateCollider (int value)
    {
      if (value ==1 )
        EquippedWeapon.GetComponent<MeleeWeapon> ().SetActiveCollider(true);
      else
        EquippedWeapon.GetComponent<MeleeWeapon> ().SetActiveCollider(false);
    }

}
