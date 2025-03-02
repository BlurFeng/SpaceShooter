using System;
using System.Collections;
using System.Collections.Generic;
using Source.Gameplay.Interfaces;
using UnityEngine;

public class PropBase : FlyItemBase, IGetProp
{
    public virtual void GetProp(GameObject user)
    {
        Destroy(gameObject);
    }

    public void FixedUpdate()
    {
        // Items can collide with each other, so we need to lock the Z height to ensure they remain on the same plane and can be collected properly.
        // 道具能互相碰撞，所以我们需要锁定Z高度，防止不在一个平面无法碰撞获取到道具。
        // アイテム同士が衝突するため、Z軸の高さを固定し、同じ平面上に留まることで正常に取得できるようにする。
        Rigidbody.velocity = new Vector3( Rigidbody.velocity.x,  Rigidbody.velocity.y, 0f);
    }
}
