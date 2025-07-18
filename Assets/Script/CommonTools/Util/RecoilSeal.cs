﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilSeal
{
    /// <summary>
    /// 字符串转为枚举类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="strType"></param>
    /// <returns></returns>
    public static T UpEnum<T>(string strType)
    {
        T t = (T)Enum.Parse(typeof(T), strType);
        return t;
    }
}
