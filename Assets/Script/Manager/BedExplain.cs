using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mkey;
public class BedExplain : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("BedTram")]    public GameObject BedTram;
    public static BedExplain Instance;
[UnityEngine.Serialization.FormerlySerializedAs("isOpenFly")]
    public bool OfLiftBed;
[UnityEngine.Serialization.FormerlySerializedAs("leftOrRight")]    public int DarnUpFlash;

    private int _AlarmLiftLove;
    private int _MowMayLove;
    
    private void Awake()
    {
        Instance = this;
        _MowMayLove = 0;
        OfLiftBed = true;
        _AlarmLiftLove = PinBeadEka.instance.ScamFive.bubble_cd;
        DarnUpFlash = 0;
    }

    private void OnEnable()
    {
        LiftIEBed();
    }
   
    public void LiftIEBed()
    {
        StopCoroutine(nameof(LiftBedBabble));
        StartCoroutine(nameof(LiftBedBabble));
    }
    IEnumerator LiftBedBabble()
    {
        while (OfLiftBed)
        {   
            if (_MowMayLove >= _AlarmLiftLove)
            {
                ThornyBedTram();
            }
            _MowMayLove++;
            yield return new WaitForSeconds(1);
        }
    }

    public void FigureBedTram()
    {
        if (transform.childCount > 0)
        {
            transform.GetChild(0).GetComponent<BedTram>().SurgeonBedTram();
            OfLiftBed = true;
        }
    }

    public void ThornyBedTram()
    {
        if (!OfLiftBed) { return; }
        // 新增：引导阶段禁止飞行气泡
        if (GameLevelHolder.CurrentLevel <= 1)
        {
            return;
        }
        //if (BubbleManager.GetInstance().IsWinGame()) { return; }
        //  if ( LevelManager.GetInstance().CurLevel > 1 && !StrikeUtil.IsApple
      if ( !StrikeUtil.WeGrade())
        {
            OfLiftBed = false;
            _MowMayLove = 0;
            GameObject obj = Instantiate(BedTram.gameObject);
            obj.transform.SetParent(transform);
            obj.transform.localScale = Vector3.one;
            obj.transform.localPosition = DarnUpFlash == 0 ? new Vector3(-650, 0, 0) : new Vector3(650, 0, 0);
        }
    }

    //public void SendFlyCollider(BubbleItem bubble)
    //{
    //    KeyValuesUpdate key = new KeyValuesUpdate(StringConst.SendFlyCollider, bubble);
    //    SeepageGrassy.SendMessage(StringConst.SendFlyCollider, key);
    //}
}
