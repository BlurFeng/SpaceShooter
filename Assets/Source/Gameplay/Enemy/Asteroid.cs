using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : EnemyBase
{
    private void OnTriggerEnter(Collider other)
    {
        // When the Asteroid hits the target, it deals damage to damageable targets and destroys itself.
        // 小行星撞击目标时，对可接受伤害的目标造成伤害，并销毁自身。
        // 小惑星がターゲットに衝突すると、ダメージを受ける対象にダメージを与え、自身は破壊される。
        IDamageable damageable = other.GetComponentInSelfOrParent<IDamageable>();
        if (damageable != null && !other.CompareTag(tag))
        {
            damageable.TakeDamage(10f);
            DestroySelf();
        }
    }
}
