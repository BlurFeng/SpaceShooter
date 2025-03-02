using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : EnemyBase
{
    [Header("Asteroid Split")]
    [SerializeField, Tooltip("When destroyed, generate fragment asteroids.\n当自身被销毁时，产生碎片小行星。\n自身が破壊された際に、破片の小惑星を生成する。")]
    private bool asteroidCanSplit;
    
    [SerializeField]
    private GameObject[] splitAsteroidPrefabs;

    protected override void InitSpeedPre()
    {
        base.InitSpeedPre();
        
        SetFlySpeedIncrease(1f + GameMode.Instance.DifficultyLevel * 0.6f);
    }

    protected override void DestroySelf()
    {
        base.DestroySelf();
        
        // When destroyed, generate fragment asteroids.
        // 当自身被摧毁时，生成碎片小行星。
        // 自分が破壊されると、破片の小惑星を生成する。
        if (asteroidCanSplit)
        {
            for (int i = 0; i < 2; i++)
            {
                FlyItemBase flyItemBase = Instantiate(splitAsteroidPrefabs[i], transform.position, transform.rotation).GetComponent<FlyItemBase>();

                flyItemBase.SetCustomFlyDirection(BlurFunctionLibrary.AngleAxis(Rigidbody.velocity, Vector3.forward, i == 1 ? 45f : -45f));
            }
        }
    }

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
