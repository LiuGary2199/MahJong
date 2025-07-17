/**
 * 
 * 常量配置
 * 
 * 
 * **/
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStatus
{
    #region 常量字段
    //登录url
    public const string LaterTug= "/api/client/user/getId?gameCode=";
    //配置url
    public const string ConfigTug= "/api/client/config?gameCode=";
    //时间戳url
    public const string LoveTug= "/api/client/common/current_timestamp?gameCode=";
    //更新AdjustId url
    public const string MarvelTug= "/api/client/user/setAdjustId?gameCode=";
    #endregion

    #region 本地存储的字符串
    /// <summary>
    /// 本地用户id (string)
    /// </summary>
    public const string Be_CrossShipOn= "sv_LocalUserId";
    /// <summary>
    /// 本地服务器id (string)
    /// </summary>
    public const string Be_CrossBreezeOn= "sv_LocalServerId";
    /// <summary>
    /// 是否是新用户玩家 (bool)
    /// </summary>
    public const string Be_WeAxeMexico= "sv_IsNewPlayer";
    public const string Be_Bike_Feed_Most_us= "sv_user_show_rate_us";


    /// <summary>
    /// 签到次数 (int)
    /// </summary>
    public const string Be_RobinCheepAirCrack= "sv_DailyBounsGetCount";
    /// <summary>
    /// 签到最后日期 (int)
    /// </summary>
    public const string Be_RobinCheepDate= "sv_DailyBounsDate";
    /// <summary>
    /// 新手引导完成的步数
    /// </summary>
    public const string Be_AxeShipDust= "sv_NewUserStep";
    /// <summary>
    /// 金币余额
    /// </summary>
    public const string Be_PoemFlee= "sv_GoldCoin";
    /// <summary>
    /// 累计金币总数
    /// </summary>
    public const string Be_HandsomelyPoemFlee= "sv_CumulativeGoldCoin";
    /// <summary>
    /// 钻石/现金余额
    /// </summary>
    public const string Be_Epoch= "sv_Token";
    /// <summary>
    /// 累计钻石/现金总数
    /// </summary>
    public const string Be_HandsomelyEpoch= "sv_CumulativeToken";
    /// <summary>
    /// 钻石Amazon
    /// </summary>
    public const string Be_Inflow= "sv_Amazon";
    /// <summary>
    /// 累计Amazon总数
    /// </summary>
    public const string Be_HandsomelyInflow= "sv_CumulativeAmazon";
    /// <summary>
    /// 游戏总时长
    /// </summary>
    public const string Be_SerumScamLove= "sv_TotalGameTime";
    /// <summary>
    /// 第一次获得钻石奖励
    /// </summary>
    public const string Be_LoverAirEpoch= "sv_FirstGetToken";
    /// <summary>
    /// 是否已显示评级弹框
    /// </summary>
    public const string Be_FanHaleSoulBelle= "sv_HasShowRatePanel";
    /// <summary>
    /// 累计Roblox奖券总数
    /// </summary>
    public const string Be_HandsomelySuffice= "sv_CumulativeLottery";
    /// <summary>
    /// 已经通过一次的关卡(int array)
    /// </summary>
    public const string Be_ReverseErieMaiden= "sv_AlreadyPassLevels";
    /// <summary>
    /// 新手引导
    /// </summary>
    public const string Be_AxeShipDustStatus= "sv_NewUserStepFinish";
    public const string Be_Fern_Perch_Burin= "sv_task_level_count";
    // 是否第一次使用过slot
    public const string Be_LoverHole= "sv_FirstSlot";

        public const string Be_LoverDewTorpor= "sv_FirstLowReward";
    /// <summary>
    /// adjust adid
    /// </summary>
    public const string Be_MarvelAdid= "sv_AdjustAdid";

    /// <summary>
    /// 广告相关 - trial_num
    /// </summary>
    public const string Be_It_Meaty_Its= "sv_ad_trial_num";
    /// <summary>
    /// 看广告总次数
    /// </summary>
    public const string Be_Shiny_It_Its= "sv_total_ad_num";

    /// <summary>
    /// 存储天
    /// </summary>
    public static string Be_CalmClosePoemWok= "sv_LastCheckDateKey";
    /// <summary>
    /// 天奖励
    /// </summary>
    public static string Be_RobinTorpor= "sv_DailyReward";

    #endregion

    #region 监听发送的消息

    /// <summary>
    /// 有窗口打开
    /// </summary>
    public static string So_WindowLift= "mg_WindowOpen";
    /// <summary>
    /// 窗口关闭
    /// </summary>
    public static string So_MarvelDelay= "mg_WindowClose";
    /// <summary>
    /// 关卡结算时传值
    /// </summary>
    public static string So_Go_Washingtonian= "mg_ui_levelcomplete";
    /// <summary>
    /// 增加金币
    /// </summary>
    public static string So_Go_Narrate= "mg_ui_addgold";
    /// <summary>
    /// 增加钻石/现金
    /// </summary>
    public static string So_Go_Thousand= "mg_ui_addtoken";
    /// <summary>
    /// 增加amazon
    /// </summary>
    public static string So_Go_Cheerless= "mg_ui_addamazon";

    /// <summary>
    /// 游戏暂停/继续
    /// </summary>
    public static string So_ScamSuspend= "mg_GameSuspend";

    /// <summary>
    /// 游戏资源数量变化
    /// </summary>
    public static string So_TramParent_= "mg_ItemChange_";

    /// <summary>
    /// 活动状态变更
    /// </summary>
    public static string So_HardshipIssueParent_= "mg_ActivityStateChange_";

    /// <summary>
    /// 关卡最大等级变更
    /// </summary>
    public static string So_SolveRotSolveParent= "mg_LevelMaxLevelChange";

    /// <summary>
    /// combo
    /// </summary>
    public static string So_AnPeartCosmic= "mg_OnComboUpdatas";
    /// <summary>
    /// combo show
    /// </summary>
    public static string So_AnPeartHale= "mg_OnComboShow";
    /// <summary>
    /// combo show
    /// </summary>
    public static string So_AnMayPique= "mg_OnAddScore";
    /// <summary>
    /// combo show
    /// </summary>
    public static string So_CosmicGetTorpor= "mg_UpdataDayReward";

    #endregion

    #region 动态加载资源的路径

    // 金币图片
    public static string Ling_PoemFlee_Subway= "Art/Tex/UI/jiangli1";
    // 钻石图片
    public static string Ling_Epoch_Subway_Luster= "Art/Tex/UI/jiangli4";

    #endregion
}

