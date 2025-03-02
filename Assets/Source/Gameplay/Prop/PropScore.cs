using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropScore : PropBase
{
    [Header("Prop Score")]
    [SerializeField]
    protected int scoreValue = 50;
    
    public override void GetProp(GameObject user)
    {
        base.GetProp(user);
        
        GameMode.Instance.AddScore(scoreValue);
    }
}
