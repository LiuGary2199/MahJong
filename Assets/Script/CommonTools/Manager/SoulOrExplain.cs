using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SoulOrExplain : MonoBehaviour
{
    public static SoulOrExplain instance;

#if UNITY_IOS
    [DllImport("__Internal")]
    internal extern static void openRateUsUrl(string appId);
#endif
    [UnityEngine.Serialization.FormerlySerializedAs("appid")]    //获取IOS函数声明
    public string Deity;

    private void Awake()
    {
        instance = this;
    }

    public void LiftAPPigWeekly()
    {
#if UNITY_ANDROID
        Application.OpenURL("market://details?id=" + appid);
#elif UNITY_IOS
        openRateUsUrl(Deity);
#endif
    }
}
