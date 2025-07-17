/***
 * 
 *    
 *           主题： 资源加载管理器      
 *    Description: 
 *           功能： 本功能是在Unity的Resources类的基础之上，增加了“缓存”的处理。
 *                  
 *   
 *    
 *   
 */
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class SubdivideEka : MonoBehaviour
{
    /* 字段 */
    private static SubdivideEka _Expertly;              //本脚本私有单例实例
    private Hashtable Of= null;                        //容器键值对集合




    /// <summary>
    /// 得到实例(单例)
    /// </summary>
    /// <returns></returns>
    public static SubdivideEka AirExpertly()
    {
        if (_Expertly == null)
        {
            _Expertly = new GameObject("_ResourceMgr").AddComponent<SubdivideEka>();
        }
        return _Expertly;
    }

    void Awake()
    {
        Of = new Hashtable();
    }

    /// <summary>
    /// 调用资源（带对象缓冲技术）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <param name="isCatch"></param>
    /// <returns></returns>
    public T WormDownward<T>(string path, bool isCatch) where T : UnityEngine.Object
    {
        if (Of.Contains(path))
        {
            return Of[path] as T;
        }

        T TResource = Resources.Load<T>(path);
        if (TResource == null)
        {
            Debug.LogError(GetType() + "/GetInstance()/TResource 提取的资源找不到，请检查。 path=" + path);
        }
        else if (isCatch)
        {
            Of.Add(path, TResource);
        }

        return TResource;
    }

    /// <summary>
    /// 调用资源（带对象缓冲技术）
    /// </summary>
    /// <param name="path"></param>
    /// <param name="isCatch"></param>
    /// <returns></returns>
    public GameObject WormMessy(string path, bool isCatch)
    {
        GameObject goObj = WormDownward<GameObject>(path, isCatch);
        GameObject goObjClone = GameObject.Instantiate<GameObject>(goObj);
        if (goObjClone == null)
        {
            Debug.LogError(GetType() + "/LoadAsset()/克隆资源不成功，请检查。 path=" + path);
        }
        return goObjClone;
    }
}