using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    [SerializeField, Tooltip("背景移动速度。")]
    private float scrollSpeed = 2f;
    
    private Vector3 startPos;
    // Start is called before the first frame update
    private void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        float dis = Mathf.Repeat(scrollSpeed * Time.time, transform.localScale.y);
        transform.position = startPos + dis * -Vector3.right;
    }
}
