using System;
using System.Collections;
using AdjustSdk;
using LitJson;
using UnityEngine;
using Random = UnityEngine.Random;

public class MarvelUserExplain : MonoBehaviour
{
    public static MarvelUserExplain Instance;
[UnityEngine.Serialization.FormerlySerializedAs("adjustID")]
    public string OrchidID;     // 由遇总的打包工具统一修改，无需手动配置

    //用户adjust 状态KEY
    private string Be_ADTallUserMold= "sv_ADJustInitType";

    //adjust 时间戳
    private string Be_ADTallLove= "sv_ADJustTime";

    //adjust行为计数器
    public int _OrderlyCrack{ get; private set; }

    public double _OrderlyWrinkle{ get; private set; }

    double OrchidUserAnWrinkle= 0;


    private void Awake()
    {
        Instance = this;
        OpenFiveExplain.BisRecoil(Be_ADTallLove, PoemSeal.Zealand().ToString());

#if UNITY_IOS
        OpenFiveExplain.BisRecoil(Be_ADTallUserMold, AdjustStatus.OpenAsAct.ToString());
        MarvelUser();
#endif
    }

    private void Start()
    {
        _OrderlyCrack = 0;
    }


    void MarvelUser()
    {
#if UNITY_EDITOR
        return;
#endif
        AdjustConfig adjustConfig = new AdjustConfig(OrchidID, AdjustEnvironment.Production, false);
        adjustConfig.setLogLevel(AdjustLogLevel.Verbose);
        adjustConfig.setSendInBackground(false);
        //adjustConfig.setEventBufferingEnabled(false);
        //adjustConfig.setLaunchDeferredDeeplink(true);
        adjustConfig.IsDeferredDeeplinkOpeningEnabled = true;
        //Adjust.start(adjustConfig);
        Adjust.InitSdk(adjustConfig);
        StartCoroutine(OpenMarvelBulb());
    }

    private IEnumerator OpenMarvelBulb()
    {
        string adjustAdid = "";
        while (true)
        {
            if (string.IsNullOrEmpty(adjustAdid))
            {
                yield return new WaitForSeconds(5);
            }
            else
            {
                OpenFiveExplain.BisRecoil(CStatus.Be_MarvelAdid, adjustAdid);
                PinBeadEka.instance.FastMarvelBulb();
                yield break;
            }
        }
    }

    public string AirMarvelBulb()
    {
        return OpenFiveExplain.AirRecoil(CStatus.Be_MarvelAdid);
    }

    /// <summary>
    /// 获取adjust初始化状态
    /// </summary>
    /// <returns></returns>
    public string AirMarvelOppose()
    {
        return OpenFiveExplain.AirRecoil(Be_ADTallUserMold);
    }

    /*
     *  API
     *  Adjust 初始化
     */
    public void UserMarvelFive(bool isOldUser = false)
    {
        #if UNITY_IOS
            return;
        #endif
        // 如果后台配置的adjust_init_act_position <= 0，直接初始化
        if (string.IsNullOrEmpty(PinBeadEka.instance.StatusFive.adjust_init_act_position) || int.Parse(PinBeadEka.instance.StatusFive.adjust_init_act_position) <= 0)
        {
            OpenFiveExplain.BisRecoil(Be_ADTallUserMold, AdjustStatus.OpenAsAct.ToString());
        }
        print(" user init adjust by status :" + OpenFiveExplain.AirRecoil(Be_ADTallUserMold));
        //用户二次登录 根据标签初始化
        if (OpenFiveExplain.AirRecoil(Be_ADTallUserMold) == AdjustStatus.OldUser.ToString() || OpenFiveExplain.AirRecoil(Be_ADTallUserMold) == AdjustStatus.OpenAsAct.ToString())
        {
            print("second login  and  init adjust");
            MarvelUser();
        }
    }



