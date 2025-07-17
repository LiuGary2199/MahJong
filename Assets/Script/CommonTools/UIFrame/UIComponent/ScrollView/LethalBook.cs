/**
 * 
 * 支持上下滑动的scroll view
 * 
 * **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LethalBook : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("itemCell")]    //预支单体
    public LethalBookTram MarkLeak;
[UnityEngine.Serialization.FormerlySerializedAs("scrollRect")]    //scrollview
    public ScrollRect MarshyEach;
[UnityEngine.Serialization.FormerlySerializedAs("content")]
    //content
    public RectTransform Useable;
[UnityEngine.Serialization.FormerlySerializedAs("spacing")]    //间隔
    public float Acquire= 10;
[UnityEngine.Serialization.FormerlySerializedAs("totalWidth")]    //总的宽
    public float ShinySolve;
[UnityEngine.Serialization.FormerlySerializedAs("totalHeight")]    //总的高
    public float ShinyWeight;
[UnityEngine.Serialization.FormerlySerializedAs("visibleCount")]    //可见的数量
    public int StatureCrack;
[UnityEngine.Serialization.FormerlySerializedAs("isClac")]    //初始数据完成是否检测计算
    public bool OfSave= false;
[UnityEngine.Serialization.FormerlySerializedAs("startIndex")]    //开始的索引
    public int AlarmElect;
[UnityEngine.Serialization.FormerlySerializedAs("lastIndex")]    //结尾的索引
    public int SongElect;
[UnityEngine.Serialization.FormerlySerializedAs("itemHeight")]    //item的高
    public float MarkWeight= 50;
[UnityEngine.Serialization.FormerlySerializedAs("itemList")]
    //缓存的itemlist
    public List<LethalBookTram> MarkWine;
[UnityEngine.Serialization.FormerlySerializedAs("visibleList")]    //可见的itemList
    public List<LethalBookTram> StatureWine;
[UnityEngine.Serialization.FormerlySerializedAs("allList")]    //总共的dataList
    public List<int> HimWine;

    void Start()
    {
        ShinyWeight = this.GetComponent<RectTransform>().sizeDelta.y;
        ShinySolve = this.GetComponent<RectTransform>().sizeDelta.x;
        Useable = MarshyEach.content;
        UserFive();

    }
    //初始化
    public void UserFive()
    {
        StatureCrack = Mathf.CeilToInt(ShinyWeight / SealWeight) + 1;
        for (int i = 0; i < StatureCrack; i++)
        {
            this.MayTram();
        }
        AlarmElect = 0;
        SongElect = 0;
        List<int> numberList = new List<int>();
        //数据长度
        int dataLength = 20;
        for (int i = 0; i < dataLength; i++)
        {
            numberList.Add(i);
        }
        BisFive(numberList);
    }
    //设置数据
    void BisFive(List<int> list)
    {
        HimWine = list;
        AlarmElect = 0;
        if (FiveCrack <= StatureCrack)
        {
            SongElect = FiveCrack;
        }
        else
        {
            SongElect = StatureCrack - 1;
        }
        //Debug.Log("ooooooooo"+lastIndex);
        for (int i = AlarmElect; i < SongElect; i++)
        {
            LethalBookTram obj = LadTram();
            if (obj == null)
            {
                Debug.Log("获取item为空");
            }
            else
            {
                obj.gameObject.name = i.ToString();

                obj.gameObject.SetActive(true);
                obj.transform.localPosition = new Vector3(0, -i * SealWeight, 0);
                StatureWine.Add(obj);
                SunlitTram(i, obj);
            }

        }
        Useable.sizeDelta = new Vector2(ShinySolve, FiveCrack * SealWeight - Acquire);
        OfSave = true;
    }
    //更新item
    public void SunlitTram(int index, LethalBookTram obj)
    {
        int d = HimWine[index];
        string str = d.ToString();
        obj.name = str;
        //更新数据 todo
    }
    //从itemlist中取出item
    public LethalBookTram LadTram()
    {
        LethalBookTram obj = null;
        if (MarkWine.Count > 0)
        {
            obj = MarkWine[0];
            obj.gameObject.SetActive(true);
            MarkWine.RemoveAt(0);
        }
        else
        {
            Debug.Log("从缓存中取出的是空");
        }
        return obj;
    }
    //item进入itemlist
    public void AnewTram(LethalBookTram obj)
    {
        MarkWine.Add(obj);
        obj.gameObject.SetActive(false);
    }
    public int FiveCrack    {
        get
        {
            return HimWine.Count;
        }
    }
    //每一行的高
    public float SealWeight    {
        get
        {
            return MarkWeight + Acquire;
        }
    }
    //添加item到缓存列表中
    public void MayTram()
    {
        GameObject obj = Instantiate(MarkLeak.gameObject);
        obj.transform.SetParent(Useable);
        RectTransform Deep= obj.GetComponent<RectTransform>();
        Deep.anchorMin = new Vector2(0.5f, 1);
        Deep.anchorMax = new Vector2(0.5f, 1);
        Deep.pivot = new Vector2(0.5f, 1);
        obj.SetActive(false);
        obj.transform.localScale = Vector3.one;
        LethalBookTram o = obj.GetComponent<LethalBookTram>();
        MarkWine.Add(o);
    }



    void Update()
    {
        if (OfSave)
        {
            Lethal();
        }
    }
    /// <summary>
    /// 计算滑动支持上下滑动
    /// </summary>
    void Lethal()
    {
        float vy = Useable.anchoredPosition.y;
        float rollUpTop = (AlarmElect + 1) * SealWeight;
        float rollUnderTop = AlarmElect * SealWeight;

        if (vy > rollUpTop && SongElect < FiveCrack)
        {
            //上边界移除
            if (StatureWine.Count > 0)
            {
                LethalBookTram obj = StatureWine[0];
                StatureWine.RemoveAt(0);
                AnewTram(obj);
            }
            AlarmElect++;
        }
        float rollUpBottom = (SongElect - 1) * SealWeight - Acquire;
        if (vy < rollUpBottom - ShinyWeight && AlarmElect > 0)
        {
            //下边界减少
            SongElect--;
            if (StatureWine.Count > 0)
            {
                LethalBookTram obj = StatureWine[StatureWine.Count - 1];
                StatureWine.RemoveAt(StatureWine.Count - 1);
                AnewTram(obj);
            }

        }
        float rollUnderBottom = SongElect * SealWeight - Acquire;
        if (vy > rollUnderBottom - ShinyWeight && SongElect < FiveCrack)
        {
            //Debug.Log("下边界增加"+vy);
            //下边界增加
            LethalBookTram go = LadTram();
            StatureWine.Add(go);
            go.transform.localPosition = new Vector3(0, -SongElect * SealWeight);
            SunlitTram(SongElect, go);
            SongElect++;
        }


        if (vy < rollUnderTop && AlarmElect > 0)
        {
            //Debug.Log("上边界增加"+vy);
            //上边界增加
            AlarmElect--;
            LethalBookTram go = LadTram();
            StatureWine.Insert(0, go);
            SunlitTram(AlarmElect, go);
            go.transform.localPosition = new Vector3(0, -AlarmElect * SealWeight);
        }

    }
}
