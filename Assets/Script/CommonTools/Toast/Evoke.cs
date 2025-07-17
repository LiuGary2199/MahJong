using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Evoke : CoaxUIProwl
{
[UnityEngine.Serialization.FormerlySerializedAs("ToastText")]    public Text EvokeExam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);

        EvokeExam.text = uiFormParams.ToString();
        StartCoroutine(nameof(LumpDelayEvoke));
    }

    private IEnumerator LumpDelayEvoke()
    {
        yield return new WaitForSeconds(2);
        DelayUIFine(GetType().Name);
    }

}
