using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FlyItemBase : MonoBehaviour
{
    [SerializeField]
    private float FlySpeed = 10f;
    
    [SerializeField]
    private float RotateSpeed = 0f;
    
    [SerializeField]
    private float lifetime = 4f;
    
    [SerializeField]
    private Direction FlyDirection = Direction.Right;
    
    private float lifetimer;
    
    // Start is called before the first frame update
    void Start()
    {
        // Set the initial movement and rotation speed. //设置初始移动和旋转速度。 //初期の移動速度と回転速度を設定する。
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = CommonTypes.GetDirection(FlyDirection) * FlySpeed;
        rb.angularVelocity = Random.insideUnitSphere * RotateSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy itself after the lifetime ends. // 存活时间结束后销毁自身。 // 生存時間が終了した後、自身を破壊する。
        lifetimer += Time.deltaTime;
        if (lifetimer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
