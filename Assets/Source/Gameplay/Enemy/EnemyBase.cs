using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class EnemyBase : FlyItemBase , IDamageable
{
    [SerializeField]
    protected int scoreValue = 100;
    
    #region Damageable

    [Header("Damageable")]
    [SerializeField]
    private GameObject explosionPrefab;

    public virtual void TakeDamage(float damage)
    {
        DestroySelf();
    }

    public virtual int GetScore()
    {
        return scoreValue;
    }

    protected virtual void DestroySelf()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        
        // When destroyed, randomly generate an item.
        // 当自身销毁时，随机生成道具。
        // 自身が破壊された際に、ランダムにアイテムを生成する。
        PropGenerator propGenerator = GetComponent<PropGenerator>();
        if (propGenerator != null) propGenerator.SpawnProp();
    }

    #endregion
}