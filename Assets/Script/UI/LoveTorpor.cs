using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using UnityEngine.UI;

public class LoveTorpor : CoaxUIProwl
{
[UnityEngine.Serialization.FormerlySerializedAs("CloseButton")]    public Button DelaySenate;
[UnityEngine.Serialization.FormerlySerializedAs("timeRewardItems")]    public List<LoveTorporSpoon> RestTorporSpoon;
    List<DayRewardData> GunTorporDatas= new List<DayRewardData>();

    // Start is called before the first frame update
    void Start()
    {
        DelaySenate.onClick.AddListener(() =>
        {
            DelayUIFine(GetType().Name);
        });
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        for (int i = 0; i < RestTorporSpoon.Count; i++)
        {
            LoveTorporSpoon rewardItem = RestTorporSpoon[i];
            rewardItem.User();
        }
        PitLoveTorpor();
    }

    public void AirTorpor(int rewardIndex)
    {
        double reward = GunTorporDatas[rewardIndex].reward_num;
        AideBelle.Instance.MayPace(reward);
    }
    public void ButFive()
    {
        string[] datas = new string[4];
        for (int i = 0; i < GunTorporDatas.Count; i++)
        {
            DayRewardData oldData = GunTorporDatas[i];
            string jsondata = JsonMapper.ToJson(oldData);
            datas[i] = jsondata;
        }
        OpenFiveExplain.BisRecoilNiche(CStatus.Be_RobinTorpor, datas);
        SeepageGrassy.FastSeepage(CStatus.So_CosmicGetTorpor, null);
    }

    public void PitLoveTorpor()
    {
        GunTorporDatas.Clear();
        string[] datas = new string[4];
        datas = OpenFiveExplain.AirRecoilNiche(CStatus.Be_RobinTorpor);
        long nowtime = GameUtil.GetNowTime();
        bool redState = false;
        for (int i = 0; i < datas.Length; i++)
        {
            string data = datas[i];
            LoveTorporSpoon rewardItem = RestTorporSpoon[i];
            DayRewardData dayData = JsonMapper.ToObject<DayRewardData>(data);
            GunTorporDatas.Add(dayData);
            rewardItem.AnAirStatus = null;
            rewardItem.AnAirStatus = (ItemIndex) =>
            {
                PorkTruckRevere.AirExpertly().FastTruck("1008", (ItemIndex + 1).ToString());
                GunTorporDatas[ItemIndex].getState = 1;
                AirTorpor(ItemIndex);
                ButFive();
                PitLoveTorpor();
            };

            rewardItem.AnAnStatus = null;
            rewardItem.AnAnStatus = (ItemIndex) =>
            {
                GunTorporDatas[ItemIndex].look_num += 1;
                ButFive();
                PitLoveTorpor();
            };
            DayRewardData deforRewardData = GunTorporDatas.Find(x => x.dataIndex == (i - 1));
            bool beforGet = true;
            if (deforRewardData != null)
            {
                beforGet = deforRewardData.getState == 1;
            }
            rewardItem.PitTram(dayData, beforGet);
            if (dayData.look_time > nowtime && beforGet)
            {

            }
        }
    }
}
