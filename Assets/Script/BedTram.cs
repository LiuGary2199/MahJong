using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BedTram : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("FlyButton")]    public Button BedSenate;
[UnityEngine.Serialization.FormerlySerializedAs("CashValue")]    public Text PaceLucky;

    private Sequence _Her1;
    private Sequence _Her2;

    private double _LilyWan;

    private void Awake()
    {
        BedSenate.onClick.AddListener(() => {
            //if (NewbieManager.GetInstance().IsOpenNewbie) { return; }
            //if (BubbleManager.GetInstance().IsWinGame()) { return; }
            BedExplain.Instance.OfLiftBed = true;
            BedExplain.Instance.LiftIEBed();
            PorkTruckRevere.AirExpertly().FastTruck("1011");
            AirTorpor();

        });
        LowPeatAnswer();
    }


    public void BedEpic()
    {
        transform.DOPlay();
        _Her1.Play();
        _Her2.Play();
    }

    public void BedSieve()
    {
        transform.DOPause();
        _Her1.Pause();
        _Her2.Pause();
    }

    public void BedPlug()
    {
        _Her1.Kill();
        _Her2.Kill();
        transform.DOKill();
    }

    private void AirTorpor()
    {
        //RewardPanelData data = new RewardPanelData();
        //data.MiniType = "Fly";
        //data.Dic_Reward.Add(RewardType.cash, _cashNum);
        //RewardManager.GetInstance().OpenLevelCompletePanel(data);
        ADExplain.Expertly.FoilTorporWeary((success) =>
        {
            if (success)
            {
                AideBelle.Instance.MayPace(_LilyWan, this.transform);
                SurgeonBedTram();
                 PorkTruckRevere.AirExpertly().FastTruck("1009");
            }
        }, "5");
    }

    private void LowPeatAnswer()
    {
        _LilyWan = PinBeadEka.instance.ScamFive.bubbledatalist[0].reward_num * GameUtil.GetCashMulti();
        _LilyWan = Mathf.Ceil((float)_LilyWan);
        PaceLucky.text = "+" + _LilyWan;
        _Her1 = DOTween.Sequence();
        _Her2 = DOTween.Sequence();
        /*int leftOrRight = Random.Range(0, 2);
        if (leftOrRight == 0)
        {*/
            DiscBed();
        /*}
        else
        {
            RigthFly();
        }*/
    }

    private void DiscBed()
    {
        transform.localPosition = new Vector3(-450f, 0, 0);
        _Her1 = DOTween.Sequence();
        _Her2 = DOTween.Sequence();
        _Her1.Append(transform.DOLocalMoveY(-250f - Random.Range(-100f, 100f), 2.5f).SetEase(Ease.InSine));
        _Her1.Append(transform.DOLocalMoveY(0, 2.5f).SetEase(Ease.InSine));
        _Her1.SetLoops(-1);
        _Her1.Play();

        _Her2.Append(transform.DOScale(1.1f, 0.5f).SetEase(Ease.Linear));
        _Her2.Append(transform.DOScale(1f, 0.5f).SetEase(Ease.Linear));
        _Her2.SetLoops(-1);
        _Her2.Play();
        transform.DOLocalMoveX(650, 10f).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (BedExplain.Instance.OfLiftBed)
            {
                SurgeonBedTram();
            }
            else
            {
                BedPlug();
                StartCoroutine(HaulBed(() => { GripeBed(); }));
            }
        });
    }

    private void GripeBed()
    {
        transform.localPosition = new Vector3(450, 100, 0);
        _Her1 = DOTween.Sequence();
        _Her2 = DOTween.Sequence();
        _Her1.Append(transform.DOLocalMoveY(0, 2.5f).SetEase(Ease.InSine));
        _Her1.Append(transform.DOLocalMoveY(100, 2.5f).SetEase(Ease.InSine));
        _Her1.SetLoops(-1);
        _Her1.Play();

        _Her2.Append(transform.DOScale(1.1f, 0.5f).SetEase(Ease.Linear));
        _Her2.Append(transform.DOScale(1f, 0.5f).SetEase(Ease.Linear));
        _Her2.SetLoops(-1);
        _Her2.Play();
        transform.DOLocalMoveX(-650, 10f).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (BedExplain.Instance.OfLiftBed)
            {
                SurgeonBedTram();
            }
            else
            {
                BedPlug();
                StartCoroutine(HaulBed(() => { DiscBed(); }));
            }

        });
    }

    IEnumerator HaulBed(Action action)
    {
        yield return new WaitForSeconds(5f);
        action?.Invoke();
    }

    public void SurgeonBedTram()
    {
        BedPlug();
        GetComponent<RectTransform>().DOKill();
        Destroy(gameObject);
    }

}
