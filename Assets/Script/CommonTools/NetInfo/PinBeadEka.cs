/***
 * 
 * 
 * 网络信息控制
 * 
 * **/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Runtime.InteropServices;
using AdjustSdk;
//using MoreMountains.NiceVibrations;

public class PinBeadEka : MonoBehaviour
{
[HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("DataFrom")]public string FiveGobi; //数据来源 打点用
    public static PinBeadEka instance;
    //请求超时时间
    private static float TIMEOUT= 3f;
[UnityEngine.Serialization.FormerlySerializedAs("BaseUrl")]    //base
    public string CoaxTug;
[UnityEngine.Serialization.FormerlySerializedAs("BaseLoginUrl")]    //登录url
    public string CoaxLaterTug;
[UnityEngine.Serialization.FormerlySerializedAs("BaseConfigUrl")]    //配置url
    public string CoaxStatusTug;
[UnityEngine.Serialization.FormerlySerializedAs("BaseTimeUrl")]    //时间戳url
    public string CoaxLoveTug;
[UnityEngine.Serialization.FormerlySerializedAs("BaseAdjustUrl")]    //更新AdjustId url
    public string CoaxMarvelTug;
[UnityEngine.Serialization.FormerlySerializedAs("GameCode")]    //后台gamecode
    public string ScamCode= "20000";
[UnityEngine.Serialization.FormerlySerializedAs("Channel")]
    //channel渠道平台
#if UNITY_IOS
    public string Survive= "IOS";
#elif UNITY_ANDROID
    public string Channel = "GooglePlay";
#else
    public string Channel = "Other";
#endif
    //工程包名
    private string ExplodeBoat{ get { return Application.identifier; } }
    //登录url
    private string LaterTug= "";
    //配置url
    private string ConfigTug= "";
    //更新AdjustId url
    private string MarvelTug= "";
[UnityEngine.Serialization.FormerlySerializedAs("country")]    //国家
    public string Slender= "";
[UnityEngine.Serialization.FormerlySerializedAs("ConfigData")]    //服务器Config数据
    public BreezeFive StatusFive;
[UnityEngine.Serialization.FormerlySerializedAs("GameData")]    public GameData ScamFive;
[UnityEngine.Serialization.FormerlySerializedAs("InitData")]    //游戏内数据
    public Init UserFive;
[UnityEngine.Serialization.FormerlySerializedAs("adManager")]    //ADExplain
    public GameObject ItExplain;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("gaid")]    public string Link;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("aid")]    public string Cud;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("idfa")]    public string Rely;
    int Shaft_Burin= 0;
[UnityEngine.Serialization.FormerlySerializedAs("ready")]    public bool Shaft= false;
    //ios 获取idfa函数声明
#if UNITY_IOS
    [DllImport("__Internal")]
    internal extern static void getIDFA();
#endif
    void Awake()
    {
        instance = this;
        LaterTug = CoaxLaterTug + ScamCode + "&channel=" + Survive + "&version=" + Application.version;
        ConfigTug = CoaxStatusTug + ScamCode + "&channel=" + Survive + "&version=" + Application.version;
        MarvelTug = CoaxMarvelTug + ScamCode;
    }
    private void Start()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass aj = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject p = aj.GetStatic<AndroidJavaObject>("currentActivity");
            p.Call("getGaid");
            p.Call("getAid");

        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
#if UNITY_IOS
            getIDFA();
            string idfv = UnityEngine.iOS.Device.vendorIdentifier;
            OpenFiveExplain.BisRecoil("idfv", idfv);
