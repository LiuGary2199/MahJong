using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;


/// <summary> 提现功能管理 </summary>
public class CashOutManager : SomeReykjavik<CashOutManager>
{
    [Header("短剧后台的产品id")]
    public string AppInfo = "4";
    string WithdrawPlatform = "PAYPAL";
    string BaseUrl = "https://us.nicedramatv.com";
    [HideInInspector] public string Account;
    [HideInInspector] public CashOutData Data;
    [HideInInspector] public long LeftTime; // 剩余时间
    [HideInInspector] public CashOutPanel _CashOutPanel;
    [HideInInspector] public CashOutEnter _CashOutEnter;
    [HideInInspector] public float Money;
    [HideInInspector] public bool Ready;
    float MinWithdrawCount; //最小提现金额
    int Event_1304Time;


    private void Start()
    {
        Account = OpenFiveExplain.AirRecoil("CashOut_Account");
        Money = OpenFiveExplain.AirHypha("CashOut_Money");
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        long Seconds = LeftTime / 10000000;
        if (pauseStatus && Seconds > 0)
        {
            string title = "Your reward is ready!";
            string info = $"All {PinBeadEka.instance.StatusFive.CashOut_MoneyName} have been converted,Please check your rewaeds!";
            MultipurposeExplain.Expertly.GrainMultipurpose();
            MultipurposeExplain.Expertly.SunlightMultipurpose(title, info, (int)Seconds);
            for (int i = 0; i < 10; i++) // 10次延时 10800秒 3小时
                MultipurposeExplain.Expertly.SunlightMultipurpose(title, info, (int)Seconds + (i * 10800));
        }
    }

    Dictionary<string, string> Headers() // 请求头
    {
        return new Dictionary<string, string>
        {
            //{"app_info", AppInfo},
            {"app-version", Application.version},
            {"lang", I2.Loc.LocalizationManager.CurrentLanguageCode},
            {"Authorization", OpenFiveExplain.AirRecoil("CashOut_Token")},
            {"platform", WithdrawPlatform},
            {"os-version", SystemInfo.operatingSystem},
            {"device-name", SystemInfo.deviceName},
            //{"device_language", Application.systemLanguage.ToString()},
        };
    }

    public void Login() // 登录
    {
        string Platform = "IOS";
        if (Application.platform == RuntimePlatform.IPhonePlayer)
            Platform = "iOS";
        string DeviceAdId = OpenFiveExplain.AirRecoil("gaid");
        if (Application.platform == RuntimePlatform.IPhonePlayer)
            DeviceAdId = OpenFiveExplain.AirRecoil("idfv");

        StringBuilder uuidsb = new StringBuilder();
        uuidsb.Append(SystemInfo.deviceUniqueIdentifier);
#if UNITY_ANDROID || UNITY_EDITOR //安卓UUID存在不同应用相同ID的情况 用SystemInfo.deviceUniqueIdentifier+AppInfo 
        bool isNewPlayer = !PlayerPrefs.HasKey(CStatus.Be_WeAxeMexico + "Bool") || OpenFiveExplain.AirSlay(CStatus.Be_WeAxeMexico);
        bool hasuuidAndAppid = OpenFiveExplain.AirSlay("UuidAndAPPid");
        if (isNewPlayer || hasuuidAndAppid) //新老用户兼容
            uuidsb.Append(AppInfo);
#endif
        var loginRequest = new Request_Login
        {
            platform = Platform,
            bundle_id = Application.identifier,
            uuid = uuidsb.ToString(),
            device_ad_id = DeviceAdId,
            device_lang = CultureInfo.CurrentCulture.Name
        };

        string jsonBody = JsonMapper.ToJson(loginRequest);
        string loginUrl = $"{BaseUrl}/login";
        CashOutLog($"请求URL: {loginUrl}  请求体: {jsonBody}", false);

        PinSlotExplain.AirExpertly().HerePorkMaya(
            url: loginUrl,
            jsonData: jsonBody,
            success: (result) =>
            {
                CashOutLog("登录数据： " + result.downloadHandler.text, false);
                try
                {
                    var response = JsonMapper.ToObject<Response_User>(result.downloadHandler.text);
                    if (response.code == 0)
                    {
#if UNITY_ANDROID || UNITY_EDITOR //安卓UUID 新老用户兼容
                        bool isNewPlayer = !PlayerPrefs.HasKey(CStatus.Be_WeAxeMexico + "Bool") || OpenFiveExplain.AirSlay(CStatus.Be_WeAxeMexico);
                        if (isNewPlayer)
                            OpenFiveExplain.BisSlay("UuidAndAPPid", true);
#endif

                        //刷新token 获取提现规则
                        OpenFiveExplain.BisRecoil("CashOut_Token", response.data.token);
                        GetWithdrawRule();
                        //整理数据
                        Data = new CashOutData();
                        Data.UserID = response.data.id.ToString();
                        Data.Cash = float.Parse(response.data.cash, CultureInfo.InvariantCulture);
                        DateTime ConvertTime = DateTime.Parse(response.data.convert_time);
                        if (PlayerPrefs.HasKey("CashOut_ConvertTime"))
                            Data.ConvertTime = long.Parse(OpenFiveExplain.AirRecoil("CashOut_ConvertTime"));
                        if (Data.ConvertTime < ConvertTime.Ticks)
                        {
                            Money = 0;
                            OpenFiveExplain.BisHypha("CashOut_Money", Money);
                        }
                        Data.ConvertTime = ConvertTime.Ticks;
                        OpenFiveExplain.BisRecoil("CashOut_ConvertTime", Data.ConvertTime.ToString());
                        InvokeRepeating(nameof(ConvertTimeCount), 1, 1);

                        // 更新UI
                        _CashOutPanel?.UpdateMoney();
                        _CashOutEnter?.UpdateMoney();

                        Ready = true;
                    }
                    else
                    {
                        CashOutLog($"登录失败: {response.msg}", true);
                        EvokeExplain.AirExpertly().HaleEvoke("Login fail :" + response.msg);
                    }
                }
                catch (Exception e)
                {
                    CashOutLog($"解析登录响应数据失败: {e.Message}", true);
                }
            },
            fail: () =>
            {
                CashOutLog("登录请求失败", true);
                EvokeExplain.AirExpertly().HaleEvoke("Login fail");
                Ready = false;
            },
            timeout: 3f,
            headers: Headers()
        );
    }

