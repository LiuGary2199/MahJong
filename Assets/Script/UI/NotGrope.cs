using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Mkey;
using UnityEngine;
using UnityEngine.UI;

public class NotGrope : CoaxUIProwl
{
[UnityEngine.Serialization.FormerlySerializedAs("AD_Button")]    public Button AD_Senate;
[UnityEngine.Serialization.FormerlySerializedAs("Restart_Button")]    public Button Onstage_Senate;
[UnityEngine.Serialization.FormerlySerializedAs("Use_Button")]    public Button Fog_Senate;

    [Header("倒计时精灵")]
[UnityEngine.Serialization.FormerlySerializedAs("countdownSprites")]    public Image[] OverprintRapidly; // 5,4,3,2,1 倒计时精灵
[UnityEngine.Serialization.FormerlySerializedAs("countdownInterval")]    public float OverprintCompound= 1f; // 倒计时间隔时间

    private Coroutine OverprintStonework;
[UnityEngine.Serialization.FormerlySerializedAs("AppleAD_Button")]
    public Button GradeAD_Senate;
[UnityEngine.Serialization.FormerlySerializedAs("AppleCoin_Button")]    public Button GradeFlee_Senate;



    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        AD_Senate.gameObject.SetActive(false);
        Fog_Senate.gameObject.SetActive(false);





        int shuffles = ShuffleHolder.Count; // 重洗次数
        /* 
        if (shuffles > 0)
         {
             Use_Button.gameObject.SetActive(true);
         }
         else
         {
             AD_Button.gameObject.SetActive(true);
         }
         */
        AD_Senate.gameObject.SetActive(true);

        if (StrikeUtil.WeGrade())
        {
            AD_Senate.gameObject.SetActive(false);
            GradeAD_Senate.gameObject.SetActive(true);
            GradeFlee_Senate.gameObject.SetActive(true);

        }
        else
        {
            AD_Senate.gameObject.SetActive(true);
            GradeAD_Senate.gameObject.SetActive(false);
            GradeFlee_Senate.gameObject.SetActive(false);

        }

        // 开始倒计时
        LotusBroadleaf();
    }

    // 开始倒计时
    private void LotusBroadleaf()
    {
        if (OverprintStonework != null)
        {
            StopCoroutine(OverprintStonework);
        }
        OverprintStonework = StartCoroutine(BroadleafStonework());
    }

    // 倒计时协程
    private IEnumerator BroadleafStonework()
    {
        // 隐藏所有倒计时精灵
        foreach (var sprite in OverprintRapidly)
        {
            if (sprite != null)
                sprite.gameObject.SetActive(false);
        }

        // 从5开始倒计时
        for (int i = 5; i >= 1; i--)
        {
            // 显示对应的倒计时精灵
            if (OverprintRapidly != null && i - 1 < OverprintRapidly.Length && OverprintRapidly[i - 1] != null)
            {
                OverprintRapidly[i - 1].gameObject.SetActive(true);
                Debug.Log($"显示倒计时精灵: {i}");
            }

            // 等待倒计时间隔
            yield return new WaitForSeconds(OverprintCompound);

            // 隐藏当前倒计时精灵
            if (OverprintRapidly != null && i - 1 < OverprintRapidly.Length && OverprintRapidly[i - 1] != null)
            {
                OverprintRapidly[i - 1].gameObject.SetActive(false);
            }
        }

        // 倒计时结束，自动选择Restart_Button
        Debug.Log("倒计时结束，自动选择Restart_Button");
        Onstage_Senate.onClick.Invoke();
    }

    // 停止倒计时
    private void FastBroadleaf()
    {
        if (OverprintStonework != null)
        {
            StopCoroutine(OverprintStonework);
            OverprintStonework = null;
        }

        // 隐藏所有倒计时精灵
        foreach (var sprite in OverprintRapidly)
        {
            if (sprite != null)
                sprite.gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GradeAD_Senate.onClick.AddListener(() =>
     {
         FastBroadleaf(); // 停止倒计时
         ADExplain.Expertly.FoilTorporWeary((success) =>
         {
             if (success)
             {
                 GameBoard.Instance.ShuffleGrid(null); // 执行重洗网格逻辑
                 DelayUIFine(GetType().Name);
             }
         }, "6");
         PorkTruckRevere.AirExpertly().FastTruck("1007", "1");

     });
        GradeFlee_Senate.onClick.AddListener(() =>
    {
        double munber = ScamFiveExplain.AirExpertly().WokEpoch();
        if (munber >= 200)
        {
            FastBroadleaf(); // 停止倒计时
            ScamFiveExplain.AirExpertly().NowEpoch(-200);
             AideBelle.Instance.MayPace(0, null);
            GameBoard.Instance.ShuffleGrid(null); // 执行重洗网格逻辑
            DelayUIFine(GetType().Name);
        }else{
            	UIExplain.AirExpertly().HaleUIProwl(nameof(Evoke), "Diamond shortage");
        }
    });

        AD_Senate.onClick.AddListener(() =>
        {
            FastBroadleaf(); // 停止倒计时
            ADExplain.Expertly.FoilTorporWeary((success) =>
            {
                if (success)
                {
                    GameBoard.Instance.ShuffleGrid(null); // 执行重洗网格逻辑
                    DelayUIFine(GetType().Name);
                }
            }, "6");
            PorkTruckRevere.AirExpertly().FastTruck("1007", "1");

        });
        Fog_Senate.onClick.AddListener(() =>
        {
            FastBroadleaf(); // 停止倒计时
            // 使用重洗道具的逻辑
            GameBoard.Instance.ShuffleGrid(null); // 执行重洗网格逻辑
            ShuffleHolder.Add(-1); // 减少一个重洗道具
            GameEvents.ApplyShuffleAction?.Invoke();
            DelayUIFine(GetType().Name);

        });

        Onstage_Senate.onClick.AddListener(() =>
        {
            FastBroadleaf(); // 停止倒计时
            ScamExplain.Instance.OnstageScam();
            DOVirtual.DelayedCall(0.5f, () =>  //停顿
            {
                DelayUIFine(GetType().Name);
            });

            PorkTruckRevere.AirExpertly().FastTruck("1007", "0");

        });

    }

    // 当UI关闭时停止倒计时
    public override void Hidding(System.Action finish = null)
    {
        FastBroadleaf();
        base.Hidding(finish);
    }
}
