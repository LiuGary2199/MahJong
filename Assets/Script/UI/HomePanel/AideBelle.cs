using DG.Tweening;
using LitJson;
using Mkey;
using Spine;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class AideBelle : CoaxUIProwl
{
    public static AideBelle Instance;
[UnityEngine.Serialization.FormerlySerializedAs("GoldBar")]
    public GameObject PoemBar;
[UnityEngine.Serialization.FormerlySerializedAs("BackBtn")]
    public Button WineYam;
[UnityEngine.Serialization.FormerlySerializedAs("SettingBtn")]    public Button RadiateYam;
[UnityEngine.Serialization.FormerlySerializedAs("SelectBtn")]    public Button WinnerYam;
[UnityEngine.Serialization.FormerlySerializedAs("SelectText")]    public Text WinnerExam;
[UnityEngine.Serialization.FormerlySerializedAs("SelectLevelObj")]    public GameObject WinnerSolveYew;
[UnityEngine.Serialization.FormerlySerializedAs("cashImg")]
    public Image LilyImg;
[UnityEngine.Serialization.FormerlySerializedAs("cashNumText")]    public Text LilyWanExam;
[UnityEngine.Serialization.FormerlySerializedAs("LevelText")]    public Text SolveExam;
[UnityEngine.Serialization.FormerlySerializedAs("instrans")]    public Transform Shepherd;

    // 提示相关UI组件
    [Header("提示面板")]
[UnityEngine.Serialization.FormerlySerializedAs("tipPanel")]    public GameObject MobBelle; // 提示面板
[UnityEngine.Serialization.FormerlySerializedAs("tipText")]    public Text MobExam; // 提示文本
[UnityEngine.Serialization.FormerlySerializedAs("tipBackground")]    public Image MobInnovation; // 提示背景
[UnityEngine.Serialization.FormerlySerializedAs("tipCloseButton")]    public Button MobDelaySenate; // 提示关闭按钮
[UnityEngine.Serialization.FormerlySerializedAs("ComboanimPB")]
    public Fantastic FantasticPB;
[UnityEngine.Serialization.FormerlySerializedAs("ComboParent")]    public Transform PeartSlight;
[UnityEngine.Serialization.FormerlySerializedAs("DayTimeBtn")]    public Button GetLoveYam;
[UnityEngine.Serialization.FormerlySerializedAs("DayTimeRedPoint")]    public GameObject GetLoveSewBrass;
[UnityEngine.Serialization.FormerlySerializedAs("CashoutBtn")]    public RectTransform TenuousYam;
[UnityEngine.Serialization.FormerlySerializedAs("TimeDown")]    public int LoveDose= 0;

    // 保存CashoutBtn的原始位置
    private Vector2 BuildingTenuousYamSplinter;
[UnityEngine.Serialization.FormerlySerializedAs("m_SkBG")]
    public SkeletonGraphic m_SkBG;
[UnityEngine.Serialization.FormerlySerializedAs("m_SkSetting")]    public SkeletonGraphic m_NoRadiate;
[UnityEngine.Serialization.FormerlySerializedAs("m_Bottomobj")]    public GameObject m_Numerical;
[UnityEngine.Serialization.FormerlySerializedAs("GoldImg")]    public Image PoemMow;
[UnityEngine.Serialization.FormerlySerializedAs("GoldFly")]    public GameObject PoemBed;
[UnityEngine.Serialization.FormerlySerializedAs("Logo")]    public GameObject Barb;
[UnityEngine.Serialization.FormerlySerializedAs("settingbtn1")]
    public Button Separation1; //
[UnityEngine.Serialization.FormerlySerializedAs("Coin")]
    public GameObject Flee;
[UnityEngine.Serialization.FormerlySerializedAs("Coinimage")]    public Image Overcrowd;
[UnityEngine.Serialization.FormerlySerializedAs("CoinStr")]    public Text FleeIts;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        if (StrikeUtil.WeGrade())
        {
            Flee.SetActive(true);
            TenuousYam.gameObject.SetActive(false);

        }
        else
        {
            Flee.SetActive(false);
            TenuousYam.gameObject.SetActive(true);

        }

        // 监听动画结束事件
        m_SkBG.AnimationState.Complete += OnBGComplete;
        m_NoRadiate.AnimationState.Complete += OnSetComplete;
        GameEvents.LevelLoadCompleteAction += OnLevelComplete;
        GameEvents.GoldProgress += PoemFumigate;


        // 监听提示事件
        GameEvents.ShowTipAction += OnShowTip;
        GameEvents.ShowTipManualAction += OnShowTipManual;
        GameEvents.HideTipAction += OnHideTip;

        WineYam.onClick.AddListener(() =>
        {
            BuildingTenuousYamSplinter = new Vector2(0, -146);
            WinnerSolveYew.gameObject.SetActive(true);
            m_SkBG.AnimationState.ClearTracks();
            m_SkBG.AnimationState.SetAnimation(0, "3close", false);
            m_NoRadiate.AnimationState.ClearTracks();
            m_NoRadiate.AnimationState.SetAnimation(0, "1open", false);
            StaticPaymentSolveExam();
            RussianTenuousYamSimple();
        });
        GetLoveYam.onClick.AddListener(() =>
        {
            LiftUIFine(nameof(LoveTorpor));
        });

        WinnerYam.onClick.AddListener(() =>
        {
            BuildingTenuousYamSplinter = new Vector2(0, -277);
            WinnerYam.gameObject.SetActive(false);
            m_SkBG.AnimationState.ClearTracks();
            m_SkBG.AnimationState.SetAnimation(0, "1open", false);
            m_NoRadiate.AnimationState.ClearTracks();
            m_NoRadiate.AnimationState.SetAnimation(0, "3close", false);
            Barb.SetActive(false);
            RussianTenuousYamSimple();

            // 新增：点击SelectBtn时让新手引导开始检测
            if (Mkey.TutorialGuide.Instance != null)
            {
                if (Mkey.GameLevelHolder.CurrentLevel == 0)
                {
                    Mkey.TutorialGuide.Instance.StartTutorialGuide();
                }
                else if (Mkey.GameLevelHolder.CurrentLevel == 1)
                {
                    Mkey.TutorialGuide.Instance.StartTutorialGuideForLevel2();
                }
            }
        });
        Separation1.onClick.AddListener(() =>
        {
            LiftUIFine(nameof(RadiateBelle));
        });
        RadiateYam.onClick.AddListener(() =>
        {
            LiftUIFine(nameof(RadiateBelle));
        });
        SeepageGrassy.MayMsgPrestige(CStatus.So_AnPeartHale, OnComboUpdate);
        SeepageGrassy.MayMsgPrestige(CStatus.So_AnMayPique, OnCashUpdate);
        SeepageGrassy.MayMsgPrestige(CStatus.So_CosmicGetTorpor, OnUpdateDayReward);

        RobinTorporLotus();
        PaymentSolveExam(); // 初始化时刷新关卡文本

        // 保存CashoutBtn的原始位置

        BisDefeatIssue();

        // 初始化提示面板
        UserTipBelle();

        // 新增：监听新手引导开始/结束事件，控制按钮可用性
        GameEvents.TutorialGuideStartedAction += OnTutorialGuideStarted;
        GameEvents.TutorialGuideEndedAction += OnTutorialGuideEnded;

        m_NoRadiate.AnimationState.SetAnimation(0, "1open", false);
        TenuousYam.anchoredPosition = new Vector2(0, -146);
    }

    /// <summary>
    /// 初始化提示面板
    /// </summary>
    private void UserTipBelle()
    {
        if (MobBelle != null)
        {
            // 初始时隐藏
            MobBelle.SetActive(false);

            // 设置关闭按钮事件
            if (MobDelaySenate != null)
            {
                MobDelaySenate.onClick.AddListener(OnHideTip);
            }
        }
    }

    /// <summary>
    /// 显示提示事件处理
    /// </summary>
    private void OnShowTip(string message, float duration)
    {
        HaleWeb(message, duration);
    }

    /// <summary>
    /// 显示提示（手动关闭）事件处理
    /// </summary>
    private void OnShowTipManual(string message)
    {
        HaleWeb(message, 0f); // 传入0表示不自动关闭
    }

    /// <summary>
    /// 隐藏提示事件处理
    /// </summary>
    private void OnHideTip()
    {
        TailWeb();
    }

    /// <summary>
    /// 显示提示
    /// </summary>
    /// <param name="message">提示信息</param>
    /// <param name="duration">显示时长（秒），0表示不自动隐藏，需要手动调用HideTip()关闭</param>
    public void HaleWeb(string message, float duration = 0f)
    {
        if (MobExam != null)
        {
            MobExam.text = message;
        }

        if (MobBelle != null)
        {
            MobBelle.SetActive(true);

            // 淡入动画
            CanvasGroup canvasGroup = MobBelle.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = MobBelle.AddComponent<CanvasGroup>();
            }

            canvasGroup.alpha = 0f;
            canvasGroup.DOFade(1f, 0.3f);

            // 如果设置了自动隐藏时间（大于0）
            if (duration > 0)
            {
                DOVirtual.DelayedCall(duration, () =>
                {
                    TailWeb();
                });
            }
        }
    }

    /// <summary>
    /// 隐藏提示
    /// </summary>
    public void TailWeb()
    {
        if (MobBelle != null)
        {
            CanvasGroup canvasGroup = MobBelle.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.DOFade(0f, 0.3f).OnComplete(() =>
                {
                    MobBelle.SetActive(false);
                });
            }
            else
            {
                MobBelle.SetActive(false);
            }
        }
    }

    /// <summary>
    /// 静态方法，供外部调用显示提示（自动关闭）
    /// </summary>
    /// <param name="message">提示信息</param>
    /// <param name="duration">显示时长（秒），0表示不自动隐藏</param>
    public static void HaleWebSeepage(string message, float duration = 3f)
    {
        if (Instance != null)
        {
            Instance.HaleWeb(message, duration);
        }
    }

    /// <summary>
    /// 静态方法，供外部调用显示提示（手动关闭）
    /// </summary>
    /// <param name="message">提示信息</param>
    public static void HaleWebSeepageDuring(string message)
    {
        if (Instance != null)
        {
            Instance.HaleWeb(message, 0f); // 传入0表示不自动关闭
        }
    }

    /// <summary>
    /// 静态方法，供外部调用隐藏提示
    /// </summary>
    public static void TailWebSeepage()
    {
        if (Instance != null)
        {
            Instance.TailWeb();
        }
    }

    private void OnLevelComplete()
    {
        Debug.Log("AideBelle 监听到过关事件");
        BisDefeatIssue();
        // 进度条归零
        if (PoemMow != null && PoemMow.gameObject.activeInHierarchy)
        {
            DG.Tweening.DOTween.Kill(PoemMow, "GoldFill");
            DG.Tweening.DOTween.To(() => PoemMow.fillAmount, x => PoemMow.fillAmount = x, 0f, 0.3f)
                .SetId("GoldFill");
        }
    }
    // goldMul是总进度，count是当前进度，GoldImg是进度图片，GoldFly是金币预制体
    // posTrans为目标位置列表，callBack为飞行完成回调
    public void PoemFumigate(int count, bool flystate, List<Transform> posTrans, Action callBack)
    {
        int goldMul = PinBeadEka.instance.ScamFive.combogold;
        float targetFill = Mathf.Clamp01((float)count / goldMul);
        // DOTween动画进度条
        if (PoemMow != null && PoemMow.gameObject.activeInHierarchy)
        {
            if (!Mathf.Approximately(PoemMow.fillAmount, targetFill))
            {
                DG.Tweening.DOTween.Kill(PoemMow, "GoldFill");
                DG.Tweening.DOTween.To(() => PoemMow.fillAmount, x => PoemMow.fillAmount = x, targetFill, 0.3f)
                    .SetId("GoldFill");
            }
        }
        // 满了且需要飞行
        if (count >= goldMul && flystate && posTrans != null && posTrans.Count >= 2)
        {
            // 生成两个金币飞行
            for (int i = 0; i < 2; i++)
            {
                GameObject fly = Instantiate(PoemBed, PoemMow.transform.position, Quaternion.identity, PoemMow.transform.parent);
                Vector3 targetPos = posTrans[i].position;
                fly.transform.SetAsLastSibling();
                fly.transform.DOMove(targetPos, 0.6f).SetEase(DG.Tweening.Ease.InQuad).OnComplete(() =>
                {
                    Destroy(fly);
                    // 两个都完成后回调
                    LeadBedStatusCrack++;
                    if (LeadBedStatusCrack == 2)
                    {
                        LeadBedStatusCrack = 0;
                        callBack?.Invoke();
                    }
                });
            }
        }
    }
    private int LeadBedStatusCrack= 0;

    private void BisDefeatIssue()
    {
        if (Mkey.GameLevelHolder.CurrentLevel <= 1)
        {
            m_Numerical.SetActive(false);
        }
        else
        {
            m_Numerical.SetActive(true);
        }
    }

    private void OnBGComplete(TrackEntry trackEntry)
    {
        if (trackEntry != null)
        {
            if (trackEntry.Animation.Name == "1open")
            {
                WinnerSolveYew.gameObject.SetActive(false);
            }

            if (trackEntry.Animation.Name == "3close")
            {
                WinnerYam.gameObject.SetActive(true);
                Barb.SetActive(true);
                m_SkBG.AnimationState.ClearTracks();
                m_SkBG.AnimationState.SetAnimation(0, "2idle", true);
            }
        }

    }
    private void OnSetComplete(TrackEntry trackEntry)
    {
        if (trackEntry != null)
        {
            if (trackEntry.Animation.Name == "1open" || trackEntry.Animation.Name == "3close")
            {
                m_NoRadiate.AnimationState.ClearTracks();
                m_NoRadiate.AnimationState.SetAnimation(0, "2idle", true);
            }
        }
    }
    private void OnUpdateDayReward(KeyValuesUpdate kv)
    {
        RobinTorporLotus();
    }

    private void OnCashUpdate(KeyValuesUpdate kv)
    {
        addScoreData sendData = (addScoreData)kv.Borrow;
        Shepherd.position = sendData.Heater3Nut;
        MayPace(sendData.PeartCrack, Shepherd);
    }

    private void OnComboUpdate(KeyValuesUpdate kv)
    {
        FastFive sendData = (FastFive)kv.Borrow;
        //Canvas canvas = UIExplain.GetInstance().MainCanvas.GetComponent<Canvas>();
        //Vector2  pos = WorldToCanvasPos(canvas, sendData.Vector3pos);
        //Fantastic combo =  Instantiate(ComboanimPB, ComboParent);
        //RectTransform rect = combo.GetComponent<RectTransform>();
        //rect.anchoredPosition = pos;
        FantasticPB.EpicDull(sendData.PeartCrack);


        //Debug.Log(kv.Key);
    }
   


    /// <summary>
    /// 世界坐标转换为画布坐标
    /// </summary>
    /// <param name="canvas">画布</param>
    /// <param name="world">世界坐标</param>
    /// <returns></returns>
    private Vector2 WriteUpQuartzLap(Canvas canvas, Vector3 world)
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, world, canvas.GetComponent<Camera>(), out position);
        return position;
    }
    public void MayPace(double cash, Transform objTrans = null)
    {
        ScamFiveExplain.AirExpertly().NowEpoch(cash);
        PaceMayInfantile(objTrans, 5);
    }
    private void PaceMayInfantile(Transform startTransform, double num)
    {
      
            if(StrikeUtil.WeGrade())
            {
  MayInfantile(startTransform, Overcrowd.transform, Overcrowd.gameObject, FleeIts,
            ScamFiveExplain.AirExpertly().WokEpoch(), num);
            }
            else{
  MayInfantile(startTransform, LilyImg.transform, LilyImg.gameObject, LilyWanExam,
            ScamFiveExplain.AirExpertly().WokEpoch(), num);
            }
    }
    private void MayInfantile(Transform startTransform, Transform endTransform, GameObject icon, Text text,
       double textValue, double num)
    {
        if (startTransform != null)
        {
            InfantileMercantile.PoemGoldAiry(icon, Mathf.Max((int)num, 1), startTransform, endTransform,
                () =>
                {
                    ///ExertEka.GetInstance().PlayEffect(ExertMold.SceneMusic.sound_getcoin);
                    InfantileMercantile.ParentIonize(double.Parse(text.text), textValue, 0.1f, text,
                        () => { text.text = IonizeSeal.ColumnUpIts(textValue); });
                });
        }
        else
        {
            InfantileMercantile.ParentIonize(double.Parse(text.text), textValue, 0.1f, text,
                () => { text.text = IonizeSeal.ColumnUpIts(textValue); });
        }
    }

    private void RobinTorporLotus()
    {
        List<DayRewardData> GunTorporDatas= new List<DayRewardData>();
        string[] datas = new string[4];
        datas = OpenFiveExplain.AirRecoilNiche(CStatus.Be_RobinTorpor);
        long nowtime = GameUtil.GetNowTime();
        bool redState = false;
        for (int i = 0; i < datas.Length; i++)
        {
            string data = datas[i];
            DayRewardData dayData = JsonMapper.ToObject<DayRewardData>(data);
            GunTorporDatas.Add(dayData);
            DayRewardData deforRewardData = GunTorporDatas.Find(x => x.dataIndex == (i - 1));
            bool beforGet = true;
            if (deforRewardData != null)
            {
                beforGet = deforRewardData.getState == 1;
            }
            if (nowtime > dayData.look_time)
            {
                if (dayData.getState == 0)
                {
                    redState = true;
                    break;
                }
            }
            else
            {
                if (beforGet == true)
                {
                    if (LoveDose != 0)
                    {
                        CrashExplain.Expertly.StopCrash(LoveDose);
                    }
                    LoveDose = CrashExplain.Expertly.LotusCrash(1, () => //启动计时器
                    {
                        int times = dayData.look_time - (int)GameUtil.GetNowTime();
                        if (times <= 0)
                        {
                            Debug.Log("计时完成");
                            CrashExplain.Expertly.StopCrash(LoveDose);
                            GetLoveSewBrass.SetActive(true);
                        }
                    }, true);
                    break;
                }
            }
        }
        GetLoveSewBrass.SetActive(redState);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            UIExplain.AirExpertly().HaleUIProwl(nameof(NotGrope));
        }
        // 测试用：按下B键切换到下一关
        if (Input.GetKeyDown(KeyCode.B))
        {
            // 关卡号自增并保存
            Mkey.GameLevelHolder.SetCurrentLevelAndSave(Mkey.GameLevelHolder.CurrentLevel + 1);
            // 先清理旧麻将牌对象
            if (GameBoard.Instance != null)
            {
                GameBoard.Instance.DestroyGrid(); // 清理旧麻将
                GameBoard.Instance.CreateGameBoard(); // 用新关卡号重建关卡
            }
            // 触发关卡开始事件，刷新UI（包括GameLevelHelper等）
            Mkey.GameLevelHolder.StartLevel();
            // 刷新主界面关卡号显示

        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            UIExplain.AirExpertly().HaleUIProwl(nameof(NotGrope));
        }

    }

    /// <summary>
    /// 刷新关卡文本，显示当前关卡号
    /// </summary>
    public void PaymentSolveExam()
    {
        if (SolveExam != null)
        {
            int level = Mkey.GameLevelHolder.CurrentLevel; // 获取当前关卡号
            SolveExam.text = $"LEVEL {level + 1}"; // 设置关卡文本
        }
    }

    /// <summary>
    /// 静态方法，供外部调用刷新关卡文本
    /// </summary>
    public static void StaticPaymentSolveExam()
    {
        if (Instance != null)
        {
            Instance.PaymentSolveExam();
        }
    }

    /// <summary>
    /// 让CashoutBtn移出屏幕显示范围，然后等待指定时间后移回原位置
    /// </summary>
    /// <param name="waitTime">等待时间（秒）</param>
    /// <param name="moveOutDuration">移出动画时长（秒）</param>
    /// <param name="moveInDuration">移入动画时长（秒）</param>
    /// <param name="onComplete">动画完成回调</param>
    public void RussianTenuousYam(float waitTime = 2f, float moveOutDuration = 0.7f, float moveInDuration = 0.5f, Action onComplete = null)
    {
        if (TenuousYam == null)
        {
            Debug.LogError("CashoutBtn is null!");
            onComplete?.Invoke();
            return;
        }

        // 停止之前的动画
        TenuousYam.DOKill();

        // 第一步：移出屏幕（Y轴移动到300）
        Vector2 moveOutPosition = new Vector2(TenuousYam.anchoredPosition.x, 300f);

        TenuousYam.DOAnchorPos(moveOutPosition, moveOutDuration)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                // 第二步：等待指定时间
                DOVirtual.DelayedCall(waitTime, () =>
                {
                    // 第三步：移回原位置
                    TenuousYam.DOAnchorPos(BuildingTenuousYamSplinter, moveInDuration)
                        .SetEase(Ease.InOutQuad)
                        .OnComplete(() =>
                        {
                            onComplete?.Invoke();
                        });
                });
            });
    }

    /// <summary>
    /// 让CashoutBtn移出屏幕显示范围，然后等待指定时间后移回原位置（简化版本）
    /// </summary>
    /// <param name="waitTime">等待时间（秒）</param>
    /// <param name="onComplete">动画完成回调</param>
    public void RussianTenuousYamSimple(float waitTime = 0.1f, Action onComplete = null)
    {
        RussianTenuousYam(waitTime, 0.5f, 0.5f, onComplete);
    }
    private void OnDestroy()
    {
        // 记得移除监听，避免内存泄漏
        GameEvents.WinLevelAction -= OnLevelComplete;
        GameEvents.ShowTipAction -= OnShowTip;
        GameEvents.ShowTipManualAction -= OnShowTipManual;
        GameEvents.HideTipAction -= OnHideTip;
        // 新增：移除新手引导事件监听
        GameEvents.TutorialGuideStartedAction -= OnTutorialGuideStarted;
        GameEvents.TutorialGuideEndedAction -= OnTutorialGuideEnded;
    }

    // 新增：新手引导开始时禁用按钮
    private void OnTutorialGuideStarted()
    {
        if (WineYam != null) WineYam.interactable = false;
        if (RadiateYam != null) RadiateYam.interactable = false;
    }
    // 新增：新手引导结束时恢复按钮
    private void OnTutorialGuideEnded()
    {
        if (WineYam != null) WineYam.interactable = true;
        if (RadiateYam != null) RadiateYam.interactable = true;
    }
}
