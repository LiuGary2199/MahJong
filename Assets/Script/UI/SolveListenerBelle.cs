using System.Collections;
using System.Collections.Generic;
using Mkey;
using UnityEngine;
using UnityEngine.UI;
using Spine;
using Spine.Unity;
using DG.Tweening;

public class SolveListenerBelle : CoaxUIProwl
{
    [Header("按钮")]
[UnityEngine.Serialization.FormerlySerializedAs("ADButton")]    public Button ADSenate;
[UnityEngine.Serialization.FormerlySerializedAs("NextLevelButton")]    public Button HandSolveSenate;
[UnityEngine.Serialization.FormerlySerializedAs("ADText")]    public GameObject ADExam;
    [Header("转盘组")]
[UnityEngine.Serialization.FormerlySerializedAs("SlotBG")]    public HoleAdorn HoleBG;
[UnityEngine.Serialization.FormerlySerializedAs("RewardCashImage")]
    public GameObject TorporPaceNoisy;
[UnityEngine.Serialization.FormerlySerializedAs("RewardGoldImage")]    public GameObject TorporPoemNoisy;
[UnityEngine.Serialization.FormerlySerializedAs("RewardText")]    public Text TorporExam;

    private double HungryLucky;
    private bool EkeNaturalAdYam;
[UnityEngine.Serialization.FormerlySerializedAs("grtMoreRect")]    public RectTransform RayWeakEach;
[UnityEngine.Serialization.FormerlySerializedAs("m_SkeletonGraphic")]    public SkeletonGraphic m_DiscoverPercent;
[UnityEngine.Serialization.FormerlySerializedAs("tween")]    // Start is called before the first frame update

    public Tween Egypt;
    void Start()
    {
        // 监听动画结束事件
        m_DiscoverPercent.AnimationState.Complete += OnAnimationComplete;
        ADSenate.onClick.AddListener(() =>
        {
            ADSenate.enabled = false;
            HandSolveSenate.enabled = false;
            if (OfAxeShip())
            {
                FoilHole();
            }
            else
            {
                ADExplain.Expertly.FoilTorporWeary((success) =>
                    {
                        if (success)
                        {
                            FoilHole();
                        }
                        else
                        {
                            ADSenate.enabled = true;
                            HandSolveSenate.enabled = true;
                        }
                    }, "2");
                if (OfAxeErie())
                {
                    PorkTruckRevere.AirExpertly().FastTruck("1004", "1");
                    OpenFiveExplain.BisSlay("newpass", false);

                }

            }
        });

        HandSolveSenate.onClick.AddListener(() =>
        {
            HandSolveSenate.enabled = false;
            AideBelle.Instance.MayPace(HungryLucky, TorporPaceNoisy.transform);
            if (!EkeNaturalAdYam)
            {
                ADExplain.Expertly.NoThanksMayCrack();
            }

            DelayUIFine(GetType().Name);

            if (!OfAxeShip())
            {
                if (OfAxeErie())
                {
                    PorkTruckRevere.AirExpertly().FastTruck("1004", "0");
                    OpenFiveExplain.BisSlay("newpass", false);
                }
            }
        });
    }
    public void BeHand()
    {
        HandSolveSenate.enabled = false;
        AideBelle.Instance.MayPace(HungryLucky, TorporPaceNoisy.transform);
        if (!EkeNaturalAdYam)
        {
            ADExplain.Expertly.NoThanksMayCrack();
        }

        DelayUIFine(GetType().Name);

        if (!OfAxeShip())
        {
            if (OfAxeErie())
            {
                PorkTruckRevere.AirExpertly().FastTruck("1004", "0");
                OpenFiveExplain.BisSlay("newpass", false);
            }
        }
    }



    private void OnAnimationComplete(TrackEntry trackEntry)
    {
        if (trackEntry != null)
        {
            if (trackEntry.Animation.Name == "1start")
            {
                m_DiscoverPercent.AnimationState.SetAnimation(0, "2idle", true);
            }
        }

    }

