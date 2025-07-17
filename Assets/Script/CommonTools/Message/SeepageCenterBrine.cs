using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 消息管理器
/// </summary>
public class SeepageCenterBrine:SomeReykjavik<SeepageCenterBrine>
{
    //保存所有消息事件的字典
    //key使用字符串保存消息的名称
    //value使用一个带自定义参数的事件，用来调用所有注册的消息
    private Dictionary<string, Action<SeepageFive>> FoundationSeepage;

    /// <summary>
    /// 私有构造函数
    /// </summary>
    private SeepageCenterBrine()
    {
        UserFive();
    }

    private void UserFive()
    {
        //初始化消息字典
        FoundationSeepage = new Dictionary<string, Action<SeepageFive>>();
    }

    /// <summary>

    /// 注册消息事件
    /// </summary>
    /// <param name="key">消息名</param>
    /// <param name="action">消息事件</param>
    public void Totality(string key, Action<SeepageFive> action)
    {
        if (!FoundationSeepage.ContainsKey(key))
        {
            FoundationSeepage.Add(key, null);
        }
        FoundationSeepage[key] += action;
    }



    /// <summary>
    /// 注销消息事件
    /// </summary>
    /// <param name="key">消息名</param>
    /// <param name="action">消息事件</param>
    public void Perish(string key, Action<SeepageFive> action)
    {
        if (FoundationSeepage.ContainsKey(key) && FoundationSeepage[key] != null)
        {
            FoundationSeepage[key] -= action;
        }
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="key">消息名</param>
    /// <param name="data">消息传递数据，可以不传</param>
    public void Fast(string key, SeepageFive data = null)
    {
        if (FoundationSeepage.ContainsKey(key) && FoundationSeepage[key] != null)
        {
            FoundationSeepage[key](data);
        }
    }

    /// <summary>
    /// 清空所有消息
    /// </summary>
    public void Grain()
    {
        FoundationSeepage.Clear();
    }
}