    public void UpdateUserInfo() // 更新用户信息
    {
        CancelInvoke(nameof(ConvertTimeCount));
        string url = $"{BaseUrl}/user";
        PinSlotExplain.AirExpertly().HereAir(
            url: url,
            success: (result) =>
            {
                CashOutLog("用户信息数据： " + result.downloadHandler.text, false);
                try
                {
                    var response = JsonMapper.ToObject<Response_User>(result.downloadHandler.text);
                    if (response.code == 0)
                    {
                        string Event_Money = Money.ToString();

                        double OldCash = OpenFiveExplain.AirColumn("CashOut_Cash");
                        float NewCash = float.Parse(response.data.cash, CultureInfo.InvariantCulture);
                        DateTime ConvertTime = DateTime.Parse(response.data.convert_time);
                        //当前时间小于后台时间 代表新一轮转换开始 清空Money
                        if (Data.ConvertTime < ConvertTime.Ticks)
                        {
                            Money = 0;
                            OpenFiveExplain.BisHypha("CashOut_Money", Money);
                        }
                        if (Money == 0)
                        {
                            //如果转换后Cash增加 播飞钱动画 否则播进度归零动画
                            bool IsIconFly = NewCash > 0 && NewCash > OldCash;
                            _CashOutPanel?.MoneyToCashAnim();
                            _CashOutEnter?.MoneyToCashAnim(IsIconFly);

                            //打点 如果钱转化了 上报转化信息
                            if (IsIconFly)
                                PorkTruckRevere.AirExpertly().FastTruck("1302", Event_Money, NewCash.ToString());
                        }
                        else
                        {
                            Data.Cash = NewCash;
                            _CashOutPanel?.UpdateMoney();
                            _CashOutEnter?.UpdateMoney();
                        }
                        Data.ConvertTime = ConvertTime.Ticks;
                        OpenFiveExplain.BisRecoil("CashOut_ConvertTime", Data.ConvertTime.ToString());
                        Data.Cash = NewCash;

                        InvokeRepeating(nameof(ConvertTimeCount), 0, 1);
                        OpenFiveExplain.BisColumn("CashOut_Cash", Data.Cash);
                        _CashOutPanel?.CloseLoading_UpdateUI();
                    }
                    else
                    {
                        CashOutLog($"获取用户信息失败: {response.msg}", true);
                    }
                }
                catch (Exception e)
                {
                    CashOutLog($"解析用户信息响应数据失败: {e.Message}", true);
                }
            },
            fail: () =>
            {
                CashOutLog("获取用户信息请求失败", true);
            },
            timeout: 3f,
            headers: Headers()
        );
    }

