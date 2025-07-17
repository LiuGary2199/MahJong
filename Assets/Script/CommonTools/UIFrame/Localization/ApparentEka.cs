/*
 * 
 * 多语言
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparentEka 
{
    public static ApparentEka _Chlorosis;
    //语言翻译的缓存集合
    private Dictionary<string, string> _ItsApparentChina;

    private ApparentEka()
    {
        _ItsApparentChina = new Dictionary<string, string>();
        //初始化语言缓存集合
        UserApparentChina();
    }

    /// <summary>
    /// 获取实例
    /// </summary>
    /// <returns></returns>
    public static ApparentEka AirExpertly()
    {
        if (_Chlorosis == null)
        {
            _Chlorosis = new ApparentEka();
        }
        return _Chlorosis;
    }

    /// <summary>
    /// 得到显示文本信息
    /// </summary>
    /// <param name="lauguageId">语言id</param>
    /// <returns></returns>
    public string HaleExam(string lauguageId)
    {
        string strQueryResult = string.Empty;
        if (string.IsNullOrEmpty(lauguageId)) return null;
        //查询处理
        if(_ItsApparentChina!=null && _ItsApparentChina.Count >= 1)
        {
            _ItsApparentChina.TryGetValue(lauguageId, out strQueryResult);
            if (!string.IsNullOrEmpty(strQueryResult))
            {
                return strQueryResult;
            }
        }
        Debug.Log(GetType() + "/ShowText()/ Query is Null!  Parameter lauguageID: " + lauguageId);
        return null;
    }

    /// <summary>
    /// 初始化语言缓存集合
    /// </summary>
    private void UserApparentChina()
    {
        //LauguageJSONConfig_En
        //LauguageJSONConfig
        IStatusExplain config = new StatusExplainUpMaya("LauguageJSONConfig");
        if (config != null)
        {
            _ItsApparentChina = config.SpyRadiate;
        }
    }
}
