using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoveUI : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("ClockText")]    public Text LocalExam;
[UnityEngine.Serialization.FormerlySerializedAs("Pointer")]    public RectTransform Shuttle;

    private long Overprint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UserFarLove(long endTime)
    {
        Overprint = endTime - PoemSeal.Zealand();

        StopCoroutine(nameof(PaymentLocal));
        StartCoroutine(nameof(PaymentLocal));
    }

    private IEnumerator PaymentLocal()
    {
        float angle = 0;
        while(Overprint > 0)
        {
            LocalExam.text = PoemSeal.InquireLizard(Overprint);
            Shuttle.DORotate(new Vector3(0, 0, angle), 0.5f);
            angle = angle - 90 == -360 ? 0 : angle - 90;
            Overprint--;
            yield return new WaitForSeconds(1);
        }
        if (Overprint <= 0)
        {
            LocalExam.text = "Finished";
            Shuttle.rotation = Quaternion.identity;
        }
    }
}
