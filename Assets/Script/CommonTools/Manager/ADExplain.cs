using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using AdjustSdk;
using LitJson;
using DG.Tweening;
using Unity.VisualScripting;

public class ADExplain : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("MAX_SDK_KEY")]    public string MAX_SDK_KEY= "";
[UnityEngine.Serialization.FormerlySerializedAs("MAX_REWARD_ID")]    public string MAX_REWARD_ID= "";
[UnityEngine.Serialization.FormerlySerializedAs("MAX_INTER_ID")]    public string MAX_INTER_ID= "";
[UnityEngine.Serialization.FormerlySerializedAs("isTest")]
    public bool OfDash= false;
    public static ADExplain Expertly{ get; private set; }

    private int ToothTrigger;   // 广告加载失败后，重新加载广告次数
    private bool OfMagnifyAn;     // 是否正在播放广告，用于判断切换前后台时是否增加计数

    public int SongEpicLoveImagist{ get; private set; }   // 距离上次广告的时间间隔
    public int Rainbow101{ get; private set; }     // 定时插屏(101)计数器
    public int Rainbow102{ get; private set; }     // NoThanks插屏(102)计数器
    public int Rainbow103{ get; private set; }     // 后台回前台插屏(103)计数器

    private string HungryMacaqueBoat;
    private Action<bool> HungryReedBackSoften;    // 激励视频回调
    private bool HungryFibrous;     // 激励视频是否成功收到奖励
    private string HungryElect;     // 激励视频的打点

    private string UnsuccessfulMacaqueBoat;
    private int UnsuccessfulMold;      // 当前播放的插屏类型，101/102/103
    private string UnsuccessfulElect;     // 插屏广告的的打点
    public bool SnowyLoveInterference{ get; private set; } // 定时插屏暂停播放

    private List<Action<ADType>> ItPotteryCopyright;    // 广告播放完成回调列表，用于其他系统广告计数（例如商店看广告任务）

    private long ScandinaviaSieveSomewhere;     // 切后台时的时间戳
    private Ad_CustomData TorporAnMirageFive; //激励视频自定义数据
    private Ad_CustomData InterferenceAnMirageFive; //插屏自定义数据
    private double InterferenceCultivate= 0;
    private void Awake()
    {
        Expertly = this;
    }

    private void OnEnable()
    {
        SnowyLoveInterference = false;
        OfMagnifyAn = false;
        SongEpicLoveImagist = 999;  // 初始时设置一个较大的值，不阻塞插屏广告
        HungryFibrous = false;

        // Android平台将Adjust的adid传给Max；iOS将randomKey传给Max
#if UNITY_ANDROID
        MaxSdk.SetSdkKey(AirWorthyFive.DecryptDES(MAX_SDK_KEY));
        // 将adjust id 传给Max
        string adjustId = OpenFiveExplain.GetString(CStatus.sv_AdjustAdid);
        if (string.IsNullOrEmpty(adjustId))
        {
            adjustId = Adjust.getAdid();
        }
        if (!string.IsNullOrEmpty(adjustId))
        {
            MaxSdk.SetUserId(adjustId);
            MaxSdk.InitializeSdk();
            OpenFiveExplain.SetString(CStatus.sv_AdjustAdid, adjustId);
        }
        else
        {
            StartCoroutine(setAdjustAdid());
        }
#else
        MaxSdk.SetSdkKey(AirWorthyFive.LearnerDES(MAX_SDK_KEY));
        MaxSdk.SetUserId(OpenFiveExplain.AirRecoil(CStatus.Be_CrossShipOn));
        MaxSdk.InitializeSdk();
#endif

        MaxSdkCallbacks.OnSdkInitializedEvent += (MaxSdkBase.SdkConfiguration sdkConfiguration) =>
        {
            // 打开调试模式
            //MaxSdk.ShowMediationDebugger();

            SynonymousCatalystRye();
            MaxSdk.SetCreativeDebuggerEnabled(true);

            // 每秒执行一次计数
            InvokeRepeating(nameof(RepeatMethod), 1, 1);
        };
    }

    IEnumerator SkiMarvelBulb()
    {
        int i = 0;
        string adjustId = "";
        while (i < 5)
        {
            yield return new WaitForSeconds(1);
            if (StrikeUtil.WeArmory())
            {
                MaxSdk.SetUserId(OpenFiveExplain.AirRecoil(CStatus.Be_CrossShipOn));
                MaxSdk.InitializeSdk();
                yield break;
            }
            else
            {
                Adjust.GetAdid((adid) =>
                {
                    adjustId = adid;
                  
                });
                if (!string.IsNullOrEmpty(adjustId))
                {
                    print("adid: " + adjustId);
                    MaxSdk.SetUserId(adjustId);
                    MaxSdk.InitializeSdk();
                    OpenFiveExplain.BisRecoil(CStatus.Be_MarvelAdid, adjustId);
                    yield break;
                }
            }
            i++;
        }
        if (i == 5)
        {
            MaxSdk.SetUserId(OpenFiveExplain.AirRecoil(CStatus.Be_CrossShipOn));
            MaxSdk.InitializeSdk();
        }
    }

    public void SynonymousCatalystRye()
    {
        // Attach callback
        MaxSdkCallbacks.Rewarded.OnAdLoadedEvent += OnRewardedAdLoadedEvent;
        MaxSdkCallbacks.Rewarded.OnAdLoadFailedEvent += OnRewardedAdLoadFailedEvent;
        MaxSdkCallbacks.Rewarded.OnAdDisplayedEvent += OnRewardedAdDisplayedEvent;
        MaxSdkCallbacks.Rewarded.OnAdClickedEvent += OnRewardedAdClickedEvent;
        MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += OnRewardedAdRevenuePaidEvent;
        MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += OnRewardedAdHiddenEvent;
        MaxSdkCallbacks.Rewarded.OnAdDisplayFailedEvent += OnRewardedAdFailedToDisplayEvent;
        MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += OnRewardedAdReceivedRewardEvent;

        MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoadedEvent;
        MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialLoadFailedEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent += OnInterstitialDisplayedEvent;
        MaxSdkCallbacks.Interstitial.OnAdClickedEvent += OnInterstitialClickedEvent;
        MaxSdkCallbacks.Interstitial.OnAdRevenuePaidEvent += OnInterstitialRevenuePaidEvent;
        MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialHiddenEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += OnInterstitialAdFailedToDisplayEvent;

        // Load the first rewarded ad
        WormCatalystAn();

        // Load the first interstitial
        WormInterference();
    }

    private void WormCatalystAn()
    {
        MaxSdk.LoadRewardedAd(MAX_REWARD_ID);
    }

    private void WormInterference()
    {
        MaxSdk.LoadInterstitial(MAX_INTER_ID);
    }

    private void OnRewardedAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad is ready for you to show. MaxSdk.IsRewardedAdReady(adUnitId) now returns 'true'.

        // Reset retry attempt
        ToothTrigger = 0;
        HungryMacaqueBoat = adInfo.NetworkName;

        TorporAnMirageFive = new Ad_CustomData();
        TorporAnMirageFive.user_id = CashOutManager.AirExpertly().Data.UserID;
        TorporAnMirageFive.version = Application.version;
        TorporAnMirageFive.request_id = CashOutManager.AirExpertly().EcpmRequestID();
        TorporAnMirageFive.vendor = adInfo.NetworkName;
    }

    private void OnRewardedAdLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Rewarded ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds).

        ToothTrigger++;
        double retryDelay = Math.Pow(2, Math.Min(6, ToothTrigger));

        Invoke(nameof(WormCatalystAn), (float)retryDelay);
    }

    private void OnRewardedAdDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
