using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils 
{
    public static bool isInRange(Vector3 origin, Vector3 target, float range)
    {
        return Vector3.Distance(origin, target) <= range;
    }

    public static Transform FindClosestObject(Transform origin, float range, string tag)
    {
        Collider[] collidersInRange = Physics.OverlapSphere(origin.position, range);
        List<Transform> objList = new List<Transform>();
        for (int i = 0; i < collidersInRange.Length; i++)
        {
            Transform obj = collidersInRange[i].transform;
            if (obj.tag.Equals(tag) && obj.transform != origin.transform)
                objList.Add(obj);
        }

        objList.Sort((a, b) =>
        {
            float distA = Vector3.SqrMagnitude(origin.position - a.transform.position);
            float distB = Vector3.SqrMagnitude(origin.position - b.transform.position);
            if (distA < distB)
                return -1;
            else if (distA == distB)
                return 0;
            else return 1;
        }
        );

        if (objList.Count == 0)
            return null;
        else
            return objList[0];
    }
}
