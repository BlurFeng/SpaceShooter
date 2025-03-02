using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyItemBase : MonoBehaviour
{
    [Header("FlyItemBase")]
    [SerializeField]
    private float flySpeed = 4f;
    
    [SerializeField]
    private float rotateSpeed = 0f;
    
    [SerializeField]
    private float lifetime = 4f;
    
    [SerializeField]
    private Direction flyDirection = Direction.Right;
    [SerializeField, 
     Tooltip("When a custom flight direction is available, prioritize using it; otherwise, set the flight direction based on the FlyDirection configuration." +
             "\n当有自定义飞行方向时，优先使用，否则根据FlyDirection的配置设置飞行方向。" +
             "\nカスタムの飛行方向がある場合は、それを優先して使用し、ない場合は FlyDirection の設定に基づいて飛行方向を設定する。")]
    private Vector3 customFlyDirection;
    
    private float lifetimer;

    public Rigidbody Rigidbody
    {
        get
        {
            if (rb == null)
            {
                rb = GetComponent<Rigidbody>();
            }
            
            return rb;
        }
    }
    private Rigidbody rb;
    
    // Start is called before the first frame update
    private void Start()
    {
        // Set the initial movement and rotation speed. //设置初始移动和旋转速度。 //初期の移動速度と回転速度を設定する。
        Vector3 dir = customFlyDirection != Vector3.zero ? customFlyDirection : CommonTypes.GetDirection(flyDirection);
        Rigidbody.velocity = dir * flySpeed;
        Rigidbody.angularVelocity = Random.insideUnitSphere * rotateSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        // Destroy itself after the lifetime ends. // 存活时间结束后销毁自身。 // 生存時間が終了した後、自身を破壊する。
        lifetimer += Time.deltaTime;
        if (lifetimer >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Set the flight speed and rotation speed.
    /// 设置飞行速度和旋转速度。
    /// 飛行速度と回転速度を設定する。
    /// </summary>
    /// <param name="inFlySpeed"></param>
    /// <param name="inRotateSpeed"></param>
    public void SetSpeed(float inFlySpeed, float inRotateSpeed)
    {
        flySpeed = inFlySpeed;
        rotateSpeed = inRotateSpeed;
    }

    /// <summary>
    /// Set a custom flight direction.
    /// 设置自定义的飞行方向。
    /// カスタムの飛行方向を設定する。
    /// </summary>
    /// <param name="inCustomFlyDirection"></param>
    public void SetCustomFlyDirection(Vector3 inCustomFlyDirection)
    {
        customFlyDirection = inCustomFlyDirection;
    }
}
