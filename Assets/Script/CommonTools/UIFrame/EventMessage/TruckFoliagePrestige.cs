/*
 *     主题： 事件触发监听      
 *    Description: 
 *           功能： 实现对于任何对象的监听处理。
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TruckFoliagePrestige : UnityEngine.EventSystems.EventTrigger
{
    public delegate void VoidDelegate(GameObject go);
    public VoidDelegate onAloud;
    public VoidDelegate HeDose;
    public VoidDelegate HeVague;
    public VoidDelegate HeLien;
    public VoidDelegate HeUp;
    public VoidDelegate HeWinner;
    public VoidDelegate HeSunlitWinner;

    /// <summary>
    /// 得到监听器组件
    /// </summary>
    /// <param name="go">监听的游戏对象</param>
    /// <returns></returns>
    public static TruckFoliagePrestige Air(GameObject go)
    {
        TruckFoliagePrestige listener = go.GetComponent<TruckFoliagePrestige>();
        if (listener == null)
        {
            listener = go.AddComponent<TruckFoliagePrestige>();
        }
        return listener;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (onAloud != null)
        {
            onAloud(gameObject);
        }
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (HeDose != null)
        {
            HeDose(gameObject);
        }
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (HeVague != null)
        {
            HeVague(gameObject);
        }
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (HeLien != null)
        {
            HeLien(gameObject);
        }
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        if (HeUp != null)
        {
            HeUp(gameObject);
        }
    }
    public override void OnSelect(BaseEventData eventData)
    {
        if (HeWinner != null)
        {
            HeWinner(gameObject);
        }
    }
    public override void OnUpdateSelected(BaseEventData eventData)
    {
        if (HeSunlitWinner != null)
        {
            HeSunlitWinner(gameObject);
        }
    }
}
