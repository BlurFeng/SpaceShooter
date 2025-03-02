using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 可以受到伤害接口。
// ダメージを受けるインターフェース。
public interface IDamageable
{
    public void TakeDamage(float damage);
}
