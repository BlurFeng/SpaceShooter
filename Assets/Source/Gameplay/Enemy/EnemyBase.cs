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
    }

    #endregion
}