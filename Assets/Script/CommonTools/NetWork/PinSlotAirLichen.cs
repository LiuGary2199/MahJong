/***
 * 
 * 网络请求的get对象
 * 
 * **/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PinSlotAirLichen 
{
    //get的url
    public string Tug;
    //get成功的回调
    public Action<UnityWebRequest> AirFibrous;
    //get失败的回调
    public Action AirHome;
    public PinSlotAirLichen(string url,Action<UnityWebRequest> success,Action fail)
    {
        Tug = url;
        AirFibrous = success;
        AirHome = fail;
    }
   
}
