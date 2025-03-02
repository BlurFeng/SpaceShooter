using System;
using UnityEngine;

public static class BlurFunctionLibrary
{
    #region Common And Math

    public static Vector3 AngleAxis(Vector3 dir, Vector3 axis, float angle)
    {
        return Quaternion.AngleAxis(angle, axis) * dir.normalized;
    }

    #endregion
}