#if UNITY_IOS
        ExertEka.AirExpertly().ByExertConvex = !ExertEka.AirExpertly().ByExertConvex;
        Time.timeScale = 0;
#endif
    }

    private void OnRewardedAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad failed to display. AppLovin recommends that you load the next ad.
        WormCatalystAn();
        OfMagnifyAn = false;
    }

    private void OnRewardedAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {

    }

    private void OnRewardedAdHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad is hidden. Pre-load the next ad
#if UNITY_IOS
        Time.timeScale = 1;
        ExertEka.AirExpertly().ByExertConvex = !ExertEka.AirExpertly().ByExertConvex;
#endif

        OfMagnifyAn = false;
        WormCatalystAn();
        if (HungryFibrous)
        {
            HungryFibrous = false;
            HungryReedBackSoften?.Invoke(true);

            ToxicAnEpicFibrous(ADType.Rewarded);
            PorkTruckRevere.AirExpertly().FastTruck("9007", HungryElect);
        }
        else
        {
            EvokeExplain.AirExpertly().HaleEvoke("No ads right now, please try it later.");
            HungryReedBackSoften?.Invoke(false);
        }

        // 上报ecpm
        CashOutManager.AirExpertly().ReportEcpm(adInfo, TorporAnMirageFive.request_id, "REWARD");
    }

    private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdk.Reward reward, MaxSdkBase.AdInfo adInfo)
    {
        // The rewarded ad displayed and the user should receive the reward.
        HungryFibrous = true;
    }

    private void OnRewardedAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo info)
    {
        // Ad revenue paid. Use this callback to track user revenue.
        //从MAX获取收入数据
        var adRevenue = new AdjustAdRevenue(AdjustConfig.AdjustAdRevenueSourceAppLovinMAX);
        adRevenue.SetRevenue(info.Revenue, "USD");
        adRevenue.setAdRevenueNetwork(info.NetworkName);
        adRevenue.setAdRevenueUnit(info.AdUnitIdentifier);
        adRevenue.setAdRevenuePlacement(info.Placement);

        //发回收入数据给自己后台
        string countryCodeByMAX = MaxSdk.GetSdkConfiguration().CountryCode; // "US" for the United States, etc - Note: Do not confuse this with currency code which is "USD"
        PorkTruckRevere.AirExpertly().FastTruck("9008", info.Revenue.ToString(), countryCodeByMAX);

        //带广告收入的漏传策略
        MarvelUserExplain.Instance.MayAnCrack(countryCodeByMAX, info.Revenue);

        string adjustAdid = MarvelUserExplain.Instance.AirMarvelBulb();
        //发回收入数据给Adjust
        if (!string.IsNullOrEmpty(adjustAdid))
        {
            Adjust.TrackAdRevenue(adRevenue);
            UnityEngine.Debug.Log("Max to Adjust (rewarded), adUnitId:" + adUnitId + ", revenue:" + info.Revenue + ", network:" + info.NetworkName + ", unit:" + info.AdUnitIdentifier + ", placement:" + info.Placement);
        }

        // 发回收入数据给Mintegral
        if (!string.IsNullOrEmpty(adjustAdid))
        {
#if UNITY_ANDROID || UNITY_IOS
            MBridgeRevenueParamsEntity mBridgeRevenueParamsEntity = new MBridgeRevenueParamsEntity(MBridgeRevenueParamsEntity.ATTRIBUTION_PLATFORM_ADJUST, adjustAdid);
            ///MaxSdkBase.AdInfo类型的adInfo
            //mBridgeRevenueParamsEntity.SetMaxAdInfo(info);
            MBridgeRevenueManager.Track(mBridgeRevenueParamsEntity);
            UnityEngine.Debug.Log(nameof(MBridgeRevenueManager) + "~Rewarded revenue:" + info.Revenue);
#endif
        }
    }

    private void OnInterstitialLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is ready for you to show. MaxSdk.IsInterstitialReady(adUnitId) now returns 'true'

        // Reset retry attempt
        ToothTrigger = 0;
        UnsuccessfulMacaqueBoat = adInfo.NetworkName;

        InterferenceAnMirageFive = new Ad_CustomData();
        InterferenceAnMirageFive.user_id = CashOutManager.AirExpertly().Data.UserID;
        InterferenceAnMirageFive.version = Application.version;
        InterferenceAnMirageFive.request_id = CashOutManager.AirExpertly().EcpmRequestID();
        InterferenceAnMirageFive.vendor = adInfo.NetworkName;
    }

    private void OnInterstitialLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Interstitial ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds)

        ToothTrigger++;
        double retryDelay = Math.Pow(2, Math.Min(6, ToothTrigger));

        Invoke(nameof(WormInterference), (float)retryDelay);
    }

    private void OnInterstitialDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
