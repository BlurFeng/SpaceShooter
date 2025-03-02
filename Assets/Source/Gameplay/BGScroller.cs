using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    [SerializeField, Tooltip("Background movement speed.\n背景移动速度。\n背景の移動速度。")]
    private float scrollSpeed = 2f;
    
    private Vector3 startPos;
    
    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        // When the background moves beyond a certain distance, it resets to the initial position. By combining two background images, an infinitely scrolling background can be created.
        // 当背景移动超出一定距离后，重置回初始位置。两个背景图组合可制作无限移动的背景。
        // 背景が一定の距離を超えて移動したら、初期位置にリセットする。2枚の背景画像を組み合わせることで、無限に移動する背景を作成できる。
        float dis = Mathf.Repeat(scrollSpeed * Time.time, transform.localScale.y);
        transform.position = startPos + dis * -Vector3.right;
    }
}
