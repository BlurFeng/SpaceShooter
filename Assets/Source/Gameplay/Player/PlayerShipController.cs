using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour, IDamageable
{
    [Header("Movement")]
    [SerializeField, Tooltip("加速度。")]
    private float acceleratedVelocity = 42f;
    
    [SerializeField, Tooltip("最大速度。")]
    private float maxVelocity = 6f;

    [SerializeField, Tooltip("倾斜角度。 \n傾き。")]
    private float tilt = 45f;

    [SerializeField, Tooltip("Restrict the position within the boundary range. \n限制位置在边界范围内。 \n位置を境界範囲内に制限する。")] 
    private Boundary boundary;
    
    private Rigidbody rb;
    private Vector3 inputDir;

    #region \\Attack \\攻击 \\ 攻撃

    [Header("Attack")]
    [SerializeField, Tooltip("子弹预制体。\n弾丸プレハブ。")]
    private GameObject bulletPrefab;
    
    [SerializeField, Tooltip("Bullet firing position.\n子弹发射位置。\n弾丸発射位置。")]
    private Transform shootTransform;

    [SerializeField, Tooltip("Bullet firing interval.\n子弹发射时间间隔。\n弾丸発射間隔。")]
    private float shootInterval = 0.5f;

    [SerializeField]
    private AudioSource shootAudio;

    [SerializeField]
    private int shooterLevel = 1;
    
    private float shootTimePoint;

    /// <summary>
    /// After shooter level up, we can fire more bullets at once.
    /// 升级发射器后我们能一次性发射更多的子弹。
    /// Shooterをレベルアップすると、一度にもっと多くの弾を発射できるようになります。
    /// </summary>
    public void ShooterLevelUp()
    {
        shooterLevel++;
    }

    private void Shoot()
    {
        // Check the firing interval time.
        // 确认发射间隔时间。
        // 発射間隔時間を確認する。
        if(Time.time < shootTimePoint) return;
        shootTimePoint = Time.time + shootInterval;

        // Generate bullets in different ways based on the current shooter Level.
        // 根据当前发射器等级，以不同的方式生成子弹。
        // 現在のshooterのレベルに基づいて、異なる方法で弾を生成する。
        if (shooterLevel == 1)
        {
            SpawnBullet();
        }
        else if (shooterLevel == 2)
        {
            SpawnBullet(30f);
            SpawnBullet(-30f);

        }
        else if (shooterLevel >= 3)
        {
            SpawnBullet();
            SpawnBullet(30f);
            SpawnBullet(-30f);
        }
        
        shootAudio.Play();
    }

    private void SpawnBullet(float angleOffset = 0f)
    {
        PlayerBullet playerBullet = Instantiate(bulletPrefab, shootTransform.position, shootTransform.rotation).GetComponent<PlayerBullet>();
        playerBullet.Init(tag);

        if (angleOffset != 0f)
        {
            playerBullet.gameObject.transform.Rotate(Vector3.forward, angleOffset);
            playerBullet.SetCustomFlyDirection(BlurFunctionLibrary.AngleAxis(Vector3.right, Vector3.forward, angleOffset));
        }
    }
    
    #endregion
    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(transform.position.x, transform.position.y, GameSettings.PlayItemPosZ);
    }

    // Update is called once per frame
    private void Update()
    {
        // --- Get input ---
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        inputDir = new Vector3(h, v, 0f).normalized;

        // --- Shoot ---
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        // --- Move ---
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
        
        
        // --- Rotate ---
        rb.rotation = Quaternion.Euler(rb.velocity.y / maxVelocity * tilt, 0f, 0f);
        
        
        // --- Limit the position ---
        float posX = Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax);
        float posY = Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax);
        
        rb.position = new Vector3(posX, posY, rb.position.z);
    }

    #region Damageable

    [Header("Damageable")]
    [SerializeField]
    private GameObject explosionPrefab;

    public void TakeDamage(float damage)
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        GameMode.Instance.GameOver();
    }

    #endregion
    
}