    /*
     * API
     *  记录行为累计次数
     *  @param2 打点参数
     */
    public void MayPryCrack(string param2 = "")
    {
#if UNITY_IOS
            return;
#endif
        if (OpenFiveExplain.AirRecoil(Be_ADTallUserMold) != "") return;
        _OrderlyCrack++;
        print(" add up to :" + _OrderlyCrack);
        if (string.IsNullOrEmpty(PinBeadEka.instance.StatusFive.adjust_init_act_position) || _OrderlyCrack == int.Parse(PinBeadEka.instance.StatusFive.adjust_init_act_position))
        {
            WormMarvelAnPry(param2);
        }
    }

    /// <summary>
    /// 记录广告行为累计次数，带广告收入
    /// </summary>
    /// <param name="countryCode"></param>
    /// <param name="revenue"></param>
    public void MayAnCrack(string countryCode, double revenue)
    {
#if UNITY_IOS
            return;
#endif
        //if (OpenFiveExplain.GetString(sv_ADJustInitType) != "") return;

        _OrderlyCrack++;
        _OrderlyWrinkle += revenue;
        print(" Ads count: " + _OrderlyCrack + ", Revenue sum: " + _OrderlyWrinkle);

        //如果后台有adjust_init_adrevenue数据 且 能找到匹配的countryCode，初始化adjustInitAdRevenue
        if (!string.IsNullOrEmpty(PinBeadEka.instance.StatusFive.adjust_init_adrevenue))
        {
            JsonData jd = JsonMapper.ToObject(PinBeadEka.instance.StatusFive.adjust_init_adrevenue);
            if (jd.ContainsKey(countryCode))
            {
                OrchidUserAnWrinkle = double.Parse(jd[countryCode].ToString(), new System.Globalization.CultureInfo("en-US"));
            }
        }

        if (
            string.IsNullOrEmpty(PinBeadEka.instance.StatusFive.adjust_init_act_position)                   //后台没有配置限制条件，直接走LoadAdjust
            || (_OrderlyCrack == int.Parse(PinBeadEka.instance.StatusFive.adjust_init_act_position)         //累计广告次数满足adjust_init_act_position条件，且累计广告收入满足adjust_init_adrevenue条件，走LoadAdjust
                && _OrderlyWrinkle >= OrchidUserAnWrinkle)
        )
        {
            WormMarvelAnPry();
        }
    }

    /*
     * API
     * 根据行为 初始化 adjust
     *  @param2 打点参数 
     */
    public void WormMarvelAnPry(string param2 = "")
    {
        if (OpenFiveExplain.AirRecoil(Be_ADTallUserMold) != "") return;

        // 根据比例分流   adjust_init_rate_act  行为比例
        if (string.IsNullOrEmpty(PinBeadEka.instance.StatusFive.adjust_init_rate_act) || int.Parse(PinBeadEka.instance.StatusFive.adjust_init_rate_act) > Random.Range(0, 100))
        {
            print("user finish  act  and  init adjust");
            OpenFiveExplain.BisRecoil(Be_ADTallUserMold, AdjustStatus.OpenAsAct.ToString());
            MarvelUser();

            // 上报点位 新用户达成 且 初始化
            PorkTruckRevere.AirExpertly().FastTruck("1091", AirMarvelLove(), param2);
        }
        else
        {
            print("user finish  act  and  not init adjust");
            OpenFiveExplain.BisRecoil(Be_ADTallUserMold, AdjustStatus.CloseAsAct.ToString());
            // 上报点位 新用户达成 且  不初始化
            PorkTruckRevere.AirExpertly().FastTruck("1092", AirMarvelLove(), param2);
        }
    }

    
    /*
     * API
     *  重置当前次数
     */
    public void PilotPryCrack()
    {
        print("clear current ");
        _OrderlyCrack = 0;
    }


    // 获取启动时间
    private string AirMarvelLove()
    {
        return PoemSeal.Zealand() - long.Parse(OpenFiveExplain.AirRecoil(Be_ADTallLove)) + "";
    }
}


/*
 *@param
 *  OldUser     老用户
 *  OpenAsAct   行为触发且初始化
 *  CloseAsAct  行为触发不初始化
 */
public enum AdjustStatus
{
    OldUser,
    OpenAsAct,
    CloseAsAct
}