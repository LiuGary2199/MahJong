using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulOrBelle : CoaxUIProwl
{
[UnityEngine.Serialization.FormerlySerializedAs("Stars")]    public Button[] Forty;
[UnityEngine.Serialization.FormerlySerializedAs("star1Sprite")]    public Sprite Bulb1Subway;
[UnityEngine.Serialization.FormerlySerializedAs("star2Sprite")]    public Sprite Bulb2Subway;
[UnityEngine.Serialization.FormerlySerializedAs("CLoseBtn")]    public Button CLoseYam;


    // Start is called before the first frame update
    void Start()
    {
        foreach (Button star in Forty)
        {
            star.onClick.AddListener(() =>
            {
                string indexStr = System.Text.RegularExpressions.Regex.Replace(star.gameObject.name, @"[^0-9]+", "");
                int index = indexStr == "" ? 0 : int.Parse(indexStr);
                CedarLotus(index);
                PorkTruckRevere.AirExpertly().FastTruck("1010", (index + 1).ToString());

            });
        }
        CLoseYam.onClick.AddListener(() =>
        {
            DelayUIFine(GetType().Name);
        });
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        for (int i = 0; i < 5; i++)
        {
            Forty[i].gameObject.GetComponent<Image>().sprite = Bulb2Subway;
        }
    }


    private void CedarLotus(int index)
    {
        for (int i = 0; i < 5; i++)
        {
            Forty[i].gameObject.GetComponent<Image>().sprite = i <= index ? Bulb1Subway : Bulb2Subway;
        }
        PorkTruckRevere.AirExpertly().FastTruck("1301", (index + 1).ToString());
        if (index < 3)
        {
            StartCoroutine(DrainBelle());
        }
        else
        {
            // 跳转到应用商店
            SoulOrExplain.instance.LiftAPPigWeekly();
            StartCoroutine(DrainBelle());
        }

        // 打点
        //PorkTruckRevere.GetInstance().SendEvent("1210", (index + 1).ToString());
    }

    IEnumerator DrainBelle(float waitTime = 0.5f)
    {
        yield return new WaitForSeconds(waitTime);
        DelayUIFine(GetType().Name);
    }
}
