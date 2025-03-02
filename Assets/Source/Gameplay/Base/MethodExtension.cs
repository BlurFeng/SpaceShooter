using UnityEngine;

public static class ColliderMethodExtension
{
    public static T GetComponentInSelfOrParent<T>(this Collider self)
    {
        T component = self.GetComponent<T>();
        if (component == null)
        {
            component = self.GetComponentInParent<T>();
        }
        
        return component;
    }
}