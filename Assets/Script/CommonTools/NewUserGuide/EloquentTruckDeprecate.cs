using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 事件渗透
/// </summary>
public class EloquentTruckDeprecate : MonoBehaviour, ICanvasRaycastFilter
{
    private RectTransform MasterEach;
[UnityEngine.Serialization.FormerlySerializedAs("isclick")]    public bool Lineage= false;

    public void BisScreamEach(RectTransform rect)
    {
        MasterEach = rect;
        Lineage = false;
    }
    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        if (MasterEach == null)
        {
            Debug.Log("[Penetrate] targetRect is null, return false");
            return false;
        }
        bool inHole = RectTransformUtility.RectangleContainsScreenPoint(MasterEach, sp, eventCamera);
        
        //Debug.Log($"[Penetrate] sp={sp}, eventCamera={eventCamera}, targetRect={targetRect}, inHole={inHole}");
        return inHole;
    }
}