using System;
using DG.Tweening;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

public class ScenicBerg : CoaxUIProwl
{
    public static ScenicBerg Instance;
[UnityEngine.Serialization.FormerlySerializedAs("rewardText")]
    public Text HungryExam;

   
    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
    }

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }

    private void Start()
    {
    }

    public void UserFive(double num)
    {
        HungryExam.text = num.ToString();
    }
    public override void Hidding()
    {
        base.Hidding();
    }
}