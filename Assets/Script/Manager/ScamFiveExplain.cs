using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScamFiveExplain : SomeReykjavik<ScamFiveExplain>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UserScamFive()
    {
#if SOHOShop
        // 提现商店初始化
        // 提现商店中的金币、现金和amazon卡均为double类型，参数请根据具体项目自行处理
        SOHOShopManager.instance.InitSOHOShopAction(
            getToken,
            getGold, 
            getAmazon,    // amazon
            (subToken) => { addToken(-subToken); }, 
            (subGold) => { addGold(-subGold); }, 
            (subAmazon) => { addAmazon(-subAmazon); });
#endif
    }

    // 金币
    public double WokPoem()
    {

        return OpenFiveExplain.AirColumn(CStatus.Be_PoemFlee);
    }

    public void NowPoem(double gold)
    {
        NowPoem(gold, LoneExplain.instance.transform);
    }

    public void NowPoem(double gold, Transform startTransform)
    {
        double oldGold = OpenFiveExplain.AirColumn(CStatus.Be_PoemFlee);
        OpenFiveExplain.BisColumn(CStatus.Be_PoemFlee, oldGold + gold);
        if (gold > 0)
        {
            OpenFiveExplain.BisColumn(CStatus.Be_HandsomelyPoemFlee, OpenFiveExplain.AirColumn(CStatus.Be_HandsomelyPoemFlee) + gold);
        }
        SeepageFive md = new SeepageFive(oldGold);
        md.NightPresident = startTransform;
        SeepageCenterBrine.AirExpertly().Fast(CStatus.So_Go_Narrate, md);
    }
    
    // 现金
    public double WokEpoch()
    {
        //return OpenFiveExplain.GetDouble(CStatus.sv_Token);
        return CashOutManager.AirExpertly().Money;
    }

    public void NowEpoch(double token)
    {
        CashOutManager.AirExpertly().AddMoney((float)token);
    
    //addToken(token, LoneExplain.instance.transform);
    }
    public void NowEpoch(double token, Transform startTransform)
    {
        double oldToken = PlayerPrefs.HasKey(CStatus.Be_Epoch) ? double.Parse(OpenFiveExplain.AirRecoil(CStatus.Be_Epoch)) : 0;
        double newToken = oldToken + token;
        OpenFiveExplain.BisColumn(CStatus.Be_Epoch, newToken);
        if (token > 0)
        {
            double allToken = OpenFiveExplain.AirColumn(CStatus.Be_HandsomelyEpoch);
            OpenFiveExplain.BisColumn(CStatus.Be_HandsomelyEpoch, allToken + token);
        }
#if SOHOShop
        SOHOShopManager.instance.UpdateCash();
#endif
        SeepageFive md = new SeepageFive(oldToken);
        md.NightPresident = startTransform;
        SeepageCenterBrine.AirExpertly().Fast(CStatus.So_Go_Thousand, md);
    }

    //Amazon卡
    public double WokInflow()
    {
        return OpenFiveExplain.AirColumn(CStatus.Be_Inflow);
    }

    public void NowInflow(double amazon)
    {
        NowInflow(amazon, LoneExplain.instance.transform);
    }
    public void NowInflow(double amazon, Transform startTransform)
    {
        double oldAmazon = PlayerPrefs.HasKey(CStatus.Be_Inflow) ? double.Parse(OpenFiveExplain.AirRecoil(CStatus.Be_Inflow)) : 0;
        double newAmazon = oldAmazon + amazon;
        OpenFiveExplain.BisColumn(CStatus.Be_Inflow, newAmazon);
        if (amazon > 0)
        {
            double allAmazon = OpenFiveExplain.AirColumn(CStatus.Be_HandsomelyInflow);
            OpenFiveExplain.BisColumn(CStatus.Be_HandsomelyInflow, allAmazon + amazon);
        }
        SeepageFive md = new SeepageFive(oldAmazon);
        md.NightPresident = startTransform;
        SeepageCenterBrine.AirExpertly().Fast(CStatus.So_Go_Cheerless, md);
    }
}
