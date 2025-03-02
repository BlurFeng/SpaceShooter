using System;
using UnityEngine;
using Random = UnityEngine.Random;

public static class BlurFunctionLibrary
{
    #region Math

    public static Vector3 AngleAxis(Vector3 dir, Vector3 axis, float angle)
    {
        return Quaternion.AngleAxis(angle, axis) * dir.normalized;
    }

    #endregion

    /// <summary>
    /// Randomly return an index based on the passed weight array.
    /// 根据传入的权重数组，根据权重随机并返回一个Index。
    /// 渡された重みの配列に基づいて、ランダムにインデックスを選択して返す。
    /// </summary>
    /// <param name="weights"></param>
    /// <param name="weightTotal"></param>
    /// <returns></returns>
    public static int RandomIndexByWeights(int[] weights, int weightTotal = 0)
    {
        if (weightTotal == 0)
        {
            for (int i = 0; i < weights.Length; i++)
            {
                weightTotal += weights[i];
            }
        }
        
        int randomInt = Random.Range(1, weightTotal + 1);

        int right = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            right += weights[i];

            if (randomInt <= right)
            {
                return i;
            }
        }
        
        return 0;
    }
}