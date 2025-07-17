using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoleAdorn : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("InitGroup")]    public GameObject UserAdorn;

    private GameObject DilutionScrubLichen;
    private float MarkWidth= 120f; // 两个item的position.x之差

    // Start is called before the first frame update
    void Start()
    {
        DilutionScrubLichen = UserAdorn.transform.Find("SlotCard_1").gameObject;
        float x = MarkWidth * 3;
        int multiCount = PinBeadEka.instance.UserFive.slot_group.Count;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < multiCount; j++)
            {
                GameObject fangkuai = Instantiate(DilutionScrubLichen, UserAdorn.transform);
                fangkuai.transform.localPosition = new Vector3(x + MarkWidth * multiCount * i + MarkWidth * j, DilutionScrubLichen.transform.localPosition.y, 0);
                fangkuai.transform.Find("Text").GetComponent<Text>().text = "×" + PinBeadEka.instance.UserFive.slot_group[j].multi;
            }
        }
    }

    public void initScrub()
    {
        UserAdorn.GetComponent<RectTransform>().localPosition = new Vector3(0, -10, 0);
    }

    public void Look(int index, Action<int> finish)
    {
        ExertEka.AirExpertly().EpicPurify(ExertMold.UIMusic.Sound_OneArmBandit);
        InfantileMercantile.IridescentLethal(UserAdorn, -(MarkWidth * 2 + MarkWidth * PinBeadEka.instance.UserFive.slot_group.Count * 3 + MarkWidth * (index + 1)), () =>
        {
            finish?.Invoke(PinBeadEka.instance.UserFive.slot_group[index].multi);
        });
    }
}
