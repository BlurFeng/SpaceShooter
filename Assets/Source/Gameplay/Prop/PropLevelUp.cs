using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropLevelUp : PropBase
{
    public override void GetProp(GameObject user)
    {
        base.GetProp(user);
        
        PlayerShipController playerShip = user.gameObject.GetComponent<PlayerShipController>();
        if (playerShip != null) playerShip.ShooterLevelUp();
    }
}