    public void HandScam()
    {
        ScamExplain.Instance.m_PeartCrack = 0;
        //ScamExplain.Instance.NextGame();
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

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        HandSolveSenate.gameObject.SetActive(false);
        m_DiscoverPercent.AnimationState.ClearTracks();
        m_DiscoverPercent.AnimationState.SetAnimation(0, "1start", false);
        ADSenate.enabled = true;
        HandSolveSenate.enabled = true;
        if (OfAxeShip())
        {
            ADExam.SetActive(false);
            RayWeakEach.anchoredPosition = new Vector2(0, 0);
            HandSolveSenate.gameObject.SetActive(false);
        }
        else
        {
            ADExam.SetActive(true);
            RayWeakEach.anchoredPosition = new Vector2(41.35f, 0);
        }
        EkeNaturalAdYam = false;

        // 根据实际项目计算奖励
        //rewardValue = StrikeUtil.IsApple() ? PinBeadEka.instance.InitData.box_gold_price * GameUtil.GetGoldMulti() : PinBeadEka.instance.InitData.passlevel_cash_price * GameUtil.GetCashMulti();
        HungryLucky = PinBeadEka.instance.ScamFive.leveldatalist[0].reward_num * GameUtil.GetCashMulti();
        //rewardValue = 1 * GameUtil.GetCashMulti();
        TorporExam.text = "+" + IonizeSeal.ColumnUpIts(HungryLucky);

        HoleBG.initScrub();
        Egypt = DOVirtual.DelayedCall(2f, () =>
       {
           Egypt?.Kill();
           if (!OfAxeShip())
           {
               HandSolveSenate.gameObject.SetActive(true);
           }

       });
        DOVirtual.DelayedCall(1f, () =>
        {
            HandScam();
        });

    }

    private bool OfAxeShip()
    {
        return !PlayerPrefs.HasKey(CStatus.Be_LoverHole + "Bool") || OpenFiveExplain.AirSlay(CStatus.Be_LoverHole);
    }
    // 计算本次slot应该获得的奖励
    private int WokHoleScrubElect()
    {
        // 新用户，第一次固定翻5倍
        if (OfAxeShip())
        {
            int index = 0;
            foreach (SlotItem wg in PinBeadEka.instance.UserFive.slot_group)
            {
                if (wg.multi == 5)
                {
                    return index;
                }
                index++;
            }
        }
        else
        {
            int sumWeight = 0;
            foreach (SlotItem wg in PinBeadEka.instance.UserFive.slot_group)
            {
                sumWeight += wg.weight;
            }
            int r = Random.Range(0, sumWeight);
            int nowWeight = 0;
            int index = 0;
            foreach (SlotItem wg in PinBeadEka.instance.UserFive.slot_group)
            {
                nowWeight += wg.weight;
                if (nowWeight > r)
                {
                    return index;
                }
                index++;
            }

        }
        return 0;
    }
    public override void Hidding()
    {
        base.Hidding();
        m_DiscoverPercent.AnimationState.SetAnimation(1, "3end", false);
    }

    private void FoilHole()
    {
        HandSolveSenate.enabled = false;
        ADSenate.enabled = false;
        int index = WokHoleScrubElect();
        HoleBG.Look(index, (multi) =>
        {
            // slot结束后的回调
            InfantileMercantile.ParentIonize(HungryLucky, HungryLucky * multi, 0, TorporExam, "+", () =>
            {
                HungryLucky = HungryLucky * multi;
                TorporExam.text = "+" + IonizeSeal.ColumnUpIts(HungryLucky);
                EkeNaturalAdYam = true;
                DOVirtual.DelayedCall(0.5f, () =>
              {
                  BeHand();
              });


            });
        });

        OpenFiveExplain.BisSlay(CStatus.Be_LoverHole, false);
    }
    private bool OfAxeErie()
    {
        return !PlayerPrefs.HasKey("newpass" + "Bool") || OpenFiveExplain.AirSlay("newpass");
    }

}
