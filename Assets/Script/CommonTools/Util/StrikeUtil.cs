using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeUtil
{

    [HideInInspector] public static string Marvel_IngoingBoat; //归因渠道名称 由PinBeadEka的CheckAdjustNetwork方法赋值
    static string Open_AP; //ApplePie的本地存档 存储第一次进入状态 未来不再受ApplePie开关影响
    static string StrikeAvidBoat= "pie"; //正常模式名称
    static string Fanatical; //距离黑名单位置的距离 打点用
    static string Answer; //进审理由 打点用
    [HideInInspector] public static string DustWeb= ""; //判断流程 打点用

    public static bool WeGrade()
    {
        //测试
        //return true;

        if (PlayerPrefs.HasKey("Save_AP"))  //优先使用本地存档
            Open_AP = PlayerPrefs.GetString("Save_AP");
        if (string.IsNullOrEmpty(Open_AP)) //无本地存档 读取网络数据
            CloseNormanFive();

        if (Open_AP != "P")
            return true;
        else
            return false;
    }
    static void CloseNormanFive() //读取网络数据 判断进入哪种游戏模式
    {
        string OtherChance = "NO"; //进审之后 是否还有可能变正常
        Open_AP = "P";
        if (PinBeadEka.instance.StatusFive.apple_pie != StrikeAvidBoat) //审模式 
        {
            OtherChance = "YES";
            Open_AP = "A";
            if (string.IsNullOrEmpty(Answer))
                Answer = "ApplePie";
        }
        DustWeb = "0:" + Open_AP;
        //判断地理位置
        if (!string.IsNullOrEmpty(PinBeadEka.instance.StatusFive.LocationList) && PinBeadEka.instance.ShipFive != null)
        {
            //判断运营商信息
            if (PinBeadEka.instance.ShipFive.IsHaveApple)
            {
                Open_AP = "A";
                if (string.IsNullOrEmpty(Answer))
                    Answer = "HaveApple";
            }
            DustWeb += "  1:" + Open_AP;
            //判断经纬度
            LocationData[] LocationDatas = LitJson.JsonMapper.ToObject<LocationData[]>(PinBeadEka.instance.StatusFive.LocationList);
            if (LocationDatas != null && LocationDatas.Length > 0 && PinBeadEka.instance.ShipFive.lat != 0 && PinBeadEka.instance.ShipFive.lon != 0)
            {
                for (int i = 0; i < LocationDatas.Length; i++)
                {
                    float Distance = AirAthenian((float)LocationDatas[i].X, (float)LocationDatas[i].Y,
                    (float)PinBeadEka.instance.ShipFive.lat, (float)PinBeadEka.instance.ShipFive.lon);
                    Fanatical += Distance.ToString() + ",";
                    if (Distance <= LocationDatas[i].Radius)
                    {
                        Open_AP = "A";
                        if (string.IsNullOrEmpty(Answer))
                            Answer = "Location";
                        break;
                    }
                }
            }
            DustWeb += "  2:" + Open_AP;
            //判断城市
            string[] HeiCityList = LitJson.JsonMapper.ToObject<string[]>(PinBeadEka.instance.StatusFive.HeiCity);
            if (!string.IsNullOrEmpty(PinBeadEka.instance.ShipFive.regionName) && HeiCityList != null && HeiCityList.Length > 0)
            {
                for (int i = 0; i < HeiCityList.Length; i++)
                {
                    if (HeiCityList[i] == PinBeadEka.instance.ShipFive.regionName
                    || HeiCityList[i] == PinBeadEka.instance.ShipFive.city)
                    {
                        Open_AP = "A";
                        if (string.IsNullOrEmpty(Answer))
                            Answer = "City";
                        break;
                    }
                }
            }
            DustWeb += "  3:" + Open_AP;
            //判断黑名单
            string[] HeiIPs = LitJson.JsonMapper.ToObject<string[]>(PinBeadEka.instance.StatusFive.HeiNameList);
            if (HeiIPs != null && HeiIPs.Length > 0 && !string.IsNullOrEmpty(PinBeadEka.instance.ShipFive.query))
            {
                string[] IpNums = PinBeadEka.instance.ShipFive.query.Split('.');
                for (int i = 0; i < HeiIPs.Length; i++)
                {
                    string[] HeiIpNums = HeiIPs[i].Split('.');
                    bool isMatch = true;
                    for (int j = 0; j < HeiIpNums.Length; j++) //黑名单IP格式可能是任意位数 根据位数逐个比对
                    {
                        if (HeiIpNums[j] != IpNums[j])
                            isMatch = false;
                    }
                    if (isMatch)
                    {
                        Open_AP = "A";
                        if (string.IsNullOrEmpty(Answer))
                            Answer = "IP";
                        break;
                    }
                }
            }
            DustWeb += "  4:" + Open_AP;
        }
        DustWeb += "  5:" + Open_AP;
        //判断自然量
        if (!string.IsNullOrEmpty(PinBeadEka.instance.StatusFive.fall_down))
        {
            if (PinBeadEka.instance.StatusFive.fall_down == "bottom") //仅判断Organic
            {
                if (Marvel_IngoingBoat == "Organic") //打开自然量 且 归因渠道是Organic 审模式
                {
                    Open_AP = "A";
                    if (string.IsNullOrEmpty(Answer))
                        Answer = "FallDown";
                }
            }
            else if (PinBeadEka.instance.StatusFive.fall_down == "down") //判断Organic + NoUserConsent
            {
                if (Marvel_IngoingBoat == "Organic" || Marvel_IngoingBoat == "No User Consent") //打开自然量 且 归因渠道是Organic或NoUserConsent 审模式
                {
                    Open_AP = "A";
                    if (string.IsNullOrEmpty(Answer))
                        Answer = "FallDown";
                }
            }
        }
        DustWeb += "  6:" + Open_AP;

        PlayerPrefs.SetString("Save_AP", Open_AP);
        PlayerPrefs.SetString("OtherChance", OtherChance);
        //打点
        if (!string.IsNullOrEmpty(OpenFiveExplain.AirRecoil(CStatus.Be_CrossBreezeOn)))
            FastTruck();


        //本地log
        Debug.Log("++++++判断流程： " + DustWeb);
        if (PinBeadEka.instance.ShipFive != null)
        {
            string Info = "游戏模式：" + (Open_AP == "A" ? "审" : "正常")
                       + "\n进审理由：" + Answer
                       + "\n开关： " + PinBeadEka.instance.StatusFive.apple_pie
                       + "\n是否包含苹果： " + PinBeadEka.instance.ShipFive.IsHaveApple
                       + "\n位置黑名单： " + PinBeadEka.instance.StatusFive.LocationList?.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(" ", "").Replace("[", "").Replace("]", "")
                       + "\n用户位置： " + PinBeadEka.instance.ShipFive.lat + "," + PinBeadEka.instance.ShipFive.lon
                       + "\n黑名单城市： " + PinBeadEka.instance.StatusFive.HeiCity?.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(" ", "").Replace("[", "").Replace("]", "")
                       + "\n用户城市: " + PinBeadEka.instance.ShipFive.regionName
                       + "\n与黑名单地点距离： " + Fanatical
                       + "\nIP黑名单： " + PinBeadEka.instance.StatusFive.HeiNameList?.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(" ", "").Replace("[", "").Replace("]", "")
                       + "\n用户IP： " + PinBeadEka.instance.ShipFive.query
                       + "\n自然量开关： " + PinBeadEka.instance.StatusFive.fall_down
                       + "\n归因渠道： " + Marvel_IngoingBoat
                       + "\n接口返回信息： " + PinBeadEka.instance.ShipFiveStr;
            Debug.Log("++++++" + Info);
        }
    }
    static float AirAthenian(float lat1, float lon1, float lat2, float lon2)
    {
        const float R = 6371f; // 地球半径，单位：公里
        float latDistance = Mathf.Deg2Rad * (lat2 - lat1);
        float lonDistance = Mathf.Deg2Rad * (lon2 - lon1);
        float a = Mathf.Sin(latDistance / 2) * Mathf.Sin(latDistance / 2)
               + Mathf.Cos(Mathf.Deg2Rad * lat1) * Mathf.Cos(Mathf.Deg2Rad * lat2)
               * Mathf.Sin(lonDistance / 2) * Mathf.Sin(lonDistance / 2);
        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        return R * c * 1000; // 距离，单位：米
    }

    public static void FastTruck()
    {
        //打点
        if (PinBeadEka.instance.ShipFive != null)
        {
            string Info1 = "[" + (Open_AP == "A" ? "审" : "正常")
                                       + "] [" + Answer + "]";
            string Info2 = "[" + PinBeadEka.instance.ShipFive.lat + "," + PinBeadEka.instance.ShipFive.lon
                           + "] [" + PinBeadEka.instance.ShipFive.regionName
                           + "] [" + Fanatical + "]";
            string Info3 = "[" + PinBeadEka.instance.ShipFive.query
                           + "] [" + Marvel_IngoingBoat + "]";
            PorkTruckRevere.AirExpertly().FastTruck("3000", Info1, Info2, Info3);
        }
        else
            PorkTruckRevere.AirExpertly().FastTruck("3000", "No UserData");
        PorkTruckRevere.AirExpertly().FastTruck("3001", (Open_AP == "A" ? "审" : "正常"), DustWeb, PinBeadEka.instance.FiveGobi);
        PlayerPrefs.SetInt("SendedEvent", 1);
    }



    public static bool WeArmory()
    {
#if UNITY_EDITOR
        return true;
#else
        return false;
#endif
    }

    /// <summary>
    /// 是否为竖屏
    /// </summary>
    /// <returns></returns>
    public static bool WeTabulate()
    {
        return Screen.height > Screen.width;
    }

    /// <summary>
    /// UI的本地坐标转为屏幕坐标
    /// </summary>
    /// <param name="tf"></param>
    /// <returns></returns>
    public static Vector2 CrossBrass2AvenueBrass(RectTransform tf)
    {
        if (tf == null)
        {
            return Vector2.zero;
        }

        Vector2 fromPivotDerivedOffset = new Vector2(tf.rect.width * 0.5f + tf.rect.xMin, tf.rect.height * 0.5f + tf.rect.yMin);
        Vector2 screenP = RectTransformUtility.WorldToScreenPoint(null, tf.position);
        screenP += fromPivotDerivedOffset;
        return screenP;
    }


    /// <summary>
    /// UI的屏幕坐标，转为本地坐标
    /// </summary>
    /// <param name="tf"></param>
    /// <param name="startPos"></param>
    /// <returns></returns>
    public static Vector2 AvenueBrass2CrossBrass(RectTransform tf, Vector2 startPos)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(tf, startPos, null, out localPoint);
        Vector2 pivotDerivedOffset = new Vector2(tf.rect.width * 0.5f + tf.rect.xMin, tf.rect.height * 0.5f + tf.rect.yMin);
        return tf.anchoredPosition + localPoint - pivotDerivedOffset;
    }

    public static Vector2 AirWriteSplinterOfEachPresident(RectTransform rectTransform)
    {
        // 从RectTransform开始，逐级向上遍历父级
        Vector2 worldPosition = rectTransform.anchoredPosition;
        for (RectTransform rt = rectTransform; rt != null; rt = rt.parent as RectTransform)
        {
            worldPosition += new Vector2(rt.localPosition.x, rt.localPosition.y);
            worldPosition += rt.pivot * rt.sizeDelta;

            // 考虑到UI元素的缩放
            worldPosition *= rt.localScale;

            // 如果父级不是Canvas，则停止遍历
            if (rt.parent != null && rt.parent.GetComponent<Canvas>() == null)
                break;
        }

        // 将结果从本地坐标系转换为世界坐标系
        return rectTransform.root.TransformPoint(worldPosition);
    }
}
