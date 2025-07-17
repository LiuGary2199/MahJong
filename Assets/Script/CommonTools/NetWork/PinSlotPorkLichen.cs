/**
 * 
 * 网络请求的post对象
 * 
 * ***/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PinSlotPorkLichen 
{
    //post请求地址
    public string URL;
    //post的数据表单
    public WWWForm Fine;
    //post成功回调
    public Action<UnityWebRequest> PorkFibrous;
    //post失败回调
    public Action PorkHome;
    public PinSlotPorkLichen(string url,WWWForm  form,Action<UnityWebRequest> success,Action fail)
    {
        URL = url;
        Fine = form;
        PorkFibrous = success;
        PorkHome = fail;
    }
}
