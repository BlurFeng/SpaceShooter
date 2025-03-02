using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public struct Boundary
{
    public float xMin, xMax, yMin, yMax;
}

[System.Serializable]
public struct FloatRandom
{
    public FloatRandom(float value, float randomDeviation)
    {
        this.value = value;
        this.randomDeviation = randomDeviation;
    }
    
    public float value;
    public float randomDeviation;

    public float GetValue()
    {
        return value + Random.Range(-randomDeviation, randomDeviation);
    }
}

[System.Serializable]
public struct IntRandom
{
    public IntRandom(int value, int randomDeviation)
    {
        this.value = value;
        this.randomDeviation = randomDeviation;
    }
    
    public int value;
    public int randomDeviation;

    public int GetValue()
    {
        return value + Random.Range(-randomDeviation, randomDeviation);
    }
}

public enum Direction
{
    Forward,
    Backward,
    Right,
    Left,
    Up,
    Down
}

public static class CommonTypes
{
    public static Vector3 GetDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.Forward:
                return Vector3.forward;
                break;
            case Direction.Backward:
                return -Vector3.forward;
                break;
            case Direction.Right:
                return Vector3.right;
                break;
            case Direction.Left:
                return -Vector3.right;
                break;
            case Direction.Up:
                return Vector3.up;
                break;
            case Direction.Down:
                return -Vector3.up;
                break;
        }
    
        return Vector3.forward;
    }
}

[Serializable]
public struct WeightItem
{
    public GameObject prefab;
    public int weight;
}