using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class EnemyBase : FlyItemBase , IDamageable
{
    #region Damageable

    [Header("Damageable")]
    [SerializeField]
    private GameObject explosionPrefab;

    public virtual void TakeDamage(float damage)
    {
        DestroySelf();
    }

    protected void DestroySelf()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    #endregion
}