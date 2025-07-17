using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class RadiateBelle : CoaxUIProwl
{
[UnityEngine.Serialization.FormerlySerializedAs("Sound_Button")]    public Button Cause_Senate;
[UnityEngine.Serialization.FormerlySerializedAs("Music_Button")]    public Button Exert_Senate;
[UnityEngine.Serialization.FormerlySerializedAs("SoundIcon")]    public Image CauseFuse;
[UnityEngine.Serialization.FormerlySerializedAs("MusicIcon")]    public Image ExertFuse;
[UnityEngine.Serialization.FormerlySerializedAs("Continue_Button")]    public Button Genotype_Senate;
[UnityEngine.Serialization.FormerlySerializedAs("CLose_Button")]    public Button CTram_Senate;
[UnityEngine.Serialization.FormerlySerializedAs("Restart_Button")]
    public Button Onstage_Senate;
[UnityEngine.Serialization.FormerlySerializedAs("MusicCloseSprite")]    public Sprite ExertDelaySubway;
[UnityEngine.Serialization.FormerlySerializedAs("MusicOpenSprite")]    public Sprite ExertLiftSubway;
[UnityEngine.Serialization.FormerlySerializedAs("SoundCloseSprite")]    public Sprite CauseDelaySubway;
[UnityEngine.Serialization.FormerlySerializedAs("SoundOpenSprite")]    public Sprite CauseLiftSubway;

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        ExertFuse.sprite = ExertEka.AirExpertly().ByExertConvex ? ExertLiftSubway : ExertDelaySubway;
        CauseFuse.sprite = ExertEka.AirExpertly().PurifyExertConvex ? CauseLiftSubway : CauseDelaySubway;
    }
    // Start is called before the first frame update
    void Start()
    {
        CTram_Senate.onClick.AddListener(() => {
            DelayUIFine(GetType().Name);
        });
        Genotype_Senate.onClick.AddListener(() => {
            DelayUIFine(GetType().Name);
        });
        Onstage_Senate.onClick.AddListener(() => {
            ScamExplain.Instance.OnstageScam();
            DOVirtual.DelayedCall(0.5f, () =>  //停顿
            {
                DelayUIFine(GetType().Name);
            });
        });
        
        Exert_Senate.onClick.AddListener(() =>
        {

            ExertEka.AirExpertly().ByExertConvex = !ExertEka.AirExpertly().ByExertConvex;
            ExertFuse.sprite = ExertEka.AirExpertly().ByExertConvex ? ExertLiftSubway : ExertDelaySubway;
        });
        Cause_Senate.onClick.AddListener(() =>
        {

            ExertEka.AirExpertly().PurifyExertConvex = !ExertEka.AirExpertly().PurifyExertConvex;
            CauseFuse.sprite = ExertEka.AirExpertly().PurifyExertConvex ? CauseLiftSubway : CauseDelaySubway;
        });
    }

}
