using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class PropGenerator : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)]
    private float spawnPropProbability = 0.2f;
    
    [SerializeField]
    private WeightItem[] spawnPropInfos;

    private int[] propWeights;
    private int propWeightTotal;
    
    private void Start()
    {
        // The data used for calculating random items.
        // 计算随机道具时用到的数据。
        // ランダムアイテムを計算する際に使用するデータ。
        propWeights = new int[spawnPropInfos.Length];
        for (int i = 0; i < spawnPropInfos.Length; i++)
        {
            propWeights[i] = spawnPropInfos[i].weight;
            propWeightTotal += propWeights[i];
        }
    }

    public void SpawnProp()
    {
        if (spawnPropInfos.Length == 0 || propWeightTotal == 0) return;
        
        // Randomly spawn an item.
        // 随机生成道具。
        // アイテムをランダムに生成する。
        if (Random.Range(0f, 1f) <= spawnPropProbability)
        {
            // Randomly select based on the weights configured in the prop list.
            // 根据道具列表配置的权重进行随机。
            // アイテムリストで設定された重みに基づいてランダムに選択する。
            int index = BlurFunctionLibrary.RandomIndexByWeights(propWeights, propWeightTotal);
            
            Instantiate(spawnPropInfos[index].prefab, transform.position, Quaternion.identity);
        }
    }
}
