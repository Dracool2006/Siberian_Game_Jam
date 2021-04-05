using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{






    public override void AttackStart(){
        enemyAnimator.SetTrigger("Attack");
        //Debug.Log("EnemyAttack");
        state = States.attackig;
        //EquippedWeapon.SetAttackColliderActive(true);
        StartCoroutine(AttackCooldown(attackCooldownTime));
    }

    public override void AttackEnd(){
        //enemyAnimator.SetBool("Attack", false);
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

    public override void Death()
    {

        MeleeWeaponActivateCollider (0);
        state = States.dead;
        enemyAnimator.SetBool("Death", true);
        AudioDead.Play();
        //Debug.Log("Enemy Death");
        gameObject.GetComponent<Collider2D> ().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        SetIsDead (true);
        StartCoroutine(Disappear(3.0f));
        SoulGenerate();
        GameObject.FindWithTag("MainCamera").GetComponent<MainLogic>().EnemyDead();
    }


}