    public void GetWithdrawRule() // 获取提现规则（规则获取不到不影响流程）
    {
        string url = $"{BaseUrl}/withdraw/rule?platform={WithdrawPlatform}";

        PinSlotExplain.AirExpertly().HereAir(
            url: url,
            success: (result) =>
            {
                CashOutLog("提现规则数据： " + result.downloadHandler.text, false);
                try
                {
                    var response = JsonMapper.ToObject<Response_WithdrawRule>(result.downloadHandler.text);
                    if (response.code == 0) // 成功状态码
                    {
                        MinWithdrawCount = float.Parse(response.data.min_amount, CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        CashOutLog($"提现规则获取失败: {response.msg}", true);
                    }
                }
                catch (Exception e)
                {
                    CashOutLog($"解析提现规则响应数据失败: {e.Message}", true);
                }
            },
            fail: () =>
            {
                CashOutLog("获取最小提现金额请求失败", true);
            },
            timeout: 3f,
            headers: Headers()
        );
    }

    public void Withdraw() // 提现
    {
        if (Data.Cash < MinWithdrawCount)
        {
            EvokeExplain.AirExpertly().HaleEvoke($"Minimum withdrawal amount {MinWithdrawCount}");
            _CashOutPanel?.CloseLoading_Withdraw(true);
            string Amount = Data.Cash.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
            SendWithdrawEvent(Amount, false);
            return;
        }

        var withdrawRequest = new RequestData_Withdraw
        {
            //测试
            //amount = MinWithdrawCount.ToString("F2",System.Globalization.CultureInfo.InvariantCulture),

            amount = Data.Cash.ToString("F2", System.Globalization.CultureInfo.InvariantCulture),
            receiver_value = Account
        };

        string jsonBody = JsonMapper.ToJson(withdrawRequest);
        string url = $"{BaseUrl}/withdraw";

        PinSlotExplain.AirExpertly().HerePorkMaya(
            url: url,
            jsonData: jsonBody,
            success: (result) =>
            {
                try
                {
                    var response = JsonMapper.ToObject<Response_Withdraw>(result.downloadHandler.text);
                    if (response.code == 0)
                    {
                        CashOutLog("提现数据： " + result.downloadHandler.text, false);
                        _CashOutPanel?.CloseLoading_Withdraw(true);
                        _CashOutPanel?.UpdateUserInfo();

                        SendWithdrawEvent(withdrawRequest.amount, true);
                    }
                    else
                    {
                        CashOutLog($"提现失败: {response.msg}", true);
                        _CashOutPanel?.CloseLoading_Withdraw();

                        SendWithdrawEvent(withdrawRequest.amount, false);
                    }
                }
                catch (Exception e)
                {
                    CashOutLog($"解析提现响应数据失败: {e.Message}", true);
                    _CashOutPanel?.CloseLoading_Withdraw();
                    EvokeExplain.AirExpertly().HaleEvoke("Withdraw fail :" + e.Message);

                    SendWithdrawEvent(withdrawRequest.amount, false);
                }
            },
            fail: () =>
            {
                CashOutLog("提现请求失败", true);
                _CashOutPanel?.CloseLoading_Withdraw();

                SendWithdrawEvent(withdrawRequest.amount, false);
            },
            timeout: 3f,
            headers: Headers()
        );
    }
    void SendWithdrawEvent(string Event_Cash, bool IsSuccess) //打点 提现成功或失败
    {
        PorkTruckRevere.AirExpertly().FastTruck("1303", Event_Cash, IsSuccess ? "1" : "0");
    }

    public void GetWithdrawRecord() // 获取提现记录
    {
        string url = $"{BaseUrl}/withdraw";
        PinSlotExplain.AirExpertly().HereAir(
            url: url,
            success: (result) =>
            {
                CashOutLog("提现记录数据： " + result.downloadHandler.text, false);
                try
                {
                    var response = JsonMapper.ToObject<Response_WithdrawRecord>(result.downloadHandler.text);
                    if (response.code == 0)
                    {
                        Data.Record = response.data.data;
                        _CashOutPanel?.CloseLoading_Record();
                        _CashOutPanel?.UpdateRecord();
                    }
                    else
                    {
                        CashOutLog($"提现记录获取失败: {response.msg}", true);
                    }
                }
                catch (Exception e)
                {
                    CashOutLog($"解析提现记录响应数据失败: {e.Message}", true);
                }
            },
            fail: () =>
            {
                CashOutLog("提现记录请求失败", true);
            },
            timeout: 3f,
            headers: Headers()
        );
    }

    public void ReportEcpm(MaxSdkBase.AdInfo info, string RequestID, string AdFormat) // 上报ecpm
    {
        return;

        if (Application.isEditor)
        {
            CashOutLog("假装上报ecpm，当前为编辑器模式 RequestID： " + RequestID);
            return;
        }
        string url = $"{BaseUrl}/ecpm";
        RequestData_ReportEcpm requestData = new RequestData_ReportEcpm();
        requestData.type = AdFormat;
        requestData.request_id = RequestID;
        requestData.amount = info.Revenue.ToString("G17", System.Globalization.CultureInfo.InvariantCulture);
        requestData.vendor = info.NetworkName;
        requestData.placement_id = info.Placement;
        requestData.timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        requestData.signature = EcpmSignatureMD5(requestData.request_id, requestData.amount, Data.UserID, requestData.timestamp);
        string jsonBody = JsonMapper.ToJson(requestData);
        CashOutLog($"上报ecpmURL: {url}  请求体: {jsonBody}", false);

        PinSlotExplain.AirExpertly().HerePorkMaya(
            url: url,
            jsonData: jsonBody,
            success: (result) =>
            {
                CashOutLog("上报ecpm数据： " + result.downloadHandler.text, false);
                try
                {
                    var response = JsonMapper.ToObject<Response_Ecpm>(result.downloadHandler.text);
                    if (response.code == 0) // 成功状态码
                    {
                        CashOutLog("上报ecpm成功", false);
                    }
                    else
                    {
                        CashOutLog($"上报ecpm失败: {response.msg}", true);
                    }
                }
                catch (Exception e)
                {
                    CashOutLog($"解析上报ecpm响应数据失败: {e.Message}", true);
                }
            },
            fail: () =>
            {
                CashOutLog("上报ecpm请求失败", true);
            },
            timeout: 3f,
            headers: Headers()
        );
    }
    public string EcpmRequestID() // 获取上报ecpm的request_id 广告加载时生成
    {
        string uuid = Guid.NewGuid().ToString();
        string formattedUuid = uuid.ToLowerInvariant().Replace("-", "");
        return formattedUuid;
    }
    string EcpmSignatureMD5(string requestId, string amount, string userId, long timestamp) // 上报ecpm生成签名
    {
        string Input = $"{requestId}-{amount}-{userId}-{timestamp}";
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(Input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }

    public void ReportAdjustID() // 上报adjust_id
    {
        string url = $"{BaseUrl}/user/ad";
        RequestData_ReportAdjustID requestData = new RequestData_ReportAdjustID();
        requestData.id = MarvelUserExplain.Instance.AirMarvelBulb();
        string jsonBody = JsonMapper.ToJson(requestData);
        CashOutLog($"上报adjust_idURL: {url}  请求体: {jsonBody}", false);
        PinSlotExplain.AirExpertly().HerePorkMaya(
            url: url,
            jsonData: jsonBody,
            success: (result) =>
            {
                CashOutLog("上报adjust_id数据： " + result.downloadHandler.text, false);
                try
                {
                    var response = JsonMapper.ToObject<BaseResponse>(result.downloadHandler.text);
                    if (response.code == 0) // 成功状态码
                    {
                        CashOutLog("上报adjust_id成功", false);
                    }
                    else
                    {
                        CashOutLog($"上报adjust_id失败: {response.msg}", true);
                    }
                }
                catch (Exception e)
                {
                    CashOutLog($"解析上报adjust_id响应数据失败: {e.Message}", true);
                }
            },
            fail: () =>
            {
                CashOutLog("上报adjust_id请求失败", true);
            },
            timeout: 3f,
            headers: Headers()
        );
    }

    void ConvertTimeCount() //Money转Cash倒计时
    {
        if (Data != null)
        {
            long nowTime = System.DateTime.UtcNow.Ticks;
            LeftTime = Data.ConvertTime - nowTime;
            //倒计时结束 更新用户信息 
            if (LeftTime <= 0)
            {
                LeftTime = 0;
                if (_CashOutPanel != null && _CashOutPanel.gameObject.activeSelf)
                    _CashOutPanel?.UpdateUserInfo(); //因为界面需要显示加载动画所以此处由_CashOutPanel调用
                else
                    UpdateUserInfo();
            }
            //更新剩余时间ui 
            string timeStr = "";
            long Seconds = LeftTime / 10000000;
            if (Seconds <= 0)
                timeStr = "00:00:00";
            else
            {
                int hour = (int)(Seconds / 3600);
                int minute = (int)((Seconds - hour * 3600) / 60);
                int second = (int)(Seconds - hour * 3600 - minute * 60);
                timeStr = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
            }
            _CashOutPanel?.UpdateTime(timeStr);
            _CashOutEnter?.UpdateTime(timeStr);
        }
    }

    public void AddMoney(float Value)
    {
        Money += Value;
        OpenFiveExplain.BisHypha("CashOut_Money", Money);
        _CashOutPanel?.UpdateMoney();
        _CashOutEnter?.UpdateMoney();
    }

    public void WaitToSendEvent1304() //等待 发送关闭商店后行为1304事件
    {
        InvokeRepeating(nameof(Count1304Time), 0, 1);
    }
    void Count1304Time() //计时器
    {
        Event_1304Time++;
    }
    public void SendEvent1304() ////打点 关闭商店后行为
    {
        CancelInvoke(nameof(Count1304Time));
        if (Event_1304Time <= 0)
            return;
        PorkTruckRevere.AirExpertly().FastTruck("1304", Event_1304Time.ToString());
        Event_1304Time = 0;
    }

    void CashOutLog(string log, bool IsError = false) //提现相关功能日志
    {
        if (IsError)
            Debug.LogError("<color=red><b>+++++   " + log + "</b></color>");
        else
            print("<color=yellow><b>+++++   " + log + "</b></color>");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _CashOutPanel?.MoneyToCashAnim();
            _CashOutEnter?.MoneyToCashAnim(true);
        }
    }
}

#region 接口相关各类请求和响应数据结构

// 各种接口数据汇总 UI常用数据
[System.Serializable]
public class CashOutData
{
    public string UserID;
    public long ConvertTime;     // Money转Cash时间戳
    public float Cash;           // 当前Cash
    public List<WithdrawRecordItem> Record; // 提现记录
}

// 基础响应模型
[System.Serializable]
public class BaseResponse
{
    public int code;
    public string msg;
}

// 用户相关数据模型
[System.Serializable]
public class Request_Login
{
    public string platform;
    public string bundle_id;
    public string uuid;
    public string device_ad_id;
    public string device_lang;
}
[System.Serializable]
public class Response_User : BaseResponse
{
    public UserData data;
}
[System.Serializable]
public class UserData
{
    public long id;
    public string nick_name;
    public string avatar;
    public string crt_time;
    public string coin;
    public string cash;
    public string channel;
    public string convert_time;
    public string token;
    public bool is_regist;
}

// 提现相关数据模型
[System.Serializable]
public class RequestData_Withdraw
{
    public string type = "TRANSFER";
    public string platform = "PAYPAL";
    public string amount;  // 改为string类型
    public string receiver_type = "EMAIL";
    public string receiver_value;
}
[System.Serializable]
public class Response_Withdraw : BaseResponse
{
    public int data;
}

// 提现规则数据模型
[System.Serializable]
public class Response_WithdrawRule : BaseResponse
{
    public WithdrawRuleData data;
}
[System.Serializable]
public class WithdrawRuleData
{
    public string min_amount;      // 最小提现金额
    public int day_count;        // 每日提现次数限制
    public string day_max_amount;  // 每日最大提现金额
    public int count;           // 总提现次数
    public string amount;         // 总提现金额
}

// 提现记录数据模型
[System.Serializable]
public class Response_WithdrawRecord : BaseResponse
{
    public WithdrawRecordData data;
}
[System.Serializable]
public class WithdrawRecordData
{
    public long count;
    public List<WithdrawRecordItem> data;
}
[System.Serializable]
public class WithdrawRecordItem
{
    public long id;
    public string amount;
    public string receiver_type;
    public string receiver_value;
    public string status;
    public string crt_time;
}

// ECPM相关数据模型
[System.Serializable]
public class RequestData_ReportEcpm
{
    public string type;
    public string request_id;
    public string amount;
    public string vendor;
    public string placement_id;
    public long timestamp;
    public string signature;
}
[System.Serializable]
public class Response_Ecpm : BaseResponse
{
    public int data;
}

// Adjust相关数据模型
[System.Serializable]
public class RequestData_ReportAdjustID
{
    public string id;
}

#endregion