#if UNITY_IOS
        ExertEka.AirExpertly().ByExertConvex = !ExertEka.AirExpertly().ByExertConvex;
        Time.timeScale = 0;
#endif
    }

    private void OnInterstitialAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad failed to display. AppLovin recommends that you load the next ad.
        WormInterference();
        OfMagnifyAn = false;
    }

    private void OnInterstitialClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) { }

    private void OnInterstitialRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo info)
    {
        //从MAX获取收入数据
        var adRevenue = new AdjustAdRevenue(AdjustConfig.AdjustAdRevenueSourceAppLovinMAX);
        adRevenue.SetRevenue(info.Revenue, "USD");
        adRevenue.setAdRevenueNetwork(info.NetworkName);
        adRevenue.setAdRevenueUnit(info.AdUnitIdentifier);
        adRevenue.setAdRevenuePlacement(info.Placement);

        //发回收入数据给自己后台
        string countryCodeByMAX = MaxSdk.GetSdkConfiguration().CountryCode; // "US" for the United States, etc - Note: Do not confuse this with currency code which is "USD"
        PorkTruckRevere.AirExpertly().FastTruck("9108", info.Revenue.ToString(), countryCodeByMAX);

        //带广告收入的漏传策略
        MarvelUserExplain.Instance.MayAnCrack(countryCodeByMAX, info.Revenue);

        //发回收入数据给Adjust
        if (!string.IsNullOrEmpty(MarvelUserExplain.Instance.AirMarvelBulb()))
        {
            Adjust.TrackAdRevenue(adRevenue);
            UnityEngine.Debug.Log("Max to Adjust (interstitial), adUnitId:" + adUnitId + ", revenue:" + info.Revenue + ", network:" + info.NetworkName + ", unit:" + info.AdUnitIdentifier + ", placement:" + info.Placement);
        }

        // 发回收入数据给Mintegral
        string adjustAdid = MarvelUserExplain.Instance.AirMarvelBulb();
        if (!string.IsNullOrEmpty(adjustAdid))
        {
#if UNITY_ANDROID || UNITY_IOS
            MBridgeRevenueParamsEntity mBridgeRevenueParamsEntity = new MBridgeRevenueParamsEntity(MBridgeRevenueParamsEntity.ATTRIBUTION_PLATFORM_ADJUST, adjustAdid);
            ///MaxSdkBase.AdInfo类型的adInfo
            //mBridgeRevenueParamsEntity.SetMaxAdInfo(info);
            MBridgeRevenueManager.Track(mBridgeRevenueParamsEntity);
            UnityEngine.Debug.Log(nameof(MBridgeRevenueManager) + "~Interstitial revenue:" + info.Revenue);
#endif
        }
    }

    private void OnInterstitialHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is hidden. Pre-load the next ad.
