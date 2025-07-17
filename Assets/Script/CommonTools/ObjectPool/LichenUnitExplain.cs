/*
 * 
 *  管理多个对象池的管理类
 * 
 * **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LichenUnitExplain : SomeReykjavik<LichenUnitExplain>
{
    //管理objectpool的字典
    private Dictionary<string, LichenUnit> m_UnitDic;
    private Transform m_PickPresident=null;
    //构造函数
    public LichenUnitExplain()
    {
        m_UnitDic = new Dictionary<string, LichenUnit>();      
    }
    
    //创建一个新的对象池
    public T ThornyLichenUnit<T>(string poolName) where T : LichenUnit, new()
    {
        if (m_UnitDic.ContainsKey(poolName))
        {
            return m_UnitDic[poolName] as T;
        }
        if (m_PickPresident == null)
        {
            m_PickPresident = this.transform;
        }      
        GameObject obj = new GameObject(poolName);
        obj.transform.SetParent(m_PickPresident);
        T pool = new T();
        pool.User(poolName, obj.transform);
        m_UnitDic.Add(poolName, pool);
        return pool;
    }
    //取对象
    public GameObject AirScamLichen(string poolName)
    {
        if (m_UnitDic.ContainsKey(poolName))
        {
            return m_UnitDic[poolName].Air();
        }
        return null;
    }
    //回收对象
    public void CottageScamLichen(string poolName,GameObject go)
    {
        if (m_UnitDic.ContainsKey(poolName))
        {
            m_UnitDic[poolName].Cottage(go);
        }
    }
    //销毁所有的对象池
    public void OnDestroy()
    {
        m_UnitDic.Clear();
        GameObject.Destroy(m_PickPresident);
    }
    /// <summary>
    /// 查询是否有该对象池
    /// </summary>
    /// <param name="poolName"></param>
    /// <returns></returns>
    public bool GreekUnit(string poolName)
    {
        return m_UnitDic.ContainsKey(poolName) ? true : false;
    }
}
