using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{

    public float waitTimeBeforeShoot = 1f;
    public Coroutine waitAttack;

  

    public override void AttackStart()
    {
        //  anim.SetBool("Attack", true);
        //  Debug.Log("EnemyAttack");
        if (GetIsDead())
            return;
        state = States.attackig;
        waitAttack = StartCoroutine(WaitToAttack(waitTimeBeforeShoot));


        //StartCoroutine(AttackCooldown(attackCooldownTime));
    }

    public override void AttackEnd()
    {
        if (GetIsDead())
            return;
        //anim.SetBool("Attack", false);
        state = States.lookingfor;
        //EquippedWeapon.SetAttackColliderActive(true);
    }

    IEnumerator WaitToAttack(float waitTime)
    {
        if (GetIsDead())
            yield return null;
        yield return new WaitForSeconds(waitTime);
        if(EquippedWeapon.activeSelf)
            EquippedWeapon.GetComponent<Gun>().Shoot();

    }

    public override void Death()
    {
        base.Death();

        if(waitAttack != null)
            StopCoroutine(waitAttack);
        
    }
}
