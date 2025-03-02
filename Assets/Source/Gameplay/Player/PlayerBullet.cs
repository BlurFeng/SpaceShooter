using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : FlyItemBase
{
    private string ownerTag;

    public void Init(string inOwnerTag)
    {
        ownerTag = inOwnerTag;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // When the bullet hits the target, it deals damage to the target.
        // 子弹击中目标时，对目标造成伤害。
        // 弾丸がターゲットに命中すると、ターゲットにダメージを与える。
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null && !other.CompareTag(ownerTag))
        {
            damageable.TakeDamage(10f);
            Destroy(gameObject);
            
            GameMode.Instance.AddScore(damageable.GetScore());
        }
    }
}
