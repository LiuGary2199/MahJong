using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TorporDewBelle : CoaxUIProwl
{
    [Header("按钮")]
[UnityEngine.Serialization.FormerlySerializedAs("ADButton")]    public Button ADSenate;
[UnityEngine.Serialization.FormerlySerializedAs("NextLevelButton")]    public Button HandSolveSenate;
[UnityEngine.Serialization.FormerlySerializedAs("RewardText")]    public Text TorporExam;
[UnityEngine.Serialization.FormerlySerializedAs("rewardTrans")]    public Transform HungryBadly;
    private double HungryLucky;
[UnityEngine.Serialization.FormerlySerializedAs("parObj")]
    public GameObject BowYew;
    private bool EkeNaturalAdYam;
[UnityEngine.Serialization.FormerlySerializedAs("adobj")]
    public GameObject Fluid;
[UnityEngine.Serialization.FormerlySerializedAs("adrettrfansform")]    public RectTransform Psychologically;
[UnityEngine.Serialization.FormerlySerializedAs("tween")]    public Tween Egypt;

    // Start is called before the first frame update
    void Start()
    {
        ADSenate.onClick.AddListener(() =>
        {
            ADSenate.enabled = false;
            HandSolveSenate.enabled = false;
            if (OfAxeShip())
            {
                OpenFiveExplain.BisSlay(CStatus.Be_LoverDewTorpor, false);
                WanDull();
            }
            else
            {
                ADExplain.Expertly.FoilTorporWeary((success) =>
                    {

                        if (success)
                        {
                            OpenFiveExplain.BisSlay(CStatus.Be_LoverDewTorpor, false);
                            WanDull();
                        }
                        else
                        {
                            ADSenate.enabled = true;
                            HandSolveSenate.enabled = true;
                        }
                    }, "1");
                if (OfAxeGod())
                {
                    PorkTruckRevere.AirExpertly().FastTruck("1003", "1");
                    OpenFiveExplain.BisSlay("newgold", false);
                }
            }

        });

        HandSolveSenate.onClick.AddListener(() =>
        {
            ADSenate.enabled = false;
            HandSolveSenate.enabled = false;
            AideBelle.Instance.MayPace(HungryLucky, HungryBadly);
            ADExplain.Expertly.NoThanksMayCrack();
            DelayUIFine(GetType().Name);

            if (!OfAxeShip())
            {
                if (OfAxeGod())
                {
                    PorkTruckRevere.AirExpertly().FastTruck("1003", "0");
                    OpenFiveExplain.BisSlay("newgold", false);
                }
            }
        });
    }


    public void WanDull()
    {
        InfantileMercantile.ParentIonize(HungryLucky, HungryLucky * 5, 0, TorporExam, "+", () =>
           {
               HungryLucky = HungryLucky * 5;
               TorporExam.text = "+" + IonizeSeal.ColumnUpIts(HungryLucky);
               EkeNaturalAdYam = true;
               AideBelle.Instance.MayPace(HungryLucky, HungryBadly);
               DOVirtual.DelayedCall(0.5f, () =>
               {
                   DelayUIFine(GetType().Name);
               });
           });
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        BowYew.SetActive(false);
        BowYew.SetActive(true);
        ADSenate.enabled = true;
        HandSolveSenate.enabled = true;
        HandSolveSenate.gameObject.SetActive(false);
        HungryLucky = IonizeSeal.LessPolymerUpColumn(uiFormParams);
        TorporExam.text = "+" + IonizeSeal.PolymerThenGatewayHit(uiFormParams);
        if (OfAxeShip())
        {
            Fluid.SetActive(false);
            Psychologically.anchoredPosition = new Vector2(0, 0);
        }
        else
        {
            Fluid.SetActive(true);
            Psychologically.anchoredPosition = new Vector2(41.35f, 0);
        }
        Egypt?.Kill();
        Egypt = DOVirtual.DelayedCall(1f, () =>
        {
            Egypt?.Kill();
              if (!OfAxeShip())
            {
            HandSolveSenate.gameObject.SetActive(true);}
        });
    }
    public override void Hidding()
    {
        base.Hidding();
        HaleSoulOrBelle();
    }
    private void HaleSoulOrBelle()
    {
        if (StrikeUtil.WeGrade())
        {
            return;
        }
        if (OpenFiveExplain.AirRecoil(CStatus.Be_Bike_Feed_Most_us) != "done")
        {
            LiftUIFine(nameof(SoulOrBelle));
            OpenFiveExplain.BisRecoil(CStatus.Be_Bike_Feed_Most_us, "done");

        }

    }

    private bool OfAxeShip()
    {
        return !PlayerPrefs.HasKey(CStatus.Be_LoverDewTorpor + "Bool") || OpenFiveExplain.AirSlay(CStatus.Be_LoverDewTorpor);
    }
    private bool OfAxeGod()
    {
        return !PlayerPrefs.HasKey("newgold" + "Bool") || OpenFiveExplain.AirSlay("newgold");
    }



}