#endif
        }
        else
        {
            Later();           //编辑器登录
        }
        //获取config数据
        AirStatusFive();
    }

    /// <summary>
    /// 获取gaid回调
    /// </summary>
    /// <param name="gaid_str"></param>
    public void LinkSoften(string gaid_str)
    {
        Debug.Log("unity收到gaid：" + gaid_str);
        Link = gaid_str; 
        if (Link == null || Link == "")
        {
            Link = OpenFiveExplain.AirRecoil("gaid");
        }
        else
        {
            OpenFiveExplain.BisRecoil("gaid", Link);
        }
        Shaft_Burin++;
        if (Shaft_Burin == 2)
        {
            Later();
        }
    }
    /// <summary>
    /// 获取aid回调
    /// </summary>
    /// <param name="aid_str"></param>
    public void CudSoften(string aid_str)
    {
        Debug.Log("unity收到aid：" + aid_str);
        Cud = aid_str;
        if (Cud == null || Cud == "")
        {
            Cud = OpenFiveExplain.AirRecoil("aid");
        }
        else
        {
            OpenFiveExplain.BisRecoil("aid", Cud);
        }
        Shaft_Burin++;
        if (Shaft_Burin == 2)
        {
            Later();
        }
    }
    /// <summary>
    /// 获取idfa成功
    /// </summary>
    /// <param name="message"></param>
    public void RelyFibrous(string message)
    {
        Debug.Log("idfa success:" + message);
        Rely = message;
        OpenFiveExplain.BisRecoil("idfa", Rely);
        Later();
    }
    /// <summary>
    /// 获取idfa失败
    /// </summary>
    /// <param name="message"></param>
    public void RelyHome(string message)
    {
        Debug.Log("idfa fail");
        Rely = OpenFiveExplain.AirRecoil("idfa");
        Later();
    }
    /// <summary>
    /// 登录
    /// </summary>
    public void Later()
    {
        CashOutManager.AirExpertly().Login();
        //获取本地缓存的Local用户ID
        string localId = OpenFiveExplain.AirRecoil(CStatus.Be_CrossShipOn);

        //没有用户ID，视为新用户，生成用户ID
        if (localId == "" || localId.Length == 0)
        {
            //生成用户随机id
            TimeSpan st = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
            string timeStr = Convert.ToInt64(st.TotalSeconds).ToString() + UnityEngine.Random.Range(0, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString();
            localId = timeStr;
            OpenFiveExplain.BisRecoil(CStatus.Be_CrossShipOn, localId);
        }

        //拼接登录接口参数
        string url = "";
        if (Application.platform == RuntimePlatform.IPhonePlayer)       //一个参数 - iOS
        {
            url = LaterTug + "&" + "randomKey" + "=" + localId + "&idfa=" + Rely + "&packageName=" + ExplodeBoat;
        }
        else if (Application.platform == RuntimePlatform.Android)  //两个参数 - Android
        {
            url = LaterTug + "&" + "randomKey" + "=" + localId + "&gaid=" + Link + "&androidId=" + Cud + "&packageName=" + ExplodeBoat;
        }
        else //编辑器
        {
            url = LaterTug + "&" + "randomKey" + "=" + localId + "&packageName=" + ExplodeBoat;
        }

        //获取国家信息
        WokHistory(() => {
            url += "&country=" + Slender;
            //登录请求
            PinSlotExplain.AirExpertly().HereAir(url,
                (data) => {
                    Debug.Log("Login 成功" + data.downloadHandler.text);
                    OpenFiveExplain.BisRecoil("init_time", DateTime.Now.ToString());
                    ServerUserData serverUserData = JsonMapper.ToObject<ServerUserData>(data.downloadHandler.text);
                    OpenFiveExplain.BisRecoil(CStatus.Be_CrossBreezeOn, serverUserData.data.ToString());

                    FastMarvelBulb();
                },
                () => {
                    Debug.Log("Login 失败");
                });
        });
    }
    /// <summary>
    /// 获取国家
    /// </summary>
    /// <param name="cb"></param>
    private void WokHistory(Action cb)
    {
        bool callBackReady = false;
        if (String.IsNullOrEmpty(Slender))
        {
            //获取国家超时返回
            StartCoroutine(PinSlotLoveFad(() =>
            {
                if (!callBackReady)
                {
                    Slender = "";
                    callBackReady = true;
                    cb?.Invoke();
                }
            }));
            PinSlotExplain.AirExpertly().HereAir("https://a.mafiagameglobal.com/event/country/", (data) =>
            {
                Slender = JsonMapper.ToObject<Dictionary<string, string>>(data.downloadHandler.text)["country"];
                Debug.Log("获取国家 成功:" + Slender);
                if (!callBackReady)
                {
                    callBackReady = true;
                    cb?.Invoke();
                }
            },
            () => {
                Debug.Log("获取国家 失败");
                if (!callBackReady)
                {
                    Slender = "";
                    callBackReady = true;
                    cb?.Invoke();
                }
            });
        }
        else
        {
            if (!callBackReady)
            {
                callBackReady = true;
                cb?.Invoke();
            }
        }
    }

    /// <summary>
    /// 获取服务器Config数据
    /// </summary>
    private void AirStatusFive()
    {
        Debug.Log("GetConfigData:" + ConfigTug);
        StartCoroutine(PinSlotLoveFad(() =>
        {
            AirProposalFive();
        }));

        //获取并存入Config
        PinSlotExplain.AirExpertly().HereAir(ConfigTug,
        (data) => {
            FiveGobi = "OnlineData";
            Debug.Log("ConfigData 成功" + data.downloadHandler.text);
            OpenFiveExplain.BisRecoil("OnlineData", data.downloadHandler.text);
            BisStatusFive(data.downloadHandler.text);
        },
        () => {
            AirProposalFive();
            Debug.Log("ConfigData 失败");
        });
    }

    /// <summary>
    /// 获取本地Config数据
    /// </summary>
    private void AirProposalFive()
    {
        //是否有缓存
        if (OpenFiveExplain.AirRecoil("OnlineData") == "" || OpenFiveExplain.AirRecoil("OnlineData").Length == 0)
        {
            Debug.Log("本地数据");
            FiveGobi = "LocalData_Updated"; //已联网更新过的数据
            TextAsset json = Resources.Load<TextAsset>("LocationJson/LocationData");
            BisStatusFive(json.text);
        }
        else
        {
            FiveGobi = "LocalData_Original"; //原始数据
            Debug.Log("服务器缓存数据");
            BisStatusFive(OpenFiveExplain.AirRecoil("OnlineData"));
        }
    }


    /// <summary>
    /// 解析config数据
    /// </summary>
    /// <param name="configJson"></param>
    void BisStatusFive(string configJson)
    {
        //如果已经获得了数据则不再处理
        if (StatusFive == null)
        {
            RootData rootData = JsonMapper.ToObject<RootData>(configJson);
            StatusFive = rootData.data;
            UserFive = JsonMapper.ToObject<Init>(StatusFive.init);
            ScamFive = JsonMapper.ToObject<GameData>(StatusFive.game_data);
            AirShipBead();
        }
    }
    /// <summary>
    /// 进入游戏
    /// </summary>
    void ScamTally()
    {
        //打开admanager
        ItExplain.SetActive(true);
        //进度条可以继续
        Shaft = true;
    }



    /// <summary>
    /// 超时处理
    /// </summary>
    /// <param name="finish"></param>
    /// <returns></returns>
    IEnumerator PinSlotLoveFad(Action finish)
    {
        yield return new WaitForSeconds(TIMEOUT);
        finish();
    }

    /// <summary>
    /// 向后台发送adjustId
    /// </summary>
    public void FastMarvelBulb()
    {
        string serverId = OpenFiveExplain.AirRecoil(CStatus.Be_CrossBreezeOn);
        string adjustId = MarvelUserExplain.Instance.AirMarvelBulb();
        if (string.IsNullOrEmpty(serverId) || string.IsNullOrEmpty(adjustId))
        {
            return;
        }

        string url = MarvelTug + "&serverId=" + serverId + "&adid=" + adjustId;
        PinSlotExplain.AirExpertly().HereAir(url,
            (data) => {
                Debug.Log("服务器更新adjust adid 成功" + data.downloadHandler.text);
            },
            () => {
                Debug.Log("服务器更新adjust adid 失败");
            });
        CashOutManager.AirExpertly().ReportAdjustID();
    }
    //轮询检查Adjust归因信息
    int CloseCrack= 0;
    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("Event_TrackerName")]public string Truck_IngoingBoat; //打点用参数
    bool _CloseNo= false;
    [HideInInspector]
    public bool MarvelIngoing_Tally    {
        get
        {
            if (Application.isEditor) //编译器跳过检查
                return true;
            return _CloseNo;
        }
    }
    public void CloseMarvelMacaque() //检查Adjust归因信息
    {
        if (Application.isEditor) //编译器跳过检查
            return;
        if (!string.IsNullOrEmpty(Truck_IngoingBoat)) //已经拿到归因信息
            return;

        CancelInvoke(nameof(CloseMarvelMacaque));
        if (!string.IsNullOrEmpty(StatusFive.fall_down) && StatusFive.fall_down == "fall")
        {
            print("Adjust 无归因相关配置或未联网 跳过检查");
            _CloseNo = true;
        }
        try
        {
            Adjust.GetAttribution((info) =>
            {
                print("Adjust 获取信息成功 归因渠道：" + info.TrackerName);
                Truck_IngoingBoat = "TrackerName: " + info.TrackerName;
                StrikeUtil.Marvel_IngoingBoat = info.TrackerName;
                _CloseNo = true;
            });
        }
        catch (System.Exception e)
        {
            CloseCrack++;
            Debug.Log("Adjust 获取信息失败：" + e.Message + " 重试次数：" + CloseCrack);
            if (CloseCrack >= 10)
                _CloseNo = true;
            Invoke(nameof(CloseMarvelMacaque), 1);
        }
    }