#if UNITY_IOS
        Time.timeScale = 1;
        ExertEka.AirExpertly().ByExertConvex = !ExertEka.AirExpertly().ByExertConvex;
#endif
        WormInterference();

        ToxicAnEpicFibrous(ADType.Interstitial);
        PorkTruckRevere.AirExpertly().FastTruck("9107", UnsuccessfulElect);
        // 上报ecpm
        CashOutManager.AirExpertly().ReportEcpm(adInfo, InterferenceAnMirageFive.request_id, "INTER");
    }


    /// <summary>
    /// 播放激励视频广告
    /// </summary>
    /// <param name="callBack"></param>
    /// <param name="index"></param>
    public void FoilTorporWeary(Action<bool> callBack, string index)
    {
        if (OfDash)
        {
            callBack(true);
            ToxicAnEpicFibrous(ADType.Rewarded);
            return;
        }

        bool rewardVideoReady = MaxSdk.IsRewardedAdReady(MAX_REWARD_ID);
        HungryReedBackSoften = callBack;
        if (rewardVideoReady)
        {
            // 打点
            HungryElect = index;
            PorkTruckRevere.AirExpertly().FastTruck("9002", index);
            OfMagnifyAn = true;
            HungryFibrous = false;
            string placement = index + "_" + HungryMacaqueBoat;
            TorporAnMirageFive.placement_id = placement;
            MaxSdk.ShowRewardedAd(MAX_REWARD_ID, placement, JsonMapper.ToJson(TorporAnMirageFive));
        }
        else
        {
            EvokeExplain.AirExpertly().HaleEvoke("No ads right now, please try it later.");
            HungryReedBackSoften(false);
        }
    }

    /// <summary>
    /// 播放插屏广告
    /// </summary>
    /// <param name="index"></param>
    public void FoilInterferenceAn(int index)
    {
        if (index == 101 || index == 102 || index == 103)
        {
            UnityEngine.Debug.LogError("广告点位不允许为101、102、103");
            return;
        }

        FoilInterference(index);
    }

    /// <summary>
    /// 播放插屏广告
    /// </summary>
    /// <param name="index">101/102/103</param>
    /// <param name="customIndex">用户自定义点位</param>
    private void FoilInterference(int index, int customIndex = 0)
    {
        UnsuccessfulMold = index;

        if (OfMagnifyAn)
        {
            return;
        }
        // 当用户过关数 < trial_MaxNum时，不弹插屏广告
        int sv_trialNum = OpenFiveExplain.AirLag(CStatus.Be_It_Meaty_Its);
        int trial_MaxNum = int.Parse(PinBeadEka.instance.StatusFive.trial_MaxNum);
        if (sv_trialNum < trial_MaxNum)
        {
            return;
        }

        // 时间间隔低于阈值，不播放广告
        if (SongEpicLoveImagist < int.Parse(PinBeadEka.instance.StatusFive.inter_freq))
        {
            return;
        }

        if (OfDash)
        {
            ToxicAnEpicFibrous(ADType.Interstitial);
            return;
        }

        bool interstitialVideoReady = MaxSdk.IsInterstitialReady(MAX_INTER_ID);
        if (interstitialVideoReady)
        {
            if (UnsuccessfulMold == 101)
            {
                OfMagnifyAn = true;
                DOVirtual.DelayedCall(0.1f, () => //停顿
                {
                    UIExplain.AirExpertly().DelayUpDorsalUIProwl(nameof(ScenicBerg));
                    string point = index.ToString();
                    if (customIndex > 0)
                    {
                        point += customIndex.ToString().PadLeft(2, '0');
                    }
                    UnsuccessfulElect = point;
                    PorkTruckRevere.AirExpertly().FastTruck("9102", point);
                    string placement = point + "_" + UnsuccessfulMacaqueBoat;
                    InterferenceAnMirageFive.placement_id = placement;
                    MaxSdk.ShowInterstitial(MAX_INTER_ID, placement, JsonMapper.ToJson(InterferenceAnMirageFive));
                });
            }
            else
            {
                OfMagnifyAn = true;
                // 打点
                string point = index.ToString();
                if (customIndex > 0)
                {
                    point += customIndex.ToString().PadLeft(2, '0');
                }
                UnsuccessfulElect = point;
                PorkTruckRevere.AirExpertly().FastTruck("9102", point);
                string placement = point + "_" + UnsuccessfulMacaqueBoat;
                InterferenceAnMirageFive.placement_id = placement;
                MaxSdk.ShowInterstitial(MAX_INTER_ID, placement, JsonMapper.ToJson(InterferenceAnMirageFive));
            }
        }
    }

    /// <summary>
    /// 每秒更新一次计数器 - 101计数器 和 时间间隔计数器
    /// </summary>
    private void RepeatMethod()
    {
        SongEpicLoveImagist++;

        int relax_interval = int.Parse(PinBeadEka.instance.StatusFive.relax_interval);
        // 计时器阈值设置为0或负数时，关闭广告101；
        // 播放广告期间不计数；
        if (relax_interval <= 0 || OfMagnifyAn)
        {
            return;
        }
        else
        {
            Rainbow101++;
            if (Rainbow101 >= relax_interval && !SnowyLoveInterference)
            {
                FoilInterference(101);
            }
            if (Rainbow101 + 2 >= relax_interval && !SnowyLoveInterference)
            {
                if (OfMagnifyAn)
                {
                    return;
                }
                int sv_trialNum = OpenFiveExplain.AirLag(CStatus.Be_It_Meaty_Its);
                int trial_MaxNum = int.Parse(PinBeadEka.instance.StatusFive.trial_MaxNum);
                if (sv_trialNum < trial_MaxNum)
                {
                    return;
                }
                if (SongEpicLoveImagist < int.Parse(PinBeadEka.instance.StatusFive.inter_freq))
                {
                    return;
                }
                if (OfDash)
                {
                    ToxicAnEpicFibrous(ADType.Interstitial);
                    return;
                }
                bool interstitialVideoReady = MaxSdk.IsInterstitialReady(MAX_INTER_ID);
                if (interstitialVideoReady)
                {
                    InterferenceCultivate = GameUtil.GetInterstitialData();
                    UIExplain.AirExpertly().HaleUIProwl(nameof(ScenicBerg));
                    ScenicBerg.Instance.UserFive(InterferenceCultivate);
                }
            }
        }
    }

    /// <summary>
    /// NoThanks插屏 - 102
    /// </summary>
    public void NoThanksMayCrack(int customIndex = 0)
    {
        // 用户行为累计次数计数器阈值设置为0或负数时，关闭广告102
        int nextlevel_interval = int.Parse(PinBeadEka.instance.StatusFive.nextlevel_interval);
        if (nextlevel_interval <= 0)
        {
            return;
        }
        else
        {
            Rainbow102 = OpenFiveExplain.AirLag("NoThanksCount") + 1;
            OpenFiveExplain.BisLag("NoThanksCount", Rainbow102);
            if (Rainbow102 >= nextlevel_interval)
            {
                FoilInterference(102, customIndex);
            }
        }
    }

    /// <summary>
    /// 前后台切换计数器 - 103
    /// </summary>
    /// <param name="pause"></param>
    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            // 切回前台
            if (!OfMagnifyAn)
            {
                // 前后台切换时，播放间隔计数器需要累加切到后台的时间
                if (ScandinaviaSieveSomewhere > 0)
                {
                    SongEpicLoveImagist += (int)(PoemSeal.Zealand() - ScandinaviaSieveSomewhere);
                    ScandinaviaSieveSomewhere = 0;
                }
                // 后台切回前台累计次数，后台配置为0或负数，关闭该广告
                int inter_b2f_count = int.Parse(PinBeadEka.instance.StatusFive.inter_b2f_count);
                if (inter_b2f_count <= 0)
                {
                    return;
                }
                else
                {
                    Rainbow103++;
                    if (Rainbow103 >= inter_b2f_count)
                    {
                        FoilInterference(103);
                    }
                }
            }
        }
        else
        {
            // 切到后台
            ScandinaviaSieveSomewhere = PoemSeal.Zealand();
        }
    }

    /// <summary>
    /// 暂停定时插屏播放 - 101
    /// </summary>
    public void SieveLoveInterference()
    {
        SnowyLoveInterference = true;
    }

    /// <summary>
    /// 恢复定时插屏播放 - 101
    /// </summary>
    public void SaharaLoveInterference()
    {
        SnowyLoveInterference = false;
    }

    /// <summary>
    /// 更新游戏的TrialNum
    /// </summary>
    /// <param name="num"></param>
    public void SunlitCrownWan(int num)
    {
        OpenFiveExplain.BisLag(CStatus.Be_It_Meaty_Its, num);
    }

    /// <summary>
    /// 注册看广告的回调事件
    /// </summary>
    /// <param name="callback"></param>
    public void TotalityEpicDormancy(Action<ADType> callback)
    {
        if (ItPotteryCopyright == null)
        {
            ItPotteryCopyright = new List<Action<ADType>>();
        }

        if (!ItPotteryCopyright.Contains(callback))
        {
            ItPotteryCopyright.Add(callback);
        }
    }

    /// <summary>
    /// 广告播放成功后，执行看广告回调事件
    /// </summary>
    private void ToxicAnEpicFibrous(ADType adType)
    {
        OfMagnifyAn = false;
        // 播放间隔计数器清零
        SongEpicLoveImagist = 0;
        // 插屏计数器清零
        if (adType == ADType.Interstitial)
        {
            // 计数器清零
            if (UnsuccessfulMold == 101)
            {
                AideBelle.Instance.MayPace(InterferenceCultivate);
                Rainbow101 = 0;
            }
            else if (UnsuccessfulMold == 102)
            {
                Rainbow102 = 0;
                OpenFiveExplain.BisLag("NoThanksCount", 0);
            }
            else if (UnsuccessfulMold == 103)
            {
                Rainbow103 = 0;
            }
        }

        // 看广告总数+1
        OpenFiveExplain.BisLag(CStatus.Be_Shiny_It_Its + adType.ToString(), OpenFiveExplain.AirLag(CStatus.Be_Shiny_It_Its + adType.ToString()) + 1);

        // 回调
        if (ItPotteryCopyright != null && ItPotteryCopyright.Count > 0)
        {
            foreach (Action<ADType> callback in ItPotteryCopyright)
            {
                callback?.Invoke(adType);
            }
        }
    }

    /// <summary>
    /// 获取总的看广告次数
    /// </summary>
    /// <returns></returns>
    public int AirSerumAnWan(ADType adType)
    {
        return OpenFiveExplain.AirLag(CStatus.Be_Shiny_It_Its + adType.ToString());
    }
}

public enum ADType { Interstitial, Rewarded }

[System.Serializable]
public class Ad_CustomData //广告自定义数据
{
    public string user_id; //用户id
    public string version; //版本号
    public string request_id; //请求id
    public string vendor; //渠道
    public string placement_id; //广告位id
}