using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTimer : MonoBehaviour
{
    [SerializeField]
    private float delayTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delayTime);
    }
}