[UnityEngine.Serialization.FormerlySerializedAs("UserDataStr")]
    //获取用户信息
    public string ShipFiveStr= "";
[UnityEngine.Serialization.FormerlySerializedAs("UserData")]    public UserInfoData ShipFive;
    int AirShipBeadCrack= 0;
    void AirShipBead()
    {
        //还有进入正常模式的可能
        if (PlayerPrefs.HasKey("OtherChance") && PlayerPrefs.GetString("OtherChance") == "YES") 
            PlayerPrefs.DeleteKey("Save_AP");
        //已经记录过用户信息 跳过检查
        if (PlayerPrefs.HasKey("OtherChance") && PlayerPrefs.GetString("OtherChance") == "NO")
        {
            ScamTally();
            return;
        }

        //检查归因渠道信息
        CloseMarvelMacaque();
        //获取用户信息
        string CheckUrl = CoaxTug + "/api/client/user/checkUser";
        PinSlotExplain.AirExpertly().HereAir(CheckUrl,
        (data) =>
        {
            ShipFiveStr = data.downloadHandler.text;
            print("+++++ 获取用户数据 成功" + ShipFiveStr);
            UserRootData rootData = JsonMapper.ToObject<UserRootData>(ShipFiveStr);
            ShipFive = JsonMapper.ToObject<UserInfoData>(rootData.data);
            if (ShipFiveStr.Contains("apple")
            || ShipFiveStr.Contains("Apple")
            || ShipFiveStr.Contains("APPLE"))
                ShipFive.IsHaveApple = true;
            AirShipBead();
        }, () => { });
        Invoke(nameof(IfAirShipBead), 1);
    }
    void IfAirShipBead()
    {
        if (!Shaft)
        {
            AirShipBeadCrack++;
            if (AirShipBeadCrack < 10)
            {
                print("+++++ 获取用户数据失败 重试： " + AirShipBeadCrack);
                AirShipBead();
            }
            else
            {
                print("+++++ 获取用户数据 失败次数过多，放弃");
                ScamTally();
            }
        }
    }

}
