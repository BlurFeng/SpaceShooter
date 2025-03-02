using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropShield : PropBase
{
    [Header("Prop Shield")]
    [SerializeField]
    float shieldDuration = 5f;
    
    public override void GetProp(GameObject user)
    {
        base.GetProp(user);
        
        PlayerShipController playerShip = user.gameObject.GetComponent<PlayerShipController>();
        if (playerShip != null) playerShip.InvincibleShield(shieldDuration);
    }
}
