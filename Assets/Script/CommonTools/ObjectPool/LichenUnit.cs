/*
 *   管理对象的池子
 * 
 * **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LichenUnit 
{
    private Queue<GameObject> m_UnitChain;
    //池子名称
    private string m_UnitBoat;
    //父物体
    protected Transform m_Slight;
    //缓存对象的预制体
    private GameObject Border;
    //最大容量
    private int m_RotCrack;
    //默认最大容量
    protected const int m_OverseaRotCrack= 20;
    public GameObject Simply    {
        get => Border;set { Border = value;  }
    }
    //构造函数初始化
    public LichenUnit()
    {
        m_RotCrack = m_OverseaRotCrack;
        m_UnitChain = new Queue<GameObject>();
    }
    //初始化
    public virtual void User(string poolName,Transform transform)
    {
        m_UnitBoat = poolName;
        m_Slight = transform;
    }
    //取对象
    public virtual GameObject Air()
    {
        GameObject obj;
        if (m_UnitChain.Count > 0)
        {
            obj = m_UnitChain.Dequeue();
        }
        else
        {
            obj = GameObject.Instantiate<GameObject>(Border);
            obj.transform.SetParent(m_Slight);
            obj.SetActive(false);
        }
        obj.SetActive(true);
        return obj;
    }
    //回收对象
    public virtual void Cottage(GameObject obj)
    {
        if (m_UnitChain.Contains(obj)) return;
        if (m_UnitChain.Count >= m_RotCrack)
        {
            GameObject.Destroy(obj);
        }
        else
        {
            m_UnitChain.Enqueue(obj);
            obj.SetActive(false);
        }
    }
    /// <summary>
    /// 回收所有激活的对象
    /// </summary>
    public virtual void CottageAie()
    {
        Transform[] child = m_Slight.GetComponentsInChildren<Transform>();
        foreach (Transform item in child)
        {
            if (item == m_Slight)
            {
                continue;
            }
            
            if (item.gameObject.activeSelf)
            {
                Cottage(item.gameObject);
            }
        }
    }
    //销毁
    public virtual void Surgeon()
    {
        m_UnitChain.Clear();
    }
}
