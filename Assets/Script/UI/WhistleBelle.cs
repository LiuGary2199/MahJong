using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

public class WhistleBelle : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("sliderImage")]    public Image StableNoisy;
[UnityEngine.Serialization.FormerlySerializedAs("progressText")]    public Text AccuracyExam;
    // Start is called before the first frame update
    void Start()
    {
        StableNoisy.fillAmount = 0;
        AccuracyExam.text = "0%";
    }

    // Update is called once per frame
    void Update()
    {
        if (StableNoisy.fillAmount <= 0.8f || (PinBeadEka.instance.Shaft && CashOutManager.AirExpertly().Ready))
        {
            StableNoisy.fillAmount += Time.deltaTime / 3f;
            AccuracyExam.text = (int)(StableNoisy.fillAmount * 100) + "%";
            if (StableNoisy.fillAmount >= 1)
            {
                StrikeUtil.WeGrade();
                Destroy(transform.parent.gameObject);
                LoneExplain.instance.CrabUser();
            }
        }
    }
}
