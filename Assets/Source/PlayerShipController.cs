using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public struct Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerShipController : MonoBehaviour
{
    [SerializeField, Tooltip("加速度。")]
    private float acceleratedVelocity = 42f;
    
    [SerializeField, Tooltip("最大速度。")]
    private float maxVelocity = 6f;

    [SerializeField, Tooltip("倾斜角度。 \n 傾き。")]
    private float tilt = 45f;

    [SerializeField, Tooltip("Restrict the position within the boundary range. \n 限制位置在边界范围内。 \n 位置を境界範囲内に制限する。")] 
    private Boundary boundary;
    
    private Rigidbody rb;
    private Vector3 inputDir;
    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Get input. // 获取输入。 // 入力を取得する。
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        inputDir = new Vector3(h, v, 0f).normalized;
    }

    private void FixedUpdate()
    {
        // --- Move // 移动 ---
        if (inputDir != Vector3.zero)
        {
            // Increase speed. // 增加速度。 // 速度を増加させる。
            rb.velocity += acceleratedVelocity * Time.fixedDeltaTime * inputDir;
            
            // Limit the maximum speed. // 限制最大速度。 // 最大速度を制限する。
            if (rb.velocity.magnitude > maxVelocity)
            {
                rb.velocity = rb.velocity.normalized * maxVelocity;
            }
        }
        else if (rb.velocity != Vector3.zero)
        {
            Vector3 vel = acceleratedVelocity * Time.fixedDeltaTime * -rb.velocity.normalized;
            
            // Decrease speed. // 减速度。 // 速度を減少させる。
            if (rb.velocity.magnitude > vel.magnitude)
                rb.velocity += vel;
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
        
        
        // --- Rotate // 旋转 ---
        rb.rotation = Quaternion.Euler(rb.velocity.y / maxVelocity * tilt, 0f, 0f);
        
        
        // --- Limit the position // 限制位置 // 位置を制限する ---
        float posX = Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax);
        float posY = Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax);
        
        rb.position = new Vector3(posX, posY, rb.position.z);
    }
}
