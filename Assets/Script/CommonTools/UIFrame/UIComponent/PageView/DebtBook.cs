/**
 * 
 * 左右滑动的页面视图
 * 
 * ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class DebtBook : MonoBehaviour,IBeginDragHandler,IEndDragHandler
{
[UnityEngine.Serialization.FormerlySerializedAs("rect")]    //scrollview
    public ScrollRect Deep;
    //求出每页的临界角，页索引从0开始
    List<float> NutWine= new List<float>();
[UnityEngine.Serialization.FormerlySerializedAs("isDrag")]    //是否拖拽结束
    public bool OfPost= false;
    bool SlopMove= true;
    //滑动的起始坐标  
    float MasterIridescent= 0;
    float AlarmPostIridescent;
    float startTime = 0f;
[UnityEngine.Serialization.FormerlySerializedAs("smooting")]    //滑动速度  
    public float Northern= 1f;
[UnityEngine.Serialization.FormerlySerializedAs("sensitivity")]    public float Pointillist= 0.3f;
[UnityEngine.Serialization.FormerlySerializedAs("OnPageChange")]    //页面改变
    public Action<int> AnDebtParent;
    //当前页面下标
    int OrderlyDebtElect= -1;
    void Start()
    {
        Deep = this.GetComponent<ScrollRect>();
        float horizontalLength = Deep.content.rect.width - this.GetComponent<RectTransform>().rect.width;
        NutWine.Add(0);
        for(int i = 1; i < Deep.content.childCount - 1; i++)
        {
            NutWine.Add(GetComponent<RectTransform>().rect.width * i / horizontalLength);
        }
        NutWine.Add(1);
    }

    
    void Update()
    {
        if(!OfPost && !SlopMove)
        {
            startTime += Time.deltaTime;
            float t = startTime * Northern;
            Deep.horizontalNormalizedPosition = Mathf.Lerp(Deep.horizontalNormalizedPosition, MasterIridescent, t);
            if (t >= 1)
            {
                SlopMove = true;
            }
        }
        
    }
    /// <summary>
    /// 设置页面的index下标
    /// </summary>
    /// <param name="index"></param>
    void BisDebtElect(int index)
    {
        if (OrderlyDebtElect != index)
        {
            OrderlyDebtElect = index;
            if (AnDebtParent != null)
            {
                AnDebtParent(index);
            }
        }
    }
    /// <summary>
    /// 开始拖拽
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        OfPost = true;
        AlarmPostIridescent = Deep.horizontalNormalizedPosition;
    }
    /// <summary>
    /// 拖拽结束
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        float posX = Deep.horizontalNormalizedPosition;
        posX += ((posX - AlarmPostIridescent) * Pointillist);
        posX = posX < 1 ? posX : 1;
        posX = posX > 0 ? posX : 0;
        int index = 0;
        float offset = Mathf.Abs(NutWine[index] - posX);
        for(int i = 0; i < NutWine.Count; i++)
        {
            float temp = Mathf.Abs(NutWine[i] - posX);
            if (temp < offset)
            {
                index = i;
                offset = temp;
            }
        }
        BisDebtElect(index);
        MasterIridescent = NutWine[index];
        OfPost = false;
        startTime = 0f;
        SlopMove = false;
    }
}
