using System.Collections;
using System.Collections.Generic;
using Mkey;
using UnityEngine;

public class LoneExplain : MonoBehaviour
{
    public static LoneExplain instance;

    private bool Shaft= false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CrabUser()
    {

        bool isNewPlayer = !PlayerPrefs.HasKey(CStatus.Be_WeAxeMexico + "Bool") || OpenFiveExplain.AirSlay(CStatus.Be_WeAxeMexico);
        MarvelUserExplain.Instance.UserMarvelFive(isNewPlayer);
        if (isNewPlayer)
        {
            // 新用户
            OpenFiveExplain.BisSlay(CStatus.Be_WeAxeMexico, false);
        }


        GameUtil.IsSameDayAsLastCheck();//每日奖励检测

        //ExertEka.GetInstance().PlayBg(ExertMold.SceneMusic.Sound_BGM);
        PorkTruckRevere.AirExpertly().FastTruck("1001");
        UIExplain.AirExpertly().HaleUIProwl(nameof(AideBelle));

        ScamFiveExplain.AirExpertly().UserScamFive();

        Shaft = true;

        //ActivityAutoOpenManager.Instance.OpenPanel(1);
    }

}
